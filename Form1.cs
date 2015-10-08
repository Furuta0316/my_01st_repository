using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace MyFileLoad
{
    public partial class Form1 : Form
    {

        int DelayedMsgCounter_ = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = textBox1.Text;

            if(System.IO.File.Exists(path)==false){
                MessageBox.Show("ファイルが見つかりません","お知らせ");
                return;
            }
            System.IO.StreamReader textFile;
            textFile = new System.IO.StreamReader(path, System.Text.Encoding.Default);
            label1.Text = textFile.ReadToEnd();
            textFile.Close();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //New File
            string path = textBox1.Text;
            //stateusString
            System.IO.StreamWriter textFile;
            textFile = new System.IO.StreamWriter(
                path, false, System.Text.Encoding.Default);
            textFile.WriteLine(string.Format("ファイルの作成時刻は{0}です。",
                DateTime.Now.ToLongTimeString()));
            textFile.Close();
            label1.Text = "新規作成しました：" + path;

        }

        private void timer1_Trick(object sender, EventArgs e)
        {

            label1.Text = string.Format("現在の時刻は{0}です。",
                DateTime.Now.ToLongTimeString());
            switch (DelayedMsgCounter_)
            {
                case 3:
                    label1.Text = "ファイルを新規作成してみよう。";
                    break;

                case 10:
                    DelayedMsgCounter_ = 0;
                    break;

                default:
                    DelayedMsgCounter_++;
                    break;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
