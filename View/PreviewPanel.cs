using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace StableManager.View
{
    using Beans;

    public partial class PreviewPanel : Form
    {
        PrePayload settings = PrePayload.Instance;
        string dirPath = @"C:\sd.webui\webui\outputs\img2img-images";
        string imageNameTmp = "";
        public PreviewPanel()
        {
            InitializeComponent();
        }
        private void ShowImage()
        {
            if (!settings.IsActiveRoop) return;
            settings.IsActiveRoop = false;
            if (settings.IsI2Imode)
            {
                dirPath = @"C:\sd.webui\webui\outputs\img2img-images";
            }
            else
            {
                dirPath = @"C:\sd.webui\webui\outputs\txt2img-images";
            }
            var files = Directory.GetFiles(dirPath, "*.png")
            .Select(filePath => new FileInfo(filePath))
            .OrderByDescending(fileInfo => fileInfo.CreationTime)
            .FirstOrDefault();

            if (files == null || imageNameTmp == files.FullName) return;
            if (imageNameTmp != files.FullName) imageNameTmp = files.FullName;
            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            File.Copy(imageNameTmp, "tmp.png", true);
            pictureBox1.Image = Image.FromFile("tmp.png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ShowImage();
        }
    }
}
