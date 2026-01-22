using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Media;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace slot777
{
    public partial class Form1 : Form
    {

        Image[] slotImages;  //画像の箱

        int tickCount = 0;  //画像の変わるスピード　

        int reelSpeed1 = 0;      //リールの回転速度
        int reelSpeed2 = 0;
        int reelSpeed3 = 0;

        bool isSpinning = false; //リールの状態を判定　

        bool stopFlag1 = false;  //ボタンの状態　
        bool stopFlag2 = false;
        bool stopFlag3 = false;

        int coins = 47;    // 所持コイン
        int bet = 3;       // 1回のBET

        int centerY1;     //真ん中
        int centerY2;
        int centerY3;

        int reelIndex1 = 1;   //インデックスで画像の順番を制御　上から下に
        int reelIndex2 = 2;
        int reelIndex3 = 3;

        Random rand = new Random();

        SoundPlayer start;  //サウンド
        SoundPlayer stop;
        SoundPlayer hit;

        
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e) 
        {
            slotImages = new Image[]　　 //絵柄をリソースに追加  　　　
            {
                
                Properties.Resources._7,
                Properties.Resources.BAR,
                Properties.Resources.Beru,
                Properties.Resources.Budou1,
               
            };

            this.ClientSize = new Size(1031,420); //表示画面のサイズ
            this.StartPosition = FormStartPosition.CenterScreen;  //真ん中に表示する

            this.KeyPreview = true;  //キー入力

            //リールの真ん中に停止する　高さ割る２
            centerY1 = panel4.Height / 2;
            centerY2 = panel5.Height / 2;
            centerY3 = panel6.Height / 2;

            labelCoins.Text = $"Coins: {coins}";

            //サウンドを追加
            start = new SoundPlayer(Properties.Resources.start);　　　//サウンド使うための処理
            stop = new SoundPlayer(Properties.Resources.stop);
            hit = new SoundPlayer(Properties.Resources.atari);


            //ボタンの設定　色　サイズ
            button1.Width = 100;
            button1.Height = 100;

            button2.Width = 100;
            button2.Height = 100;

            button3.Width = 100;
            button3.Height = 100;

            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.BackColor = Color.Blue;
            button1.ForeColor = Color.White;

            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.BackColor = Color.Blue;
            button2.ForeColor = Color.White;

            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.BackColor = Color.Blue;
            button3.ForeColor = Color.White;


            //ボタンを丸くする
            GraphicsPath a = new GraphicsPath();
            a.AddEllipse(0, 0, button1.Width, button1.Height);
            button1.Region = new Region(a);

            GraphicsPath b = new GraphicsPath();
            b.AddEllipse(0, 0, button2.Width, button2.Height);
            button2.Region = new Region(b);

            GraphicsPath c = new GraphicsPath();
            c.AddEllipse(0, 0, button3.Width, button3.Height);
            button3.Region = new Region(c);
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            // ▼ リール1
            if (!stopFlag1)
            {
                pictureBox1.Top += reelSpeed1;      //画像を次へ

                if (pictureBox1.Top >= panel4.Height)　//画像が一番下に来たら
                {
                    pictureBox1.Top = -pictureBox1.Height;  //画像を一番上に移動

                    reelIndex1 = (reelIndex1 + 1) % slotImages.Length;  //  画像がスライドアウトしたら次の画像へ
                    pictureBox1.Image = slotImages[reelIndex1];

                }
            }

            else
            {

                int picCenter = pictureBox1.Top + pictureBox1.Height / 2;　//画像のy座標 +　画像の真ん中　=　真ん中がどこにあるのか
                int diff = centerY1 - picCenter;　　　　　　　　　　　　　//diff = 中心が上か下かの判断

                if (Math.Abs(diff) <= reelSpeed1)        //1コマより距離が短いか長いか　短いならそのまま真ん中に
                {
                    pictureBox1.Top += diff;            //真ん中に近いなら止める
                    reelSpeed1 = 0;                    //停止
                }

                else　　　　　　　　　　　　　　    　//1コマ分より遠いならその分動かす
                {
                    pictureBox1.Top += Math.Sign(diff) * reelSpeed1;   　//Math.Sign(diff) =絶対値
                }

            }

            // ▼ リール2
            if (!stopFlag2)
            {
                pictureBox2.Top += reelSpeed2;

                if (pictureBox2.Top >= panel5.Height)
                {
                    pictureBox2.Top = -pictureBox2.Height;

                    reelIndex2 = (reelIndex2 + 1) % slotImages.Length;
                    pictureBox2.Image = slotImages[reelIndex2];

                }
            }
            　
            else
            {

                int picCenter = pictureBox2.Top + pictureBox2.Height / 2;
                int diff = centerY2 - picCenter;

                if (Math.Abs(diff) <= reelSpeed2)
                {
                    pictureBox2.Top += diff;
                    reelSpeed2 = 0;
                }

                else
                {
                    pictureBox2.Top += Math.Sign(diff) * reelSpeed2;
                }

            }

            // ▼ リール3
            if (!stopFlag3)
            {
                pictureBox3.Top += reelSpeed3;

                if (pictureBox3.Top >= panel6.Height)
                {
                    pictureBox3.Top = -pictureBox3.Height;

                    reelIndex3 = (reelIndex3 + 1) % slotImages.Length;
                    pictureBox3.Image = slotImages[reelIndex3];

                }
            }

            else
            {

                int picCenter = pictureBox3.Top + pictureBox3.Height / 2;
                int diff = centerY3 - picCenter;

                if (Math.Abs(diff) <= reelSpeed3)
                {
                    pictureBox3.Top += diff;
                    reelSpeed3 = 0;
                }

                else
                {
                    pictureBox3.Top += Math.Sign(diff) * reelSpeed3;
                }

            }


            // 全部止まったら判定
            if (reelSpeed1 == 0 && reelSpeed2 == 0 && reelSpeed3 == 0)
            {
                timer1.Stop();
                isSpinning = false;
                button5.Enabled = true;

                CheckResult();
            }


        }

        private void button1_Click(object sender, EventArgs e) //ボタン1の止める処理
        {
            if (!isSpinning || stopFlag1) return; //回転中だけボタンを有効にする
            stopFlag1 = true;                     //止まったらリール停止
            stop.Play();

        }


        private void button2_Click(object sender, EventArgs e)  //ボタン2
        {
            if (!isSpinning || stopFlag2) return;
            stopFlag2 = true;
            stop.Play();

        }

        private void button3_Click(object sender, EventArgs e)  //ボタン3
        {
            if (!isSpinning || stopFlag3) return;
            stopFlag3 = true;
            stop.Play();
        }


        private void button5_Click(object sender, EventArgs e)  // スタートボタン
        {
            start.Play();  //スタートSE
            if (isSpinning) return;

            if (coins < bet)
            {
                DialogResult result = MessageBox.Show(
                    "コインが足りません。\nコインを追加しますか？",
                    "コイン不足",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    coins += 47;   // ★追加するコイン枚数
                    labelCoins.Text = $"Coins: {coins}";
                }

                return;
            }


            button5.Enabled = false;


            // BET 消費
            coins -= bet;    //coinからベット数減らす
            labelCoins.Text = $"Coins: {coins}";

            // ストップフラグ解除
            stopFlag1 = stopFlag2 = stopFlag3 = false;

            // スピード初期化
            reelSpeed1 = reelSpeed2 = reelSpeed3 = 30;    //リールの速度

            pictureBox1.Top = -pictureBox1.Height;  //一番上に次の画像を表示  // 画像を
            pictureBox2.Top = -pictureBox2.Height;
            pictureBox3.Top = -pictureBox3.Height;


            // ランダムで画像を決める
            reelIndex1 = rand.Next(slotImages.Length);  //ボタンを押したらランダムで画像が表示
            reelIndex2 = rand.Next(slotImages.Length);
            reelIndex3 = rand.Next(slotImages.Length);

            pictureBox1.Image = slotImages[reelIndex1];
            pictureBox2.Image = slotImages[reelIndex2];
            pictureBox3.Image = slotImages[reelIndex3];


            timer1.Interval = 1;　　//画像の切り替わるスピード
            isSpinning = true;
            timer1.Start();
        }


        private void CheckResult()    //停止した時の判定処理
        {
            Image　img1 = pictureBox1.Image;   
            Image  img2 = pictureBox2.Image;
            Image  img3 = pictureBox3.Image;

            if (img1 == img2 && img2 == img3)  //絵柄がそろったら枚数と音を追加
            {
                hit.Play();
                coins += bet * 10;   //30枚
                labelCoins.Text = $"Coins: {coins}";
            }

        }


        private void Form1_Key(object sender, KeyEventArgs e) //キーボタン対応
        {
            // 1：スタート
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                button5.PerformClick();
            }

            // 2：左リール停止
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                button1.PerformClick();
            }

            // 3：中リール停止
            else if (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3)
            {
                button2.PerformClick();
            }

            // 4：右リール停止
            else if (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5)
            {
                button3.PerformClick();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile(@"C:\path\to\your\image.jpg");
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Image.FromFile(@"C:\path\to\your\image.jpg");
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            labelCoins.Font = new Font(labelCoins.Font.FontFamily, 15);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }

}

