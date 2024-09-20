namespace Z.QRCodeEncoder.Net.UI.Net8
{

    /// <summary>
    /// 主界面
    /// </summary>
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Init();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            levelComboBox.SelectedIndex = 0;
            modeComboBox.SelectedIndex = 0;
            versionNumberComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// 点击生成按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            int level = levelComboBox.SelectedIndex;
            int mode = modeComboBox.SelectedIndex;
            int versionNumber = versionNumberComboBox.SelectedIndex;
            string content = contentText.Text;
            QRCode qrCode;
            try
            {
                qrCode = new QRCode(content, level, mode == 0 ? null : (int?)mode - 1, versionNumber == 0 ? null : (int?)versionNumber);
            }
            catch (QRCodeException e1)
            {
                MessageBox.Show(e1.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            previewLabel.Visible = false;
            Bitmap bitmap = ImageUtils.QrMatrix2Bitmap(qrCode.Matrix, 20);
            if (previewImg.Image != null)
            {
                previewImg.Image.Dispose();
                previewImg.Image = null;
            }
            previewImg.Image = bitmap;
            if (mode == 0)
            {
                modeComboBox.Items[0] = "(自动探测) " + modeComboBox.Items[qrCode.Mode + 1];
            }
            if (versionNumber == 0)
            {
                versionNumberComboBox.Items[0] = "(最小版本) " + qrCode.VersionNumber;
            }
        }

    }
}
