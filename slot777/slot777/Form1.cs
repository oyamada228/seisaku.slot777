using System;
using System.Drawing;
using System.Windows.Forms;

namespace slot777
{
    public partial class Form1 : Form
    {

        Image[] slotImages;  //絵柄の箱

        Random rand = new Random();　　//ランダム化
        int tickCount = 0;
        int stop1 = 0, stop2 = 0, stop3 = 0;   //停止ボタン

        bool stopFlag1 = false;
        bool stopFlag2 = false;
        bool stopFlag3 = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //絵柄をリソースに追加
        {
            slotImages = new Image[]
            {
                Properties.Resources.BAR,
                Properties.Resources.Beru,
                Properties.Resources._7,
                Properties.Resources.Budou,
                Properties.Resources.hurt,

            }
            ;
        }



        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!stopFlag1)
            pictureBox1.Image = slotImages[rand.Next(slotImages.Length)];

            if (!stopFlag2)
                pictureBox2.Image = slotImages[rand.Next(slotImages.Length)];

            if (!stopFlag3)
                pictureBox3.Image = slotImages[rand.Next(slotImages.Length)];

            if (stopFlag1 && stopFlag2 && stopFlag3)
            {
                timer1.Stop();
                CheckResult();
            }

        }
         

        private void button1_Click(object sender, EventArgs e) //ボタン1の止める処理
        {
            stopFlag1 = true;
        }


        private void button2_Click(object sender, EventArgs e)  //ボタン2
        {
            stopFlag2 = true;
        }

        private void button3_Click(object sender, EventArgs e)  //ボタン3
        {
            stopFlag3 = true;
        } 
            
        private void timer1_Tck(object sender, EventArgs e)
        {
           tickCount++;

            if(tickCount <= stop1)
            pictureBox1.Image = slotImages[rand.Next(slotImages.Length)];

            if (tickCount <= stop2)
                pictureBox2.Image = slotImages[rand.Next(slotImages.Length)];

            if (tickCount <= stop3)
                pictureBox3.Image = slotImages[rand.Next(slotImages.Length)];

             if(tickCount > stop3)
             {
                timer1.Stop();
                CheckResult();

             }

        }
    


        private void button4_Click(object sender, EventArgs e)  // スタートボタン
        {
            tickCount = 0;
            timer1.Interval = 100;


            stop1 = rand.Next(15, 25);
            stop2 = rand.Next(25, 35);
            stop3 = rand.Next(35, 45);

            timer1.Start();
        }



        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"C:\path\to\your\image.jpg");
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"C:\path\to\your\image.jpg");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stopFlag1 = false;
            stopFlag2 = false;
            stopFlag3 = false;

            timer1.Interval = 100;
            timer1.Start();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\path\to\your\image.jpg");
            timer1.Enabled = true;
        }

        private void CheckResult()
        {
            if (pictureBox1.Image == pictureBox2.Image && pictureBox2.Image == pictureBox3.Image)

            {
                MessageBox.Show("当たり");
            }

        }


    }

}

