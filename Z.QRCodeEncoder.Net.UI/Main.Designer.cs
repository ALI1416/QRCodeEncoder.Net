namespace Z.QRCodeEncoder.Net.UI
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.leftPanel = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.levelLabel = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.modeLabel = new System.Windows.Forms.Label();
            this.versionNumberComboBox = new System.Windows.Forms.ComboBox();
            this.versionNumberLabel = new System.Windows.Forms.Label();
            this.contentText = new System.Windows.Forms.TextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.previewLabel = new System.Windows.Forms.Label();
            this.previewImg = new System.Windows.Forms.PictureBox();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).BeginInit();
            this.SuspendLayout();
            // 
            // leftPanel
            // 
            this.leftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.leftPanel.Controls.Add(this.titleLabel);
            this.leftPanel.Controls.Add(this.levelComboBox);
            this.leftPanel.Controls.Add(this.levelLabel);
            this.leftPanel.Controls.Add(this.modeComboBox);
            this.leftPanel.Controls.Add(this.modeLabel);
            this.leftPanel.Controls.Add(this.versionNumberComboBox);
            this.leftPanel.Controls.Add(this.versionNumberLabel);
            this.leftPanel.Controls.Add(this.contentText);
            this.leftPanel.Controls.Add(this.contentLabel);
            this.leftPanel.Controls.Add(this.generateBtn);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(300, 400);
            this.leftPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(65, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(180, 27);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "二维码生成器";
            // 
            // levelComboBox
            // 
            this.levelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.levelComboBox.FormattingEnabled = true;
            this.levelComboBox.Items.AddRange(new object[] {
            "L(7%)",
            "M(10%)",
            "Q(25%)",
            "H(30%)"});
            this.levelComboBox.Location = new System.Drawing.Point(70, 50);
            this.levelComboBox.Name = "levelComboBox";
            this.levelComboBox.Size = new System.Drawing.Size(220, 20);
            this.levelComboBox.TabIndex = 3;
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(10, 54);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(65, 12);
            this.levelLabel.TabIndex = 0;
            this.levelLabel.Text = "纠错等级：";
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Items.AddRange(new object[] {
            "(自动探测)",
            "NUMERIC",
            "ALPHANUMERIC",
            "BYTE(ISO-8859-1)",
            "BYTE(UTF-8)"});
            this.modeComboBox.Location = new System.Drawing.Point(70, 80);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(220, 20);
            this.modeComboBox.TabIndex = 4;
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(10, 84);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(65, 12);
            this.modeLabel.TabIndex = 0;
            this.modeLabel.Text = "编码模式：";
            // 
            // versionNumberComboBox
            // 
            this.versionNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionNumberComboBox.FormattingEnabled = true;
            this.versionNumberComboBox.Items.AddRange(new object[] {
            "(最小版本)",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40"});
            this.versionNumberComboBox.Location = new System.Drawing.Point(70, 110);
            this.versionNumberComboBox.Name = "versionNumberComboBox";
            this.versionNumberComboBox.Size = new System.Drawing.Size(220, 20);
            this.versionNumberComboBox.TabIndex = 5;
            // 
            // versionNumberLabel
            // 
            this.versionNumberLabel.AutoSize = true;
            this.versionNumberLabel.Location = new System.Drawing.Point(10, 114);
            this.versionNumberLabel.Name = "versionNumberLabel";
            this.versionNumberLabel.Size = new System.Drawing.Size(53, 12);
            this.versionNumberLabel.TabIndex = 0;
            this.versionNumberLabel.Text = "版本号：";
            // 
            // contentText
            // 
            this.contentText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contentText.Location = new System.Drawing.Point(10, 170);
            this.contentText.Multiline = true;
            this.contentText.Name = "contentText";
            this.contentText.Size = new System.Drawing.Size(280, 170);
            this.contentText.TabIndex = 1;
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(10, 144);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(41, 12);
            this.contentLabel.TabIndex = 0;
            this.contentLabel.Text = "内容：";
            // 
            // generateBtn
            // 
            this.generateBtn.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.generateBtn.Location = new System.Drawing.Point(80, 350);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(120, 40);
            this.generateBtn.TabIndex = 2;
            this.generateBtn.Text = "生成";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.GenerateBtn_Click);
            // 
            // rightPanel
            // 
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightPanel.Controls.Add(this.previewLabel);
            this.rightPanel.Controls.Add(this.previewImg);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(300, 0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(400, 400);
            this.rightPanel.TabIndex = 0;
            // 
            // previewLabel
            // 
            this.previewLabel.AutoSize = true;
            this.previewLabel.Location = new System.Drawing.Point(160, 200);
            this.previewLabel.Name = "previewLabel";
            this.previewLabel.Size = new System.Drawing.Size(89, 12);
            this.previewLabel.TabIndex = 0;
            this.previewLabel.Text = "请点击生成按钮";
            // 
            // previewImg
            // 
            this.previewImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewImg.Location = new System.Drawing.Point(0, 0);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(398, 398);
            this.previewImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.previewImg.TabIndex = 0;
            this.previewImg.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.leftPanel);
            this.MinimumSize = new System.Drawing.Size(716, 439);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二维码生成器";
            this.leftPanel.ResumeLayout(false);
            this.leftPanel.PerformLayout();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        /* 左侧 */
        /// <summary>
        /// 左侧Panel
        /// </summary>
        private System.Windows.Forms.Panel leftPanel;
        /// <summary>
        /// 二维码生成器Label
        /// </summary>
        private System.Windows.Forms.Label titleLabel;
        /// <summary>
        /// 纠错等级Label
        /// </summary>
        private System.Windows.Forms.Label levelLabel;
        /// <summary>
        /// 纠错等级ComboBox
        /// </summary>
        private System.Windows.Forms.ComboBox levelComboBox;
        /// <summary>
        /// 编码模式Label
        /// </summary>
        private System.Windows.Forms.Label modeLabel;
        /// <summary>
        /// 编码模式ComboBox
        /// </summary>
        private System.Windows.Forms.ComboBox modeComboBox;
        /// <summary>
        /// 版本号Label
        /// </summary>
        private System.Windows.Forms.Label versionNumberLabel;
        /// <summary>
        /// 版本号ComboBox
        /// </summary>
        private System.Windows.Forms.ComboBox versionNumberComboBox;
        /// <summary>
        /// 内容Label
        /// </summary>
        private System.Windows.Forms.Label contentLabel;
        /// <summary>
        /// 内容TextBox
        /// </summary>
        private System.Windows.Forms.TextBox contentText;
        /// <summary>
        /// 生成Button
        /// </summary>
        private System.Windows.Forms.Button generateBtn;

        /* 右侧 */
        /// <summary>
        /// 右侧Panel
        /// </summary>
        private System.Windows.Forms.Panel rightPanel;
        /// <summary>
        /// 预览Label
        /// </summary>
        private System.Windows.Forms.Label previewLabel;
        /// <summary>
        /// 预览图像PictureBox
        /// </summary>
        private System.Windows.Forms.PictureBox previewImg;

    }
}
