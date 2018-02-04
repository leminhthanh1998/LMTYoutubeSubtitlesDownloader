namespace LMT_Youtube_Subtitles_Downloader
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txbLink = new System.Windows.Forms.TextBox();
            this.btnCheck = new MetroFramework.Controls.MetroButton();
            this.cmbSub = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.btnDownload = new MetroFramework.Controls.MetroButton();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.cmbTrans = new MetroFramework.Controls.MetroComboBox();
            this.labelProcess = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(23, 74);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(119, 25);
            this.metroLabel1.TabIndex = 0;
            this.metroLabel1.Text = "Link Youtube: ";
            // 
            // txbLink
            // 
            this.txbLink.Location = new System.Drawing.Point(148, 79);
            this.txbLink.Name = "txbLink";
            this.txbLink.Size = new System.Drawing.Size(266, 20);
            this.txbLink.TabIndex = 1;
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(420, 77);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(75, 23);
            this.btnCheck.TabIndex = 2;
            this.btnCheck.Text = "Check";
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // cmbSub
            // 
            this.cmbSub.FormattingEnabled = true;
            this.cmbSub.ItemHeight = 23;
            this.cmbSub.Location = new System.Drawing.Point(148, 113);
            this.cmbSub.Name = "cmbSub";
            this.cmbSub.Size = new System.Drawing.Size(266, 29);
            this.cmbSub.TabIndex = 3;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.Location = new System.Drawing.Point(23, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(116, 25);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Chọn phụ đề:";
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(220, 203);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "Tải về";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.Location = new System.Drawing.Point(23, 158);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(109, 25);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Dịch phụ đề:";
            // 
            // cmbTrans
            // 
            this.cmbTrans.FormattingEnabled = true;
            this.cmbTrans.ItemHeight = 23;
            this.cmbTrans.Items.AddRange(new object[] {
            "Không dịch",
            "Tiếng Việt",
            "Tiếng Anh",
            "Tiếng Nhật",
            "Tiếng Pháp",
            "Tiếng Đức",
            "Tiếng Hàn",
            "Tiếng Nga",
            "Tiếng TBN"});
            this.cmbTrans.Location = new System.Drawing.Point(148, 157);
            this.cmbTrans.Name = "cmbTrans";
            this.cmbTrans.Size = new System.Drawing.Size(266, 29);
            this.cmbTrans.TabIndex = 6;
            // 
            // labelProcess
            // 
            this.labelProcess.AutoSize = true;
            this.labelProcess.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.labelProcess.Location = new System.Drawing.Point(157, 239);
            this.labelProcess.Name = "labelProcess";
            this.labelProcess.Size = new System.Drawing.Size(0, 0);
            this.labelProcess.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 269);
            this.Controls.Add(this.labelProcess);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.cmbTrans);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.cmbSub);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txbLink);
            this.Controls.Add(this.metroLabel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "LMT Youtube Subtitles Downloader 1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.TextBox txbLink;
        private MetroFramework.Controls.MetroButton btnCheck;
        private MetroFramework.Controls.MetroComboBox cmbSub;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnDownload;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroComboBox cmbTrans;
        private MetroFramework.Controls.MetroLabel labelProcess;
    }
}

