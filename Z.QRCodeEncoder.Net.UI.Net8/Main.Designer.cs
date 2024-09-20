namespace Z.QRCodeEncoder.Net.UI.Net8
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            leftPanel = new Panel();
            titleLabel = new Label();
            levelComboBox = new ComboBox();
            levelLabel = new Label();
            modeComboBox = new ComboBox();
            modeLabel = new Label();
            versionNumberComboBox = new ComboBox();
            versionNumberLabel = new Label();
            contentText = new TextBox();
            contentLabel = new Label();
            generateBtn = new Button();
            rightPanel = new Panel();
            previewLabel = new Label();
            previewImg = new PictureBox();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)previewImg).BeginInit();
            SuspendLayout();
            // 
            // leftPanel
            // 
            leftPanel.BorderStyle = BorderStyle.FixedSingle;
            leftPanel.Controls.Add(titleLabel);
            leftPanel.Controls.Add(levelComboBox);
            leftPanel.Controls.Add(levelLabel);
            leftPanel.Controls.Add(modeComboBox);
            leftPanel.Controls.Add(modeLabel);
            leftPanel.Controls.Add(versionNumberComboBox);
            leftPanel.Controls.Add(versionNumberLabel);
            leftPanel.Controls.Add(contentText);
            leftPanel.Controls.Add(contentLabel);
            leftPanel.Controls.Add(generateBtn);
            leftPanel.Dock = DockStyle.Left;
            leftPanel.Location = new Point(0, 0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new Size(300, 400);
            leftPanel.TabIndex = 1;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Microsoft YaHei UI", 20F);
            titleLabel.Location = new Point(65, 10);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(177, 35);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "二维码生成器";
            // 
            // levelComboBox
            // 
            levelComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            levelComboBox.FormattingEnabled = true;
            levelComboBox.Items.AddRange(new object[] { "L(7%)", "M(10%)", "Q(25%)", "H(30%)" });
            levelComboBox.Location = new Point(70, 50);
            levelComboBox.Name = "levelComboBox";
            levelComboBox.Size = new Size(220, 25);
            levelComboBox.TabIndex = 3;
            // 
            // levelLabel
            // 
            levelLabel.AutoSize = true;
            levelLabel.Location = new Point(10, 54);
            levelLabel.Name = "levelLabel";
            levelLabel.Size = new Size(68, 17);
            levelLabel.TabIndex = 0;
            levelLabel.Text = "纠错等级：";
            // 
            // modeComboBox
            // 
            modeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modeComboBox.FormattingEnabled = true;
            modeComboBox.Items.AddRange(new object[] { "(自动探测)", "NUMERIC", "ALPHANUMERIC", "BYTE(ISO-8859-1)", "BYTE(UTF-8)" });
            modeComboBox.Location = new Point(70, 80);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new Size(220, 25);
            modeComboBox.TabIndex = 3;
            // 
            // modeLabel
            // 
            modeLabel.AutoSize = true;
            modeLabel.Location = new Point(10, 84);
            modeLabel.Name = "modeLabel";
            modeLabel.Size = new Size(68, 17);
            modeLabel.TabIndex = 0;
            modeLabel.Text = "编码模式：";
            // 
            // versionNumberComboBox
            // 
            versionNumberComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            versionNumberComboBox.FormattingEnabled = true;
            versionNumberComboBox.Items.AddRange(new object[] { "(最小版本)", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40" });
            versionNumberComboBox.Location = new Point(70, 110);
            versionNumberComboBox.Name = "versionNumberComboBox";
            versionNumberComboBox.Size = new Size(220, 25);
            versionNumberComboBox.TabIndex = 5;
            // 
            // versionNumberLabel
            // 
            versionNumberLabel.AutoSize = true;
            versionNumberLabel.Location = new Point(10, 114);
            versionNumberLabel.Name = "versionNumberLabel";
            versionNumberLabel.Size = new Size(56, 17);
            versionNumberLabel.TabIndex = 0;
            versionNumberLabel.Text = "版本号：";
            // 
            // contentText
            // 
            contentText.Font = new Font("Microsoft YaHei UI", 12F);
            contentText.Location = new Point(10, 170);
            contentText.Multiline = true;
            contentText.Name = "contentText";
            contentText.Size = new Size(280, 170);
            contentText.TabIndex = 1;
            // 
            // contentLabel
            // 
            contentLabel.AutoSize = true;
            contentLabel.Location = new Point(10, 144);
            contentLabel.Name = "contentLabel";
            contentLabel.Size = new Size(44, 17);
            contentLabel.TabIndex = 0;
            contentLabel.Text = "内容：";
            // 
            // generateBtn
            // 
            generateBtn.Font = new Font("Microsoft YaHei UI", 18F);
            generateBtn.Location = new Point(80, 350);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(120, 40);
            generateBtn.TabIndex = 2;
            generateBtn.Text = "生成";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += GenerateBtn_Click;
            // 
            // rightPanel
            // 
            rightPanel.BorderStyle = BorderStyle.FixedSingle;
            rightPanel.Controls.Add(previewLabel);
            rightPanel.Controls.Add(previewImg);
            rightPanel.Dock = DockStyle.Fill;
            rightPanel.Location = new Point(300, 0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new Size(400, 400);
            rightPanel.TabIndex = 0;
            // 
            // previewLabel
            // 
            previewLabel.AutoSize = true;
            previewLabel.Location = new Point(160, 200);
            previewLabel.Name = "previewLabel";
            previewLabel.Size = new Size(92, 17);
            previewLabel.TabIndex = 0;
            previewLabel.Text = "请点击生成按钮";
            // 
            // previewImg
            // 
            previewImg.Dock = DockStyle.Fill;
            previewImg.Location = new Point(0, 0);
            previewImg.Name = "previewImg";
            previewImg.Size = new Size(398, 398);
            previewImg.SizeMode = PictureBoxSizeMode.Zoom;
            previewImg.TabIndex = 0;
            previewImg.TabStop = false;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 400);
            Controls.Add(rightPanel);
            Controls.Add(leftPanel);
            MinimumSize = new Size(716, 439);
            Name = "Main";
            StartPosition = FormStartPosition.CenterParent;
            Text = "二维码生成器";
            leftPanel.ResumeLayout(false);
            leftPanel.PerformLayout();
            rightPanel.ResumeLayout(false);
            rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)previewImg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        /* 左侧 */
        /// <summary>
        /// 左侧Panel
        /// </summary>
        private Panel leftPanel;
        /// <summary>
        /// 二维码生成器Label
        /// </summary>
        private Label titleLabel;
        /// <summary>
        /// 纠错等级Label
        /// </summary>
        private Label levelLabel;
        /// <summary>
        /// 纠错等级ComboBox
        /// </summary>
        private ComboBox levelComboBox;
        /// <summary>
        /// 编码模式Label
        /// </summary>
        private Label modeLabel;
        /// <summary>
        /// 编码模式ComboBox
        /// </summary>
        private ComboBox modeComboBox;
        /// <summary>
        /// 版本号Label
        /// </summary>
        private Label versionNumberLabel;
        /// <summary>
        /// 版本号ComboBox
        /// </summary>
        private ComboBox versionNumberComboBox;
        /// <summary>
        /// 内容Label
        /// </summary>
        private Label contentLabel;
        /// <summary>
        /// 内容TextBox
        /// </summary>
        private TextBox contentText;
        /// <summary>
        /// 生成Button
        /// </summary>
        private Button generateBtn;

        /* 右侧 */
        /// <summary>
        /// 右侧Panel
        /// </summary>
        private Panel rightPanel;
        /// <summary>
        /// 预览Label
        /// </summary>
        private Label previewLabel;
        /// <summary>
        /// 预览图像PictureBox
        /// </summary>
        private PictureBox previewImg;

    }
}
