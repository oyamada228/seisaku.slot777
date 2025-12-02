using System;
using System.Drawing;
using System.Windows.Forms;

namespace slot777
{
    public partial class Form1 : Form
    {

        Image[] slotImages;




        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            slotImages = new Image[]
            {
                Properties.Resources.slot1

            }
            ;




        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


        Random rand = new Random();



        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox3.Image = slotImages[rand.Next(slotImages.Length)];
        }


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"C:\path\to\your\image.jpg");
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"C:\path\to\your\image.jpg");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }
    }

}

