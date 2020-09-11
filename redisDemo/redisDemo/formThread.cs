using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redisDemo
{
    public partial class formThread : Form
    {
        delegate void set_Text(string i);
        int i;          //全局变量i
        Thread thread1;
        set_Text aa;
        private void Set_LabelText(string i)
        {
            label1.Text = i;
        }
        public formThread()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread1 = new Thread(run);
            thread1.Start();
        }

        private void run()
        {
            for (int i = 0; i < 101; i++)
            {
                label1.Invoke(aa, new object[] { i.ToString() }); //通过调用委托，来改变lable1的值
                Thread.Sleep(100); //线程休眠时间，单位是ms
            }
        }

        private void formThread_Load(object sender, EventArgs e)
        {
            label1.Text = "0";
            aa = new set_Text(Set_LabelText);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i > 100)
            {
                timer1.Stop();
            }
            label1.Text = i.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void formThread_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread1!=null && thread1.IsAlive) {
                thread1.Abort();
                
            }
        }
    }
}
