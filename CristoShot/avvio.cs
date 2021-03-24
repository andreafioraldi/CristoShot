using System;
using System.IO;
using System.Media;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CristoShot
{
    public partial class avvio : Form
    {
        static int vol;

        public avvio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        private void avvio_Load(object sender, EventArgs e)
        {
 
            player.Stream = Properties.Resources.gesu3;
            player.Play();
            
            if (!File.Exists("list.list"))
            {
                FileStream fs = File.Create("list.list");
                fs.Close();
            }
                
            string line;
            StreamReader file = new StreamReader("list.list");
            while ((line = file.ReadLine()) != null)
            {
                listBox1.Items.Add(line);
            }

            file.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            player.Stop();
            this.Controls.Clear();
            gioco fm = new gioco();
            fm.Location = new Point(0, 0);
            fm.Size = panel2.Size;
            fm.Parent = this;
            
            fm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            FileStream fs = new FileStream("list.list", FileMode.Truncate);
            fs.Close();
        }
    }
}
