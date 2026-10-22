// rev-q3mh4o-20261022 Form1.cs
// rev-b8f3c1-20260825 Form1.cs
﻿using System;
using System.IO;
using System.Windows.Forms;

namespace YuzuLauncher
{
    public partial class MainForm : Form
    {
        private readonly GameLibrary _library = new();

        public MainForm()
        {
            InitializeComponent();
            RefreshStatus();
        }

        private void RefreshStatus()
        {
            var keysError = KeysValidator.DetectMissingKeys();
            lblKeysStatus.Text       = keysError ?? "prod.keys: OK";
            lblKeysStatus.ForeColor  = keysError == null
                ? System.Drawing.Color.LimeGreen
                : System.Drawing.Color.OrangeRed;

            lstGames.Items.Clear();
            foreach (var g in _library.Scan())
                lstGames.Items.Add($"{g.Name}  [{g.Extension}]  {g.SizeBytes / 1048576} MB");

            lblGuide.Text = KeysValidator.GetSetupGuide();
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var exe = EmulatorLauncher.FindYuzuExe()
                   ?? Path.Combine(Application.StartupPath, "yuzu.exe");
            if (!File.Exists(exe)) { MessageBox.Show("yuzu.exe not found."); return; }
            EmulatorLauncher.Launch(exe);
        }

        private void btnRefresh_Click(object sender, EventArgs e) => RefreshStatus();

        private void btnAddDir_Click(object sender, EventArgs e)
        {
            using var dlg = new FolderBrowserDialog { Description = "Select game directory" };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _library.AddDirectory(dlg.SelectedPath);
                RefreshStatus();
            }
        }

        private void btnOpenKeys_Click(object sender, EventArgs e)
        {
            var dir = Path.GetDirectoryName(KeysValidator.GetKeysPath())!;
            Directory.CreateDirectory(dir);
            System.Diagnostics.Process.Start("explorer.exe", dir);
        }
    }
}