namespace Host_Hunter
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblIpStartLabel = new System.Windows.Forms.Label();
            this.txtIpStart = new System.Windows.Forms.TextBox();
            this.lblIpEndLabel = new System.Windows.Forms.Label();
            this.txtIpEnd = new System.Windows.Forms.TextBox();
            this.btnScan = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openInBrowserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteDesktopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblHostnameLabel = new System.Windows.Forms.Label();
            this.txtHostname = new System.Windows.Forms.TextBox();
            this.cboNetmask = new System.Windows.Forms.ComboBox();
            this.lblNetmaskLabel = new System.Windows.Forms.Label();
            this.lblCustomPorts = new System.Windows.Forms.Label();
            this.txtCustomPorts = new System.Windows.Forms.TextBox();
            this.btnSaveResults = new System.Windows.Forms.Button();
            this.lblPortSelection = new System.Windows.Forms.Label();
            this.cboPortSelection = new System.Windows.Forms.ComboBox();
            this.lblBookmarks = new System.Windows.Forms.Label();
            this.cboBookmarks = new System.Windows.Forms.ComboBox();
            this.btnAddBookmark = new System.Windows.Forms.Button();
            this.btnRemoveBookmark = new System.Windows.Forms.Button();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIpStartLabel
            // 
            this.lblIpStartLabel.AutoSize = true;
            this.lblIpStartLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpStartLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblIpStartLabel.Location = new System.Drawing.Point(12, 13);
            this.lblIpStartLabel.Name = "lblIpStartLabel";
            this.lblIpStartLabel.Size = new System.Drawing.Size(92, 28);
            this.lblIpStartLabel.TabIndex = 8;
            this.lblIpStartLabel.Text = "IP Range:";
            // 
            // txtIpStart
            // 
            this.txtIpStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtIpStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpStart.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpStart.ForeColor = System.Drawing.Color.White;
            this.txtIpStart.Location = new System.Drawing.Point(82, 12);
            this.txtIpStart.Name = "txtIpStart";
            this.txtIpStart.Size = new System.Drawing.Size(150, 30);
            this.txtIpStart.TabIndex = 11;
            this.txtIpStart.Text = "10.10.11.0";
            this.txtIpStart.Leave += new System.EventHandler(this.UpdateIpRange);
            // 
            // lblIpEndLabel
            // 
            this.lblIpEndLabel.AutoSize = true;
            this.lblIpEndLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpEndLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblIpEndLabel.Location = new System.Drawing.Point(238, 13);
            this.lblIpEndLabel.Name = "lblIpEndLabel";
            this.lblIpEndLabel.Size = new System.Drawing.Size(35, 28);
            this.lblIpEndLabel.TabIndex = 12;
            this.lblIpEndLabel.Text = "to:";
            // 
            // txtIpEnd
            // 
            this.txtIpEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtIpEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIpEnd.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIpEnd.ForeColor = System.Drawing.Color.White;
            this.txtIpEnd.Location = new System.Drawing.Point(267, 12);
            this.txtIpEnd.Name = "txtIpEnd";
            this.txtIpEnd.Size = new System.Drawing.Size(150, 30);
            this.txtIpEnd.TabIndex = 13;
            this.txtIpEnd.Text = "10.10.11.255";
            // 
            // btnScan
            // 
            this.btnScan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnScan.FlatAppearance.BorderSize = 0;
            this.btnScan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScan.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScan.ForeColor = System.Drawing.Color.White;
            this.btnScan.Location = new System.Drawing.Point(267, 45);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(150, 23);
            this.btnScan.TabIndex = 4;
            this.btnScan.Text = "Start";
            this.btnScan.UseVisualStyleBackColor = false;
            this.btnScan.Click += new System.EventHandler(this.btnScan_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.AllowUserToResizeRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvResults.Location = new System.Drawing.Point(15, 81);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.RowHeadersWidth = 62;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(1151, 726);
            this.dgvResults.TabIndex = 5;
            this.dgvResults.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyIPToolStripMenuItem,
            this.openInBrowserToolStripMenuItem,
            this.remoteDesktopToolStripMenuItem,
            this.sshToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(218, 132);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // copyIPToolStripMenuItem
            // 
            this.copyIPToolStripMenuItem.Name = "copyIPToolStripMenuItem";
            this.copyIPToolStripMenuItem.Size = new System.Drawing.Size(217, 32);
            this.copyIPToolStripMenuItem.Text = "Copy IP Address";
            // 
            // openInBrowserToolStripMenuItem
            // 
            this.openInBrowserToolStripMenuItem.Name = "openInBrowserToolStripMenuItem";
            this.openInBrowserToolStripMenuItem.Size = new System.Drawing.Size(217, 32);
            this.openInBrowserToolStripMenuItem.Text = "Open in Browser";
            // 
            // remoteDesktopToolStripMenuItem
            // 
            this.remoteDesktopToolStripMenuItem.Name = "remoteDesktopToolStripMenuItem";
            this.remoteDesktopToolStripMenuItem.Size = new System.Drawing.Size(217, 32);
            this.remoteDesktopToolStripMenuItem.Text = "Remote Desktop";
            // 
            // sshToolStripMenuItem
            // 
            this.sshToolStripMenuItem.Name = "sshToolStripMenuItem";
            this.sshToolStripMenuItem.Size = new System.Drawing.Size(217, 32);
            this.sshToolStripMenuItem.Text = "SSH";
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(15, 813);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1026, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 6;
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblStatus.Location = new System.Drawing.Point(1047, 813);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(105, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Ready";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHostnameLabel
            // 
            this.lblHostnameLabel.AutoSize = true;
            this.lblHostnameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHostnameLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblHostnameLabel.Location = new System.Drawing.Point(12, 46);
            this.lblHostnameLabel.Name = "lblHostnameLabel";
            this.lblHostnameLabel.Size = new System.Drawing.Size(105, 28);
            this.lblHostnameLabel.TabIndex = 14;
            this.lblHostnameLabel.Text = "Hostname:";
            // 
            // txtHostname
            // 
            this.txtHostname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtHostname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHostname.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHostname.ForeColor = System.Drawing.Color.White;
            this.txtHostname.Location = new System.Drawing.Point(82, 45);
            this.txtHostname.Name = "txtHostname";
            this.txtHostname.ReadOnly = true;
            this.txtHostname.Size = new System.Drawing.Size(150, 30);
            this.txtHostname.TabIndex = 15;
            // 
            // cboNetmask
            // 
            this.cboNetmask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cboNetmask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNetmask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboNetmask.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboNetmask.ForeColor = System.Drawing.Color.White;
            this.cboNetmask.FormattingEnabled = true;
            this.cboNetmask.Location = new System.Drawing.Point(499, 12);
            this.cboNetmask.Name = "cboNetmask";
            this.cboNetmask.Size = new System.Drawing.Size(80, 31);
            this.cboNetmask.TabIndex = 9;
            this.cboNetmask.SelectedIndexChanged += new System.EventHandler(this.UpdateIpRange);
            // 
            // lblNetmaskLabel
            // 
            this.lblNetmaskLabel.AutoSize = true;
            this.lblNetmaskLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNetmaskLabel.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblNetmaskLabel.Location = new System.Drawing.Point(430, 13);
            this.lblNetmaskLabel.Name = "lblNetmaskLabel";
            this.lblNetmaskLabel.Size = new System.Drawing.Size(93, 28);
            this.lblNetmaskLabel.TabIndex = 16;
            this.lblNetmaskLabel.Text = "Netmask:";
            // 
            // lblCustomPorts
            // 
            this.lblCustomPorts.AutoSize = true;
            this.lblCustomPorts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomPorts.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblCustomPorts.Location = new System.Drawing.Point(595, 46);
            this.lblCustomPorts.Name = "lblCustomPorts";
            this.lblCustomPorts.Size = new System.Drawing.Size(157, 28);
            this.lblCustomPorts.TabIndex = 17;
            this.lblCustomPorts.Text = "Additional Ports:";
            // 
            // txtCustomPorts
            // 
            this.txtCustomPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtCustomPorts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomPorts.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomPorts.ForeColor = System.Drawing.Color.White;
            this.txtCustomPorts.Location = new System.Drawing.Point(710, 45);
            this.txtCustomPorts.Name = "txtCustomPorts";
            this.txtCustomPorts.Size = new System.Drawing.Size(162, 30);
            this.txtCustomPorts.TabIndex = 18;
            this.txtCustomPorts.Text = "8081, 5000";
            // 
            // btnSaveResults
            // 
            this.btnSaveResults.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveResults.FlatAppearance.BorderSize = 0;
            this.btnSaveResults.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveResults.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveResults.ForeColor = System.Drawing.Color.White;
            this.btnSaveResults.Location = new System.Drawing.Point(429, 45);
            this.btnSaveResults.Name = "btnSaveResults";
            this.btnSaveResults.Size = new System.Drawing.Size(150, 23);
            this.btnSaveResults.TabIndex = 19;
            this.btnSaveResults.Text = "Save Results";
            this.btnSaveResults.UseVisualStyleBackColor = false;
            this.btnSaveResults.Click += new System.EventHandler(this.btnSaveResults_Click);
            // 
            // lblPortSelection
            // 
            this.lblPortSelection.AutoSize = true;
            this.lblPortSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPortSelection.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblPortSelection.Location = new System.Drawing.Point(595, 13);
            this.lblPortSelection.Name = "lblPortSelection";
            this.lblPortSelection.Size = new System.Drawing.Size(86, 28);
            this.lblPortSelection.TabIndex = 17;
            this.lblPortSelection.Text = "Port List:";
            // 
            // cboPortSelection
            // 
            this.cboPortSelection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cboPortSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPortSelection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboPortSelection.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboPortSelection.ForeColor = System.Drawing.Color.White;
            this.cboPortSelection.FormattingEnabled = true;
            this.cboPortSelection.Location = new System.Drawing.Point(660, 12);
            this.cboPortSelection.Name = "cboPortSelection";
            this.cboPortSelection.Size = new System.Drawing.Size(150, 31);
            this.cboPortSelection.TabIndex = 20;
            // 
            // lblBookmarks
            // 
            this.lblBookmarks.AutoSize = true;
            this.lblBookmarks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookmarks.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblBookmarks.Location = new System.Drawing.Point(825, 13);
            this.lblBookmarks.Name = "lblBookmarks";
            this.lblBookmarks.Size = new System.Drawing.Size(113, 28);
            this.lblBookmarks.TabIndex = 21;
            this.lblBookmarks.Text = "Bookmarks:";
            // 
            // cboBookmarks
            // 
            this.cboBookmarks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cboBookmarks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBookmarks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboBookmarks.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBookmarks.ForeColor = System.Drawing.Color.White;
            this.cboBookmarks.FormattingEnabled = true;
            this.cboBookmarks.Location = new System.Drawing.Point(905, 12);
            this.cboBookmarks.Name = "cboBookmarks";
            this.cboBookmarks.Size = new System.Drawing.Size(180, 31);
            this.cboBookmarks.TabIndex = 22;
            this.cboBookmarks.SelectedIndexChanged += new System.EventHandler(this.cboBookmarks_SelectedIndexChanged);
            // 
            // btnAddBookmark
            // 
            this.btnAddBookmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnAddBookmark.FlatAppearance.BorderSize = 0;
            this.btnAddBookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBookmark.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBookmark.ForeColor = System.Drawing.Color.White;
            this.btnAddBookmark.Location = new System.Drawing.Point(1091, 12);
            this.btnAddBookmark.Name = "btnAddBookmark";
            this.btnAddBookmark.Size = new System.Drawing.Size(75, 23);
            this.btnAddBookmark.TabIndex = 23;
            this.btnAddBookmark.Text = "Add";
            this.btnAddBookmark.UseVisualStyleBackColor = false;
            this.btnAddBookmark.Click += new System.EventHandler(this.btnAddBookmark_Click);
            // 
            // btnRemoveBookmark
            // 
            this.btnRemoveBookmark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnRemoveBookmark.FlatAppearance.BorderSize = 0;
            this.btnRemoveBookmark.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveBookmark.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveBookmark.ForeColor = System.Drawing.Color.White;
            this.btnRemoveBookmark.Location = new System.Drawing.Point(1091, 45);
            this.btnRemoveBookmark.Name = "btnRemoveBookmark";
            this.btnRemoveBookmark.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveBookmark.TabIndex = 24;
            this.btnRemoveBookmark.Text = "Remove";
            this.btnRemoveBookmark.UseVisualStyleBackColor = false;
            this.btnRemoveBookmark.Click += new System.EventHandler(this.btnRemoveBookmark_Click);
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearch.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblSearch.Location = new System.Drawing.Point(888, 46);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(74, 28);
            this.lblSearch.TabIndex = 25;
            this.lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.ForeColor = System.Drawing.Color.White;
            this.txtSearch.Location = new System.Drawing.Point(943, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(142, 30);
            this.txtSearch.TabIndex = 26;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1178, 850);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.btnRemoveBookmark);
            this.Controls.Add(this.btnAddBookmark);
            this.Controls.Add(this.cboBookmarks);
            this.Controls.Add(this.lblBookmarks);
            this.Controls.Add(this.cboPortSelection);
            this.Controls.Add(this.lblPortSelection);
            this.Controls.Add(this.btnSaveResults);
            this.Controls.Add(this.txtCustomPorts);
            this.Controls.Add(this.lblCustomPorts);
            this.Controls.Add(this.cboNetmask);
            this.Controls.Add(this.lblNetmaskLabel);
            this.Controls.Add(this.txtHostname);
            this.Controls.Add(this.lblHostnameLabel);
            this.Controls.Add(this.txtIpEnd);
            this.Controls.Add(this.lblIpEndLabel);
            this.Controls.Add(this.txtIpStart);
            this.Controls.Add(this.lblIpStartLabel);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.btnScan);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(900, 400);
            this.Name = "Form1";
            this.Text = "Host Hunter";
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtIpStart;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblIpStartLabel;
        private System.Windows.Forms.Label lblIpEndLabel;
        private System.Windows.Forms.TextBox txtIpEnd;
        private System.Windows.Forms.Label lblHostnameLabel;
        private System.Windows.Forms.TextBox txtHostname;
        private System.Windows.Forms.ComboBox cboNetmask;
        private System.Windows.Forms.Label lblNetmaskLabel;
        private System.Windows.Forms.Label lblCustomPorts;
        private System.Windows.Forms.TextBox txtCustomPorts;
        private System.Windows.Forms.Button btnSaveResults;
        private System.Windows.Forms.Label lblPortSelection;
        private System.Windows.Forms.ComboBox cboPortSelection;
        private System.Windows.Forms.Label lblBookmarks;
        private System.Windows.Forms.ComboBox cboBookmarks;
        private System.Windows.Forms.Button btnAddBookmark;
        private System.Windows.Forms.Button btnRemoveBookmark;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem copyIPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openInBrowserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteDesktopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sshToolStripMenuItem;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
    }
}