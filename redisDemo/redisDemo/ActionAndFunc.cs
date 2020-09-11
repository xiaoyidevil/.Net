using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace redisDemo
{
    public partial class ActionAndFunc : Form
    {
        private delegate void BuyBook();
        private delegate void BuyBook1(string bookname);

        public static void Book()
        {
            Console.WriteLine("我是买书的是:{0}");
        }

        public static void Book(string BookName) {
            Console.WriteLine("我是买书的是:{0}", BookName);
        }

        public ActionAndFunc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BuyBook buybook = new BuyBook(Book);
            buybook();
            BuyBook1 buybook1 = new BuyBook1(Book);
            buybook1("teasd");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Action<string> BookAction = new Action<string>(Book);
            BookAction("test");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Func<string> RetBookx = new Func<string>(FuncBookx);
            Console.WriteLine(RetBookx);

        }

        public static string FuncBookx()
        {
            string aa = "asdf";
            return aa;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Func<string, string> RetBook = new Func<string, string>(FuncBook);
            Console.WriteLine(RetBook("aaa"));
        }

        public static string FuncBook(string BookName)
        {
            return "the book name that you buy:" + BookName;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Func<string> funcValue = delegate
            {
                return "我是即将传递的值3";
            };
            DisPlayValue(funcValue);
        }

        private void DisPlayValue(Func<string> func)
        {
            string RetFunc = func();
            Console.WriteLine("我在测试一下传过来值：{0}", RetFunc);
        }
    }
}
