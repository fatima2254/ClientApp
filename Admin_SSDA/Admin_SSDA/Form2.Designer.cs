
namespace Admin_SSDA
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.action_btn_get = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DisplayVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstallDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Publisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.InstallLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Version = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionMinor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.VersionMajor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EstimatedSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UninstallString = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.HelpLink = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstDisplayHardware = new System.Windows.Forms.ListView();
            this.send_email = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // action_btn_get
            // 
            this.action_btn_get.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.action_btn_get.ForeColor = System.Drawing.Color.Green;
            this.action_btn_get.Location = new System.Drawing.Point(1046, 25);
            this.action_btn_get.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.action_btn_get.Name = "action_btn_get";
            this.action_btn_get.Size = new System.Drawing.Size(204, 45);
            this.action_btn_get.TabIndex = 0;
            this.action_btn_get.Text = "GET The List";
            this.action_btn_get.UseVisualStyleBackColor = true;
            this.action_btn_get.Click += new System.EventHandler(this.action_btn_get_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 37);
            this.label1.TabIndex = 3;
            this.label1.Text = "RESULT";
            // 
            // DisplayName
            // 
            this.DisplayName.Text = "DisplayName";
            this.DisplayName.Width = 72;
            // 
            // DisplayVersion
            // 
            this.DisplayVersion.Text = "DisplayVersion";
            this.DisplayVersion.Width = 73;
            // 
            // InstallDate
            // 
            this.InstallDate.Text = "InstallDate";
            this.InstallDate.Width = 70;
            // 
            // Publisher
            // 
            this.Publisher.Text = "Publisher";
            // 
            // InstallLocation
            // 
            this.InstallLocation.Text = "InstallLocation";
            // 
            // Version
            // 
            this.Version.Text = "Version";
            // 
            // VersionMinor
            // 
            this.VersionMinor.Text = "VersionMinor";
            // 
            // VersionMajor
            // 
            this.VersionMajor.Text = "VersionMajor";
            // 
            // EstimatedSize
            // 
            this.EstimatedSize.Text = "EstimatedSize";
            // 
            // UninstallString
            // 
            this.UninstallString.Text = "UninstallString";
            // 
            // HelpLink
            // 
            this.HelpLink.Text = "HelpLink";
            // 
            // lstDisplayHardware
            // 
            this.lstDisplayHardware.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DisplayName,
            this.EstimatedSize,
            this.DisplayVersion,
            this.InstallDate,
            this.Publisher,
            this.InstallLocation,
            this.Version,
            this.VersionMinor,
            this.VersionMajor,
            this.UninstallString,
            this.HelpLink});
            this.lstDisplayHardware.HideSelection = false;
            this.lstDisplayHardware.Location = new System.Drawing.Point(26, 82);
            this.lstDisplayHardware.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstDisplayHardware.Name = "lstDisplayHardware";
            this.lstDisplayHardware.Size = new System.Drawing.Size(1222, 756);
            this.lstDisplayHardware.TabIndex = 17;
            this.lstDisplayHardware.UseCompatibleStateImageBehavior = false;
            this.lstDisplayHardware.View = System.Windows.Forms.View.Details;
            // 
            // send_email
            // 
            this.send_email.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.send_email.Location = new System.Drawing.Point(920, 25);
            this.send_email.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.send_email.Name = "send_email";
            this.send_email.Size = new System.Drawing.Size(123, 45);
            this.send_email.TabIndex = 18;
            this.send_email.Text = "Send Email";
            this.send_email.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(783, 28);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 42);
            this.button1.TabIndex = 19;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1268, 863);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.send_email);
            this.Controls.Add(this.lstDisplayHardware);
            this.Controls.Add(this.action_btn_get);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "List of Programs";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button action_btn_get;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader DisplayName;
        private System.Windows.Forms.ColumnHeader DisplayVersion;
        private System.Windows.Forms.ColumnHeader InstallDate;
        private System.Windows.Forms.ColumnHeader Publisher;
        private System.Windows.Forms.ColumnHeader InstallLocation;
        private System.Windows.Forms.ColumnHeader Version;
        private System.Windows.Forms.ColumnHeader VersionMinor;
        private System.Windows.Forms.ColumnHeader VersionMajor;
        private System.Windows.Forms.ColumnHeader EstimatedSize;
        private System.Windows.Forms.ColumnHeader UninstallString;
        private System.Windows.Forms.ColumnHeader HelpLink;
        private System.Windows.Forms.ListView lstDisplayHardware;
        private System.Windows.Forms.Button send_email;
        private System.Windows.Forms.Button button1;
    }
}