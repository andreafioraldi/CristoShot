using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CristoShot
{
    public partial class gioco : UserControl
    {
        public gioco()
        {
            InitializeComponent();
        }

        Random r1 = new Random(DateTime.Now.Millisecond);
        Random r2 = new Random(DateTime.Now.Millisecond);

        private void gioco_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (label2.Text == "0")
            {
                gameover gf = new gameover();
                gf.label3.Text = "tempo:  " + label6.Text;
                gf.label4.Text = "punti:  " + label1.Text;
                gf.Show();
                this.Hide();
            }
            label2.Text = (int.Parse(label2.Text) - 1).ToString();
            PictureBox pb = new PictureBox();
            pb.Parent = this;
            pb.Width = 60;
            pb.Height = 60;
            pb.Location = new Point(pictureBox2.Left, pictureBox2.Top - pb.Height);
            if (radioButton1.Checked)
            {
                pb.BackgroundImage = CristoShot.Properties.Resources.lancia;
            }
            else if (radioButton2.Checked)
            {
                pb.BackgroundImage = CristoShot.Properties.Resources.corona;
            }
            else if (radioButton3.Checked)
            {
                pb.BackgroundImage = CristoShot.Properties.Resources.bibbia;
            }
            pbl.Add(pb);
            pb.Show();
            Timer t = new Timer();
            t.Tag = pb;
            t.Interval = 10;
            t.Tick += new System.EventHandler(this.timers_Tick);
            t.Start();
        }

        private void timers_Tick(object sender, EventArgs e)
        {
            if (((PictureBox)((Timer)sender).Tag).Top - pictureBox1.Height <= 0 &&
                ((PictureBox)((Timer)sender).Tag).Top - pictureBox1.Height >= -8)
            {
                if (((PictureBox)((Timer)sender).Tag).Left >= pictureBox1.Left &&
                    ((PictureBox)((Timer)sender).Tag).Right >= pictureBox1.Right)
                {
                    if (radioButton1.Checked)
                    {
                        label1.Text = (int.Parse(label1.Text) + 1).ToString();
                        label2.Text = (int.Parse(label2.Text) + 1).ToString();
                        if (label1.Text == "10")
                        {
                            radioButton2.Show();
                            radioButton2.Checked = true;
                        }
                        else if (label1.Text == "20")
                        {
                            radioButton3.Show();
                            radioButton3.Checked = true;
                        }
                    }
                    else if (radioButton2.Checked)
                    {
                        label1.Text = (int.Parse(label1.Text) + 2).ToString();
                        label2.Text = (int.Parse(label2.Text) + 1).ToString();
                        if (label1.Text == "20")
                        {
                            radioButton3.Show();
                            radioButton3.Checked = true;
                        }
                    }
                    else if (radioButton3.Checked)
                    {
                        label1.Text = (int.Parse(label1.Text) + 5).ToString();
                        label2.Text = (int.Parse(label2.Text) + 1).ToString();
                    }
                    Talk();

                    ((Timer)sender).Stop();
                    ((PictureBox)((Timer)sender).Tag).Dispose();
                    pbl.Remove(((PictureBox)((Timer)sender).Tag));
                    return;
                }
                else if (((PictureBox)((Timer)sender).Tag).Top <= 0)
                {
                    ((Timer)sender).Stop();
                    ((PictureBox)((Timer)sender).Tag).Dispose();
                    pbl.Remove(((PictureBox)((Timer)sender).Tag));
                    return;
                }
            }
            if (radioButton1.Checked)
                ((PictureBox)((Timer)sender).Tag).Top -= 12;
            else if (radioButton2.Checked)
                ((PictureBox)((Timer)sender).Tag).Top -= 7;
            else if (radioButton3.Checked)
                ((PictureBox)((Timer)sender).Tag).Top -= 3;

        }

        System.Media.SoundPlayer player = new System.Media.SoundPlayer();

        void Talk()
        {
            int o = r2.Next(0, 7);
            if (o == 0)
                player.Stream = Properties.Resources.ahhhh;
            else if (o == 1)
                player.Stream = Properties.Resources.ahioo;
            else if (o == 2)
                player.Stream = Properties.Resources.diocan;
            else if (o == 3)
                player.Stream = Properties.Resources.fdputtana;
            else if (o == 4)
                player.Stream = Properties.Resources.marò;
            else if (o == 5)
                player.Stream = Properties.Resources.zoccola;
            else
                player.Stream = Properties.Resources.porcodio;
            player.Play();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Width - pictureBox1.Left + r1.Next(0, 1000) < 8)
            {
                pictureBox1.Left = 0;
                return;
            }
            pictureBox1.Left += r1.Next(1, 16);
        }

        List<PictureBox> pbl = new List<PictureBox>();

        private void timer2_Tick(object sender, EventArgs e)
        {
            label6.Text = (int.Parse(label6.Text) + 1).ToString();
        }



    }
}
