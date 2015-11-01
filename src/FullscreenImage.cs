using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NastyFans
{
    public partial class FullscreenImage : Form
    {
        string image_url { get; set; }
        string image_name { get; set; }
        public FullscreenImage(string url,string name)
        {
            image_url = url;
            image_name = name;
            InitializeComponent();
        }

        private void FullscreenImage_Load(object sender, EventArgs e)
        {
            this.Text = "Viewing: " + image_name;
            pictureBox1.ImageLocation = image_url;
        }
    }
}
