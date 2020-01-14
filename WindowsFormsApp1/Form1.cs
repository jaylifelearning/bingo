using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // 宣告myStringLists 為List
        // 以下List 裡為string 型態
        int[] randomArray = new int[1];
        List<int> myStringLists = new List<int>();
        public int i;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;
            timer1.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();  //產生亂數初始值

            randomArray[i] = rnd.Next(1,65);   //亂數產生，亂數產生的範圍是1~9

            for (int j = 0; j < i; j++)
            {
                while (randomArray[j] == randomArray[i])    //檢查是否與前面產生的數值發生重複，如果有就重新產生
                    {
                        j = 0;  //如有重複，將變數j設為0，再次檢查 (因為還是有重複的可能)
                        randomArray[i] = rnd.Next(1,65);   //重新產生，存回陣列，亂數產生的範圍是1~9
                    }
            }
            label2.Text = randomArray[i].ToString();
  
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            label2.Text = randomArray[i].ToString();
            myStringLists.Add(randomArray[i]);
            for (int a = 0; a < myStringLists.Count; a++)
            {
                for (int b = a + 1; b < myStringLists.Count; b++)
                {
                    if (myStringLists[a] != myStringLists[b])
                    {
                        label1.Text = String.Join(", ", myStringLists);
                    }
                    else
                    {
                        MessageBox.Show("號碼已重複");
                        myStringLists.RemoveAt(myStringLists.Count - 1);
                    }
                }
            }
            label1.Text = String.Join(", ", myStringLists);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
