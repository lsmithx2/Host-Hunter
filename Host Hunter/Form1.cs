using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Host_Hunter
{
    public partial class Form1 : Form
    {
        private CancellationTokenSource _cancellationTokenSource;
        private Dictionary<string, List<int>> _predefinedPortLists;
        private List<int> _currentPortsToScan;
        private readonly string _dataFolderPath;
        private readonly string _bookmarksFilePath;
        private Dictionary<string, string> _comments;
        private string _currentSubnetIdentifier;

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            _dataFolderPath = Path.Combine(appDataPath, "Host Hunter");
            _bookmarksFilePath = Path.Combine(_dataFolderPath, "bookmarks.txt");
            Directory.CreateDirectory(_dataFolderPath);
            _comments = new Dictionary<string, string>();
            InitializeDataGridView();
            InitializeUI();
        }

        private void InitializeDataGridView()
        {
            dgvResults.Columns.Clear();
            dgvResults.AutoGenerateColumns = false;
            dgvResults.ReadOnly = false;

            var darkBg = Color.FromArgb(45, 45, 48);
            var lightText = Color.White;
            var gridBg = Color.FromArgb(60, 63, 65);

            dgvResults.BackgroundColor = gridBg;
            dgvResults.GridColor = gridBg;
            dgvResults.EnableHeadersVisualStyles = false;
            dgvResults.ColumnHeadersDefaultCellStyle.BackColor = darkBg;
            dgvResults.ColumnHeadersDefaultCellStyle.ForeColor = lightText;
            dgvResults.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvResults.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvResults.DefaultCellStyle.BackColor = gridBg;
            dgvResults.DefaultCellStyle.ForeColor = lightText;
            dgvResults.DefaultCellStyle.SelectionBackColor = Color.SteelBlue;
            dgvResults.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn() { Name = "IPAddress", HeaderText = "IP", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.None, Width = 140 });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Status", HeaderText = "Status", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Ping", HeaderText = "Ping", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Hostname", HeaderText = "Hostname", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn() { Name = "OS", HeaderText = "OS", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Ports", HeaderText = "Ports", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Comments", HeaderText = "Comments", ReadOnly = false, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        private void InitializeUI()
        {
            try
            {
                txtHostname.Text = Dns.GetHostName();

                cboNetmask.Items.Clear();
                for (int i = 32; i >= 1; i--)
                {
                    cboNetmask.Items.Add($"/{i}");
                }
                cboNetmask.SelectedItem = "/24";

                _predefinedPortLists = new Dictionary<string, List<int>>
                {
                    { "Common Ports", new List<int> { 21, 22, 23, 25, 53, 80, 110, 139, 443, 445, 3389, 8080 } },
                    { "Web Server Ports", new List<int> { 80, 443, 8000, 8080, 8443 } },
                    { "Remote Access", new List<int> { 22, 23, 3389, 5900 } },
                    { "Database Ports", new List<int> { 1433, 1521, 3306, 5432 } },
                    { "Email Ports", new List<int> { 25, 110, 143, 465, 993, 995 } },
                    { "File Transfer", new List<int> { 20, 21, 22, 69, 445 } }
                };

                cboPortSelection.Items.AddRange(_predefinedPortLists.Keys.ToArray());
                cboPortSelection.SelectedIndex = 0;

                LoadBookmarks();
            }
            catch (Exception ex)
            {
                txtHostname.Text = "N/A";
                MessageBox.Show($"Could not retrieve local host info: {ex.Message}", "Network Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            if (btnScan.Text == "Start")
            {
                if (!IPAddress.TryParse(txtIpStart.Text, out var startIp) || !IPAddress.TryParse(txtIpEnd.Text, out var endIp))
                {
                    MessageBox.Show("Invalid IP Range. Please enter valid start and end IP addresses.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _currentSubnetIdentifier = $"{startIp.ToString().Substring(0, startIp.ToString().LastIndexOf('.'))}.0{cboNetmask.SelectedItem.ToString().Replace('/', '_')}";
                LoadComments(_currentSubnetIdentifier);
                BuildPortList();
                dgvResults.Rows.Clear();
                progressBar.Value = 0;
                lblStatus.Text = "Scanning...";
                btnScan.Text = "Stop";
                _cancellationTokenSource = new CancellationTokenSource();

                try
                {
                    await ScanIpRangeAsync(startIp, endIp, _cancellationTokenSource.Token);
                    lblStatus.Text = "Scan Completed.";
                }
                catch (OperationCanceledException) { lblStatus.Text = "Scan Cancelled."; }
                catch (Exception ex)
                {
                    lblStatus.Text = "An error occurred.";
                    MessageBox.Show($"An error occurred during the scan: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { btnScan.Text = "Start"; }
            }
            else
            {
                _cancellationTokenSource?.Cancel();
                btnScan.Text = "Start";
                lblStatus.Text = "Cancelling...";
            }
        }

        private void BuildPortList()
        {
            string selectedListName = cboPortSelection.SelectedItem.ToString();
            _currentPortsToScan = new List<int>(_predefinedPortLists[selectedListName]);

            if (!string.IsNullOrWhiteSpace(txtCustomPorts.Text))
            {
                var customPorts = txtCustomPorts.Text.Split(new[] { ',', ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var portStr in customPorts)
                {
                    if (int.TryParse(portStr, out int port) && port > 0 && port <= 65535 && !_currentPortsToScan.Contains(port))
                    {
                        _currentPortsToScan.Add(port);
                    }
                }
            }
        }

        private async Task ScanIpRangeAsync(IPAddress startIp, IPAddress endIp, CancellationToken cancellationToken)
        {
            var semaphore = new SemaphoreSlim(100);

            var startIpBytes = startIp.GetAddressBytes();
            var endIpBytes = endIp.GetAddressBytes();
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(startIpBytes);
                Array.Reverse(endIpBytes);
            }

            var startIpInt = BitConverter.ToUInt32(startIpBytes, 0);
            var endIpInt = BitConverter.ToUInt32(endIpBytes, 0);

            int totalIps = (int)(endIpInt - startIpInt + 1);
            progressBar.Maximum = totalIps > 0 ? totalIps : 1;
            progressBar.Value = 0;

            var tasks = new List<Task>();
            for (uint i = startIpInt; i <= endIpInt; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                await semaphore.WaitAsync(cancellationToken);
                var currentIpBytes = BitConverter.GetBytes(i);
                if (BitConverter.IsLittleEndian) { Array.Reverse(currentIpBytes); }
                var currentIp = new IPAddress(currentIpBytes);

                tasks.Add(Task.Run(async () =>
                {
                    try { await PingAndUpdateGridAsync(currentIp, cancellationToken); }
                    finally { semaphore.Release(); }
                }, cancellationToken));
            }

            await Task.WhenAll(tasks);
        }

        private async Task PingAndUpdateGridAsync(IPAddress ipAddress, CancellationToken cancellationToken)
        {
            string hostname = "N/A";
            long roundtripTime = 0;
            bool isAlive = false;
            string status;
            Color rowColor;
            string os = "N/A";

            try
            {
                using (var pinger = new Ping())
                {
                    var reply = await pinger.SendPingAsync(ipAddress, 1000);
                    cancellationToken.ThrowIfCancellationRequested();
                    if (reply.Status == IPStatus.Success)
                    {
                        isAlive = true;
                        roundtripTime = reply.RoundtripTime;
                        os = GuessOSByTtl(reply.Options.Ttl);
                    }
                }
            }
            catch (Exception) { /* Ignore ping exceptions */ }

            string openPorts = await ScanPortsAsync(ipAddress, cancellationToken);
            if (!string.IsNullOrEmpty(openPorts)) isAlive = true;

            if (isAlive)
            {
                status = "Active";
                rowColor = Color.FromArgb(173, 255, 173); // Light green
                try
                {
                    var hostEntry = await Dns.GetHostEntryAsync(ipAddress);
                    hostname = hostEntry.HostName;
                }
                catch (SocketException) { hostname = "N/A"; }
                catch { hostname = "N/A"; }
            }
            else
            {
                status = "Inactive";
                rowColor = Color.FromArgb(255, 102, 102); // Light red
            }

            dgvResults.Invoke((MethodInvoker)delegate
            {
                if (cancellationToken.IsCancellationRequested) return;

                string comment = _comments.ContainsKey(ipAddress.ToString()) ? _comments[ipAddress.ToString()] : "";
                int rowIndex = dgvResults.Rows.Add(ipAddress.ToString(), status, isAlive ? $"{roundtripTime}ms" : "-", hostname, os, openPorts, comment);
                dgvResults.Rows[rowIndex].Cells["Status"].Style.ForeColor = rowColor;
                dgvResults.Sort(new IpAddressComparer());

                if (progressBar.Value < progressBar.Maximum) progressBar.Value++;
            });
        }

        private async Task<string> ScanPortsAsync(IPAddress ipAddress, CancellationToken cancellationToken)
        {
            var openPorts = new List<int>();
            var tasks = _currentPortsToScan.Select(port => Task.Run(async () =>
            {
                cancellationToken.ThrowIfCancellationRequested();
                try
                {
                    using (var client = new TcpClient())
                    {
                        var task = client.ConnectAsync(ipAddress, port);
                        if (await Task.WhenAny(task, Task.Delay(200, cancellationToken)) == task && client.Connected)
                        {
                            lock (openPorts)
                            {
                                openPorts.Add(port);
                            }
                        }
                    }
                }
                catch { /* Ignore exceptions */ }
            }, cancellationToken));

            await Task.WhenAll(tasks);
            openPorts.Sort();
            return string.Join(", ", openPorts);
        }

        private void UpdateIpRange(object sender, EventArgs e)
        {
            if (IPAddress.TryParse(txtIpStart.Text, out IPAddress baseIp) && cboNetmask.SelectedItem != null)
            {
                string cidrString = $"{baseIp}{cboNetmask.SelectedItem}";
                if (TryParseCidr(cidrString, out IPAddress startIp, out IPAddress endIp))
                {
                    txtIpStart.Text = startIp.ToString();
                    txtIpEnd.Text = endIp.ToString();
                }
            }
        }

        public static bool TryParseCidr(string cidr, out IPAddress startIp, out IPAddress endIp)
        {
            startIp = null;
            endIp = null;
            var parts = cidr.Split('/');
            if (parts.Length != 2) return false;

            if (!IPAddress.TryParse(parts[0], out IPAddress baseIp)) return false;
            if (!int.TryParse(parts[1], out int maskBits) || maskBits < 0 || maskBits > 32) return false;

            try
            {
                byte[] ipBytes = baseIp.GetAddressBytes();
                uint ipAsUint = (uint)ipBytes[0] << 24 | (uint)ipBytes[1] << 16 | (uint)ipBytes[2] << 8 | ipBytes[3];
                uint mask = maskBits == 0 ? 0 : 0xffffffff << (32 - maskBits);
                uint networkAddress = ipAsUint & mask;
                uint broadcastAddress = networkAddress | ~mask;

                startIp = new IPAddress(BitConverter.GetBytes(networkAddress).Reverse().ToArray());
                endIp = new IPAddress(BitConverter.GetBytes(broadcastAddress).Reverse().ToArray());
                return true;
            }
            catch { return false; }
        }

        private void btnSaveResults_Click(object sender, EventArgs e)
        {
            if (dgvResults.Rows.Count == 0)
            {
                MessageBox.Show("There are no results to save.", "Save Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                sfd.FileName = $"HostHunter_Scan_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var sb = new StringBuilder();
                        var headers = dgvResults.Columns.Cast<DataGridViewColumn>();
                        sb.AppendLine(string.Join(",", headers.Select(column => $"\"{column.HeaderText}\"").ToArray()));
                        foreach (DataGridViewRow row in dgvResults.Rows)
                        {
                            var cells = row.Cells.Cast<DataGridViewCell>();
                            sb.AppendLine(string.Join(",", cells.Select(cell => $"\"{cell.Value}\"").ToArray()));
                        }
                        File.WriteAllText(sfd.FileName, sb.ToString());
                        MessageBox.Show("Results saved successfully!", "Save Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void dgvResults_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvResults.Columns["Comments"].Index) return;

            string ip = dgvResults.Rows[e.RowIndex].Cells["IPAddress"].Value.ToString();
            string comment = dgvResults.Rows[e.RowIndex].Cells["Comments"].Value?.ToString() ?? "";

            if (_comments.ContainsKey(ip)) _comments[ip] = comment;
            else _comments.Add(ip, comment);

            SaveComments(_currentSubnetIdentifier);
        }

        private void LoadComments(string subnetIdentifier)
        {
            _comments.Clear();
            string filePath = Path.Combine(_dataFolderPath, $"{subnetIdentifier}.csv");
            if (!File.Exists(filePath)) return;

            try
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(new[] { ',' }, 2);
                    if (parts.Length == 2 && !_comments.ContainsKey(parts[0]))
                    {
                        _comments.Add(parts[0], parts[1]);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error loading comments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void SaveComments(string subnetIdentifier)
        {
            if (string.IsNullOrEmpty(subnetIdentifier)) return;
            string filePath = Path.Combine(_dataFolderPath, $"{subnetIdentifier}.csv");
            try
            {
                var lines = _comments.Select(kvp => $"{kvp.Key},{kvp.Value}");
                File.WriteAllLines(filePath, lines);
            }
            catch (Exception ex) { MessageBox.Show($"Error saving comments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void LoadBookmarks()
        {
            cboBookmarks.Items.Clear();
            if (File.Exists(_bookmarksFilePath))
            {
                try
                {
                    var bookmarks = File.ReadAllLines(_bookmarksFilePath);
                    cboBookmarks.Items.AddRange(bookmarks);
                }
                catch (Exception ex) { MessageBox.Show($"Error loading bookmarks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void SaveBookmarks()
        {
            try
            {
                var bookmarks = cboBookmarks.Items.Cast<string>().ToArray();
                File.WriteAllLines(_bookmarksFilePath, bookmarks);
            }
            catch (Exception ex) { MessageBox.Show($"Error saving bookmarks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAddBookmark_Click(object sender, EventArgs e)
        {
            string bookmark = $"{txtIpStart.Text} {cboNetmask.SelectedItem}";
            if (!cboBookmarks.Items.Contains(bookmark))
            {
                cboBookmarks.Items.Add(bookmark);
                SaveBookmarks();
            }
        }

        private void cboBookmarks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBookmarks.SelectedItem == null) return;

            string bookmark = cboBookmarks.SelectedItem.ToString();
            var parts = bookmark.Split(' ');
            if (parts.Length == 2)
            {
                txtIpStart.Text = parts[0];
                cboNetmask.SelectedItem = parts[1];
                UpdateIpRange(sender, e);
            }
        }

        private void btnRemoveBookmark_Click(object sender, EventArgs e)
        {
            if (cboBookmarks.SelectedIndex >= 0)
            {
                cboBookmarks.Items.RemoveAt(cboBookmarks.SelectedIndex);
                SaveBookmarks();
            }
        }

        private string GuessOSByTtl(int ttl)
        {
            if (ttl > 0 && ttl <= 64) return "Linux/Unix";
            if (ttl > 64 && ttl <= 128) return "Windows";
            return "Unknown";
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            var selectedRow = dgvResults.SelectedRows[0];
            var portsCellValue = selectedRow.Cells["Ports"].Value?.ToString() ?? "";
            var openPorts = portsCellValue.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                          .Select(p => p.Trim().Split(' ')[0])
                                          .ToList();

            remoteDesktopToolStripMenuItem.Enabled = openPorts.Contains("3389");
            sshToolStripMenuItem.Enabled = openPorts.Contains("22");
            openInBrowserToolStripMenuItem.Enabled = openPorts.Contains("80") || openPorts.Contains("443");
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (dgvResults.SelectedRows.Count == 0) return;
            var selectedRow = dgvResults.SelectedRows[0];
            string ipAddress = selectedRow.Cells["IPAddress"].Value.ToString();

            try
            {
                switch (e.ClickedItem.Name)
                {
                    case "copyIPToolStripMenuItem":
                        Clipboard.SetText(ipAddress);
                        break;
                    case "openInBrowserToolStripMenuItem":
                        Process.Start($"http://{ipAddress}");
                        break;
                    case "remoteDesktopToolStripMenuItem":
                        Process.Start("mstsc.exe", $"/v:{ipAddress}");
                        break;
                    case "sshToolStripMenuItem":
                        Process.Start("cmd.exe", $"/k ssh {ipAddress}");
                        break;
                }
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show($"Could not start the application. Please ensure it is installed and in your system's PATH.\n\nError: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    class IpAddressComparer : System.Collections.IComparer
    {
        public int Compare(object x, object y)
        {
            var rowA = (DataGridViewRow)x;
            var rowB = (DataGridViewRow)y;
            var ipA = IPAddress.Parse((string)rowA.Cells["IPAddress"].Value);
            var ipB = IPAddress.Parse((string)rowB.Cells["IPAddress"].Value);
            var bytesA = ipA.GetAddressBytes();
            var bytesB = ipB.GetAddressBytes();
            for (int i = 0; i < bytesA.Length; i++)
            {
                if (bytesA[i] != bytesB[i])
                {
                    return bytesA[i].CompareTo(bytesB[i]);
                }
            }
            return 0;
        }
    }
}