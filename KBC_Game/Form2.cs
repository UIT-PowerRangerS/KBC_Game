using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Media;

namespace KBC_Game
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            displaycauhoi(1);
        }
        //Hàm đếm số dòng trong file text.
        public int rangbuoc = 60;
        Timer timer1;
        public int demsocau = 1;
        int tinhdiem(int x)
        {
            if (x == 0)
                return 0;
            if (x == 1)
                return 100;
            if (x == 2)
                return 200;
            if (x == 3)
                return 300;
            if (x == 4)
                return 500;
            if (x == 5)
                return 1000;
            if (x == 6)
                return 2000;
            if (x == 7)
                return 4000;
            if (x == 8)
                return 8000;
            if (x == 9)
                return 16000;
            if (x == 10)
                return 32000;
            if (x == 11)
                return 64000;
            if (x == 12)
                return 125000;
            if (x == 13)
                return 250000;
            if (x == 14)
                return 500000;
            if (x == 15)
                return 1000000;
            else return 0;
        }
        public void Dem_nguoc()
        {
                //code countdown timer
                timer1 = new Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 1000; // 1 second
                timer1.Start();
                label1.Text = rangbuoc.ToString();
                if (rangbuoc == 0)
                {

                }      
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            rangbuoc--;
            if (rangbuoc == 0)
                timer1.Stop();
            label1.Text = rangbuoc.ToString();

        }
        public int countLine(string pathFile)
        {
            int keywordCount = 0;
            string s = File.ReadAllText(pathFile);
            Regex r = new Regex("\n", RegexOptions.Multiline);
            MatchCollection mc = r.Matches(s);
            keywordCount = mc.Count + 1;
            return keywordCount;

        }

        //Hàm lấy câu hỏi ngẫu nhiên  trả về là 1 câu hỏi.
        public cauhoi lcauhoi(int x)
        {
            string path = @Application.StartupPath + @"\QS\q" + x.ToString() + ".mpv";
            cauhoi n = new cauhoi();
            StreamReader caumot = new StreamReader(path);
            Random rd = new Random();
            int rand = rd.Next(1, (countLine(path) / 6) + 1);
            int dk;
            dk = 1;
            while (dk != rand && !caumot.EndOfStream)
            {
                caumot.ReadLine();
                caumot.ReadLine();
                caumot.ReadLine();
                caumot.ReadLine();
                caumot.ReadLine();
                caumot.ReadLine();
                dk++;
            }
            n.cauHoi = caumot.ReadLine();
            n.A = caumot.ReadLine();
            n.B = caumot.ReadLine();
            n.C = caumot.ReadLine();
            n.D = caumot.ReadLine();
            n.dapan1 = caumot.ReadLine();
            return n;
        }
        //Hàm hiển thị câu hỏi ra form.Các đáp án ngẫu nhiên/
        public void displaycauhoi(int x)
        {
            //Đến câu nào thì btn câu đó đổi màu
            if (x == 1)
                pictureBox2.Image = Properties.Resources.Picture1;
            if (x == 2)
                pictureBox2.Image = Properties.Resources.Picture2;
            if (x == 3)
                pictureBox2.Image = Properties.Resources.Picture3;
            if (x == 4)
                pictureBox2.Image = Properties.Resources.Picture4;
            if (x == 5)
                pictureBox2.Image = Properties.Resources.Picture5;
            if (x == 6)
                pictureBox2.Image = Properties.Resources.Picture6;
            if (x == 7)
                pictureBox2.Image = Properties.Resources.Picture7;
            if (x == 8)
                pictureBox2.Image = Properties.Resources.Picture8;
            if (x == 9)
                pictureBox2.Image = Properties.Resources.Picture9;
            if (x == 10)
                pictureBox2.Image = Properties.Resources.Picture10;
            if (x == 11)
                pictureBox2.Image = Properties.Resources.Picture11;
            if (x == 12)
                pictureBox2.Image = Properties.Resources.Picture12;
            if (x == 13)
                pictureBox2.Image = Properties.Resources.Picture13;
            if (x == 14)
                pictureBox2.Image = Properties.Resources.Picture14;
            if (x == 15)
                pictureBox2.Image = Properties.Resources.Picture15;

            Dem_nguoc();
            if (x == 16)
            {

            }
            else
            {//khai báo cauhoi outCH để nhận giá trị đưa ra từ hàm lcauhoi(int x).
                cauhoi outCH = new cauhoi();

                //thiết lập lại
                textBox_cauhoi.Text = "";
                btn_A.Text = "";
                btn_B.Text = "";
                btn_C.Text = "";
                btn_D.Text = "";
                btn_dapan.Text = "";
                //Gán 
                outCH = lcauhoi(x);
                textBox_cauhoi.Text = "Câu " + x.ToString() + ":   " + outCH.cauHoi;

                btn_dapan.Text = outCH.dapan1;
                //Random đáp án
                Random laydapan = new Random();
                int rdda = laydapan.Next(1, 4);
                if (rdda == 1)
                {

                    btn_A.Text = outCH.A;
                    btn_B.Text = outCH.B;
                    btn_C.Text = outCH.C;
                    btn_D.Text = outCH.D;

                }
                if (rdda == 2)
                {

                    btn_A.Text = outCH.D;
                    btn_B.Text = outCH.C;
                    btn_C.Text = outCH.A;
                    btn_D.Text = outCH.B;

                }
                if (rdda == 3)
                {

                    btn_A.Text = outCH.C;
                    btn_B.Text = outCH.A;
                    btn_C.Text = outCH.D;
                    btn_D.Text = outCH.B;

                }
                if (rdda == 4)
                {

                    btn_A.Text = outCH.B;
                    btn_B.Text = outCH.D;
                    btn_C.Text = outCH.C;
                    btn_D.Text = outCH.A;

                }
            }
        }
        
        //Hàm thông báo nếu trả lời sai.
        void thongbaosai()
        {
            this.Close();
            Form4 form4 = new Form4();
            form4.Show();
        }

        //Hàm hiển thị khi trả lời đúng


        void thongbaodung()
        {
            btn_diem.Text = tinhdiem(demsocau).ToString();
            demsocau++;
            Form4 form4 = new Form4();
            form4.ShowDialog();
            this.Show();
        }
        string test;
        private void btn_A_Click(object sender, EventArgs e)
        {
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            timer1.Stop();
            btn_A.BackColor = Color.Yellow;
            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {
                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Adung";
            if (btn_dapan.Text == btn_A.Text)
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
            else
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            timer1.Stop();
            btn_A.BackColor = Color.Yellow;
            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {

                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Bdung";
            if (btn_dapan.Text == btn_A.Text)
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
            else
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            timer1.Stop();
            btn_A.BackColor = Color.Yellow;
            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {

                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Cdung";
            if (btn_dapan.Text == btn_A.Text)
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
            else
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
        }

        private void btn_D_Click(object sender, EventArgs e)
        {
            btn_A.Enabled = false; btn_B.Enabled = false;
            btn_C.Enabled = false; btn_D.Enabled = false;
            timer1.Stop();
            btn_A.BackColor = Color.Yellow;
            if (Convert.ToInt32(btn_diem.Text) >= 1000)
            {

                SoundPlayer AAA = new SoundPlayer(@Application.StartupPath + @"\Data\Music\Sou\Phuong an tra loi cuoi cung cua chung toi la.wav");
                AAA.Play();
            }
            test = "Ddung";
            if (btn_dapan.Text == btn_A.Text)
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
            else
            {
                AA = 0;
                nhap_nhay();
                rangbuoc = 60;
                timer1.Start();
            }
        }
        
        //Tạo hiệu ứng nháy nháy
        int AA = 0;
        private void nhap_nhay()
        {
            AA++;
            if (AA > 96)
            {
                if (btn_dapan.Text == btn_A.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_A.BackColor = Color.Red;

                    }
                    else
                    {
                        btn_A.BackColor = Color.Blue;
                    }

                }
                if (btn_dapan.Text == btn_B.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_B.BackColor = Color.Red;
                    }
                    else
                    {
                        btn_B.BackColor = Color.Blue;
                    }


                }
                if (btn_dapan.Text == btn_C.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_C.BackColor = Color.Red;
                    }
                    else
                    {
                        btn_C.BackColor = Color.Blue;
                    }
                }
                if (btn_dapan.Text == btn_D.Text)
                {
                    if (AA % 2 == 0)
                    {
                        btn_D.BackColor = Color.Red;
                    }
                    else
                    {
                        btn_D.BackColor = Color.Blue;
                    }
                }
            }
            if (AA == 130)
            {
                btn_A.BackColor = Color.Blue;
                btn_B.BackColor = Color.Blue;
                btn_C.BackColor = Color.Blue;
                btn_D.BackColor = Color.Blue;
                if (test == "Adung")
                {
                    if (btn_A.Text == btn_dapan.Text)
                        thongbaodung();
                    else
                        thongbaosai();
                }
                if (test == "Bdung")
                {
                    if (btn_B.Text == btn_dapan.Text)
                        thongbaodung();
                    else
                        thongbaosai();
                }
                if (test == "Cdung")
                {
                    if (btn_C.Text == btn_dapan.Text)
                        thongbaodung();
                    else
                        thongbaosai();
                }
                if (test == "Ddung")
                {
                    if (btn_D.Text == btn_dapan.Text)
                        thongbaodung();
                    else
                        thongbaosai();
                }
                /*
                tmdapan.Stop();
                */
                //testing 3
            }

        }
    }
}
