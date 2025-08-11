<div align="center">


|  |/  |--.-----.|  |--.-----.----.    |  |--.----.----|  |--.-----.
|     <  |  -||  _  |  _  |   _|    |  _  |   _|  |    <|  -|
||_|||||*||      |__|| |*___|||_____|


### An Advanced Network Scanning and Reconnaissance Tool for Windows

![Host Hunter Screenshot](https://i.imgur.com/FiZHw1x.png) 

</div>

---

> **Host Hunter** is a powerful network scanning tool built with C# and Windows Forms, inspired by applications like Angry IP Scanner. It is designed to provide network administrators and security enthusiasts with a comprehensive set of features to discover, analyze, and manage devices on a network. The application uses asynchronous operations to ensure the user interface remains responsive, even during intensive scans.

---

## Core Features

* **IP Range Scanning:** Define a network range using a start IP and a CIDR netmask (e.g., `/24`, `/27`) to scan.
* **Host Discovery:** Displays all hosts in the specified range, color-coding them as **'Active'** or **'Inactive'**.
* **Multi-threaded Performance:** Scans up to 100 hosts concurrently for maximum speed and efficiency.
* **Detailed Host Information:** For active hosts, it retrieves Ping time, Hostname, and a guessed Operating System (based on TTL).
* **Flexible Port Scanning:** Choose from predefined lists (Common, Web, Remote Access) and add your own custom ports to scan.
* **Persistent Comments:** Add and edit comments for any IP address. Comments are automatically saved and reloaded for each subnet.
* **Bookmark Management:** Save and manage your favorite IP ranges for quick access.
* **Right-Click Actions:** A dynamic context menu provides quick access to tools like Remote Desktop (RDP) and SSH if the relevant ports are open.
* **Export Results:** Save the entire scan result table to a `.csv` file for reporting and analysis.

---

## How to Use

1.  **Define the Scan Range:** Enter a starting IP address in the `IP Range` box and select a netmask (e.g., `/24`) from the dropdown. The "to" field will update automatically.
2.  **Select Ports to Scan:** Choose a predefined list from the `Port List` dropdown. You can also add extra, comma-separated ports in the `Additional Ports` box.
3.  **Start the Scan:** Click the **Start** button. Hosts will appear in the grid as they are discovered.
4.  **Interact with Results:** Right-click any active host for quick actions. You can also directly edit the `Comments` column for any host.
5.  **Manage Bookmarks:** To save the current range, click the **Add** button next to the Bookmarks dropdown. To remove a bookmark, select it from the list and click **Remove**.

---

## Saving Data

Host Hunter saves user data in a dedicated folder to maintain your settings and notes between sessions. This folder is located in your user's AppData directory:

`C:\Users\YourUsername\AppData\Roaming\Host Hunter\`

* **Bookmarks** are stored in `bookmarks.txt`.
* **Comments** are saved in separate `.csv` files named after the subnet (e.g., `192.168.1.0_24.csv`).

---

## Dependencies

* **.NET Framework:** The application requires the .NET Framework (version 4.7.2 or newer) to run.
* **OpenSSH Client (Optional):** For the right-click "SSH" feature to work, the OpenSSH Client must be installed on Windows. This is included by default in modern versions of Windows 10 and 11 but may need to be enabled in "Optional features".
