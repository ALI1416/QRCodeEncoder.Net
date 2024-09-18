using System.Windows.Forms;
using System.Drawing;

namespace Z.QRCodeEncoder.Net.UI
{

    /// <summary>
    /// 主界面
    /// </summary>
    public partial class Main : Form
    {

        /// <summary>
        /// 主程序
        /// </summary>
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
        private void GenerateBtn_Click(object sender, System.EventArgs e)
        {
            int level = levelComboBox.SelectedIndex;
            int mode = modeComboBox.SelectedIndex;
            int versionNumber = versionNumberComboBox.SelectedIndex;
            string content = contentText.Text;
            QRCode qrCode = new QRCode(content, level == 0 ? null : (int?)level, mode == 0 ? null : (int?)mode, versionNumber == 0 ? null : (int?)versionNumber);
            Bitmap bitmap = ImageUtils.QrMatrix2Bitmap(qrCode.Matrix, 10);
            previewLabel.Visible = false;
            if (previewImg.Image != null)
            {
                previewImg.Image.Dispose();
                previewImg.Image = null;
            }
            previewImg.Image = bitmap;
        }

    }
}
