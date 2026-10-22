// rev-q3mh4o-20261022 Form1.Designer.cs
// rev-b8f3c1-20260825 Form1.Designer.cs
﻿namespace YuzuLauncher
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblKeysStatus = new System.Windows.Forms.Label();
            this.lstGames      = new System.Windows.Forms.ListBox();
            this.lblGuide      = new System.Windows.Forms.Label();
            this.btnLaunch     = new System.Windows.Forms.Button();
            this.btnRefresh    = new System.Windows.Forms.Button();
            this.btnAddDir     = new System.Windows.Forms.Button();
            this.btnOpenKeys   = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblKeysStatus.Location = new System.Drawing.Point(12, 12);
            this.lblKeysStatus.Size     = new System.Drawing.Size(560, 22);
            this.lstGames.Location      = new System.Drawing.Point(12, 42);
            this.lstGames.Size          = new System.Drawing.Size(560, 140);
            this.lblGuide.Location      = new System.Drawing.Point(12, 192);
            this.lblGuide.Size          = new System.Drawing.Size(560, 80);
            this.lblGuide.AutoSize      = false;

            this.btnLaunch.Text      = "Launch Yuzu";
            this.btnLaunch.Location  = new System.Drawing.Point(12, 280);
            this.btnLaunch.Size      = new System.Drawing.Size(120, 34);
            this.btnLaunch.Click    += new System.EventHandler(this.btnLaunch_Click);

            this.btnRefresh.Text     = "Refresh";
            this.btnRefresh.Location = new System.Drawing.Point(146, 280);
            this.btnRefresh.Size     = new System.Drawing.Size(90, 34);
            this.btnRefresh.Click   += new System.EventHandler(this.btnRefresh_Click);

            this.btnAddDir.Text      = "Add Games Folder";
            this.btnAddDir.Location  = new System.Drawing.Point(250, 280);
            this.btnAddDir.Size      = new System.Drawing.Size(140, 34);
            this.btnAddDir.Click    += new System.EventHandler(this.btnAddDir_Click);

            this.btnOpenKeys.Text    = "Open Keys Folder";
            this.btnOpenKeys.Location= new System.Drawing.Point(404, 280);
            this.btnOpenKeys.Size    = new System.Drawing.Size(140, 34);
            this.btnOpenKeys.Click  += new System.EventHandler(this.btnOpenKeys_Click);

            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblKeysStatus, this.lstGames, this.lblGuide,
                this.btnLaunch, this.btnRefresh, this.btnAddDir, this.btnOpenKeys });

            this.Text          = "Yuzu Emulator Launcher v1734";
            this.ClientSize    = new System.Drawing.Size(586, 332);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Label   lblKeysStatus, lblGuide;
        private System.Windows.Forms.ListBox lstGames;
        private System.Windows.Forms.Button  btnLaunch, btnRefresh, btnAddDir, btnOpenKeys;
    }
}