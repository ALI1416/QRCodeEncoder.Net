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
            this.components = new System.ComponentModel.Container();
            this.previewImg = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.titleLabel = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.modeLabel = new System.Windows.Forms.Label();
            this.versionNumberLabel = new System.Windows.Forms.Label();
            this.levelComboBox = new System.Windows.Forms.ComboBox();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.versionNumberComboBox = new System.Windows.Forms.ComboBox();
            this.contentText = new System.Windows.Forms.TextBox();
            this.contentLabel = new System.Windows.Forms.Label();
            this.generateBtn = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.levelShowLabel = new System.Windows.Forms.Label();
            this.modeShowLabel = new System.Windows.Forms.Label();
            this.versionNumberShowLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // previewImg
            // 
            this.previewImg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.previewImg.Dock = System.Windows.Forms.DockStyle.Right;
            this.previewImg.Location = new System.Drawing.Point(300, 0);
            this.previewImg.Name = "previewImg";
            this.previewImg.Size = new System.Drawing.Size(400, 400);
            this.previewImg.TabIndex = 0;
            this.previewImg.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.versionNumberShowLabel);
            this.panel1.Controls.Add(this.modeShowLabel);
            this.panel1.Controls.Add(this.levelShowLabel);
            this.panel1.Controls.Add(this.generateBtn);
            this.panel1.Controls.Add(this.contentLabel);
            this.panel1.Controls.Add(this.contentText);
            this.panel1.Controls.Add(this.versionNumberComboBox);
            this.panel1.Controls.Add(this.modeComboBox);
            this.panel1.Controls.Add(this.levelComboBox);
            this.panel1.Controls.Add(this.versionNumberLabel);
            this.panel1.Controls.Add(this.modeLabel);
            this.panel1.Controls.Add(this.levelLabel);
            this.panel1.Controls.Add(this.titleLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 400);
            this.panel1.TabIndex = 1;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.titleLabel.Location = new System.Drawing.Point(69, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(180, 27);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "二维码生成器";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Location = new System.Drawing.Point(10, 54);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(65, 12);
            this.levelLabel.TabIndex = 1;
            this.levelLabel.Text = "纠错等级：";
            // 
            // modeLabel
            // 
            this.modeLabel.AutoSize = true;
            this.modeLabel.Location = new System.Drawing.Point(10, 84);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(65, 12);
            this.modeLabel.TabIndex = 2;
            this.modeLabel.Text = "编码模式：";
            // 
            // versionNumberLabel
            // 
            this.versionNumberLabel.AutoSize = true;
            this.versionNumberLabel.Location = new System.Drawing.Point(10, 114);
            this.versionNumberLabel.Name = "versionNumberLabel";
            this.versionNumberLabel.Size = new System.Drawing.Size(53, 12);
            this.versionNumberLabel.TabIndex = 3;
            this.versionNumberLabel.Text = "版本号：";
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
            this.levelComboBox.Size = new System.Drawing.Size(120, 20);
            this.levelComboBox.TabIndex = 4;
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
            this.modeComboBox.Size = new System.Drawing.Size(120, 20);
            this.modeComboBox.TabIndex = 5;
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
            this.versionNumberComboBox.Size = new System.Drawing.Size(120, 20);
            this.versionNumberComboBox.TabIndex = 6;
            // 
            // contentText
            // 
            this.contentText.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.contentText.Location = new System.Drawing.Point(10, 170);
            this.contentText.Multiline = true;
            this.contentText.Name = "contentText";
            this.contentText.Size = new System.Drawing.Size(280, 170);
            this.contentText.TabIndex = 7;
            // 
            // contentLabel
            // 
            this.contentLabel.AutoSize = true;
            this.contentLabel.Location = new System.Drawing.Point(10, 144);
            this.contentLabel.Name = "contentLabel";
            this.contentLabel.Size = new System.Drawing.Size(41, 12);
            this.contentLabel.TabIndex = 8;
            this.contentLabel.Text = "内容：";
            // 
            // generateBtn
            // 
            this.generateBtn.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Bold);
            this.generateBtn.Location = new System.Drawing.Point(74, 350);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(120, 40);
            this.generateBtn.TabIndex = 9;
            this.generateBtn.Text = "生成";
            this.generateBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "请点击生成按钮";
            // 
            // levelShowLabel
            // 
            this.levelShowLabel.AutoSize = true;
            this.levelShowLabel.Location = new System.Drawing.Point(200, 54);
            this.levelShowLabel.Name = "levelShowLabel";
            this.levelShowLabel.Size = new System.Drawing.Size(41, 12);
            this.levelShowLabel.TabIndex = 10;
            this.levelShowLabel.Text = "label7";
            // 
            // modeShowLabel
            // 
            this.modeShowLabel.AutoSize = true;
            this.modeShowLabel.Location = new System.Drawing.Point(200, 84);
            this.modeShowLabel.Name = "modeShowLabel";
            this.modeShowLabel.Size = new System.Drawing.Size(41, 12);
            this.modeShowLabel.TabIndex = 11;
            this.modeShowLabel.Text = "label8";
            // 
            // versionNumberShowLabel
            // 
            this.versionNumberShowLabel.AutoSize = true;
            this.versionNumberShowLabel.Location = new System.Drawing.Point(200, 114);
            this.versionNumberShowLabel.Name = "versionNumberShowLabel";
            this.versionNumberShowLabel.Size = new System.Drawing.Size(41, 12);
            this.versionNumberShowLabel.TabIndex = 12;
            this.versionNumberShowLabel.Text = "label9";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.previewImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "二维码生成器";
            ((System.ComponentModel.ISupportInitialize)(this.previewImg)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox previewImg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Label contentLabel;
        private System.Windows.Forms.TextBox contentText;
        private System.Windows.Forms.ComboBox versionNumberComboBox;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.ComboBox levelComboBox;
        private System.Windows.Forms.Label versionNumberLabel;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label levelLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label modeShowLabel;
        private System.Windows.Forms.Label levelShowLabel;
        private System.Windows.Forms.Label versionNumberShowLabel;
    }
}
