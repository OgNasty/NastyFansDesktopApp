using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Codeplex.Data;
using Microsoft.CSharp;
using System.Reflection;

namespace NastyFans
{
    public partial class Form1 : Form
    {
        string exchange { get; set; }
        string ghs_mining { get; set; }
        double donations { get; set; }
        string seatsale { get; set; }
        string ghs_pool { get; set; }
        string miners { get; set; }
        public Form1()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;
        }
        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var dllName = new AssemblyName(args.Name).Name + ".dll";
            var execAsm = Assembly.GetExecutingAssembly();
            var resourceName = execAsm.GetManifestResourceNames().FirstOrDefault(s => s.EndsWith(dllName));
            if (resourceName == null) return null;
            using (var stream = execAsm.GetManifestResourceStream(resourceName))
            {
                var assbebmlyBytes = new byte[stream.Length];
                stream.Read(assbebmlyBytes, 0, assbebmlyBytes.Length);
                return Assembly.Load(assbebmlyBytes);
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            this.BackColor = Color.FromArgb(44, 62, 80);
            panel1.BackColor = Color.FromArgb(46, 204, 113);
            panel2.BackColor = Color.FromArgb(46, 204, 113);
            panel6.BackColor = Color.FromArgb(46, 204, 113);
            panel7.BackColor = Color.FromArgb(46, 204, 113);
            panel8.BackColor = Color.FromArgb(46, 204, 113);
            panel9.BackColor = Color.FromArgb(46, 204, 113);
            panel10.BackColor = Color.FromArgb(46, 204, 113);
            panel11.BackColor = Color.FromArgb(46, 204, 113);
            label1.BackColor = Color.FromArgb(39, 174, 96);
            label4.BackColor = Color.FromArgb(39, 174, 96);
            label5.BackColor = Color.FromArgb(39, 174, 96);
            label6.BackColor = Color.FromArgb(39, 174, 96);
            label7.BackColor = Color.FromArgb(39, 174, 96);
            label17.BackColor = Color.FromArgb(39, 174, 96);
            label20.BackColor = Color.FromArgb(39, 174, 96);
            button1.BackColor = Color.FromArgb(39, 174, 96);
            button4.BackColor = Color.FromArgb(39, 174, 96);
            button2.BackColor = Color.FromArgb(39, 174, 96);
            button3.BackColor = Color.FromArgb(39, 174, 96);
            button6.BackColor = Color.FromArgb(39, 174, 96);
            panel3.BackColor = Color.FromArgb(39, 174, 96);
            pictureBox1.ImageLocation = "http://langrock.org/stats/bitstamp.png";
            pictureBox2.ImageLocation = "http://langrock.org/stats/nasty_chart.png";
            reload(true);
        }

        private void reload(bool initial)
        {
            var wc = new System.Net.WebClient();
            string json_response_nasty = wc.DownloadString("https://nastyfans.org/nasty.json");
            var json = DynamicJson.Parse(@json_response_nasty);
            exchange = json.exchangerates.lastblockchainsale.ToString();
            ghs_mining = json.nastymining.hashrateghs.ToString();
            donations = json.nastyfans.donationsreceived;
            donations = Math.Round(donations,3);
            seatsale = json.nastyfans.lastseatsale.ToString();
            ghs_pool = json.nastypool.hashrateghs.ToString();
            miners = json.nastypool.activeminers.ToString();
            label3.Text = "1 BTC = " + exchange + "$";
            label8.Text = ghs_mining + " GH/s";
            label9.Text = donations + " BTC Donated";
            label10.Text = "Seat Price: " + seatsale + " BTC";
            label11.Text = ghs_pool + " GH/s";
            label12.Text = miners + " Active Miners";
            if(!initial) { MessageBox.Show("Reload Complete", "NastyFans", MessageBoxButtons.OK); }
        }

        const int HTCAPTION = 0x2;
        const int WM_NCLBUTTONDOWN = 0xA1;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(231, 76, 60);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(9, 144, 70);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(9, 144, 70);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(39, 174, 96);
        }
        private void button6_MouseEnter(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(9, 144, 70);
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            button6.BackColor = Color.FromArgb(39, 174, 96);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (!panel2.Visible)
            {
                panel2.Visible = true;
                panel2.BringToFront();
            } else
            {
                panel2.Visible = false;
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if(panel2.Visible) { panel2.Visible = false; }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            reload(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            About about = new About();
            about.ShowDialog();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FullscreenImage image = new FullscreenImage(pictureBox1.ImageLocation, "Bitstamp USD Chart");
            image.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FullscreenImage image = new FullscreenImage(pictureBox2.ImageLocation, "NastyFans Seat / Bitcoin Chart");
            image.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            Policy policy = new Policy();
            policy.ShowDialog();
        }
    }
}
