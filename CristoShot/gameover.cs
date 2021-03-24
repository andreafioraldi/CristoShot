using System;
using System.IO;
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
    public partial class gameover : Form
    {
        public gameover()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText("list.list",
                   "nome:  " + textBox1.Text + "  " + label3.Text + "  " + label4.Text + Environment.NewLine);
            Application.Exit();
        }

        private void gameover_Load(object sender, EventArgs e)
        {

        }
    }
}
