using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tp3
{
    public partial class Reference : Form
    {
        public Reference()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://vk.com/ishim59") { UseShellExecute = true });

        }
    }
}
