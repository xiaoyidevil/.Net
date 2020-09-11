using ServiceStack.Redis;
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
    public partial class Form1 : Form
    {
        //public static ServiceStack.Redis.RedisClient client = new ServiceStack.Redis.RedisClient("127.0.0.1", 6379);
        public static RedisClient client = null;
        public static RedisClient clientV = null;
        private IRedisSubscription subscription;
        private Thread tSubscription;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnectTest_Click(object sender, EventArgs e)
        {
            int intPort = 6379;
            int.TryParse(txtPort.Text, out intPort);
            client = new RedisClient(txtIP.Text, intPort, txtPassword.Text);
            clientV = new RedisClient(txtIP.Text, intPort, txtPassword.Text);
            subscription = client.CreateSubscription();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            if (clientV != null) {
                List<string> listkey = clientV.GetAllKeys();
                List<string> listvalue = clientV.GetValues(listkey);
                DataGridViewColumn gc = new DataGridViewColumn();
                gc.HeaderText = "value";
                GridAllKeys.Rows.Clear();
                foreach (var item in listkey)
                {
                    DataGridViewRow gr = new DataGridViewRow();
                    gr.CreateCells(GridAllKeys);
                    gr.Cells[0].Value = item;
                    gr.Cells[1].Value = clientV.GetValue(item);
                    GridAllKeys.Rows.Add(gr);
                }
            }
        }

        private void btnGetDemoValue_Click(object sender, EventArgs e)
        {
            if (clientV != null)
            {
                string[] channelList = new string[] { "test" };                
                txtDemoValue.Text = clientV.Get<string>("height");
            }
        }

        private void btnSetDemoValue_Click(object sender, EventArgs e)
        {
            clientV.Set<string>("height", txtDemoValue.Text); 
        }

        private void btnSubscribe_Click(object sender, EventArgs e)
        {
            if (tSubscription == null || tSubscription.ThreadState == ThreadState.Aborted)
            {
                tSubscription = new Thread(new ThreadStart(StartSubscription));
            }
            else
            {
                return;
            }
            tSubscription.IsBackground = true;
            tSubscription.Start();
        }

        private void StartSubscription() {
            subscription.OnMessage = (channel, msg) =>
            {
                receiveRedis(subscription, txtChannel.Text, msg);
            };

            //订阅频道时
            subscription.OnSubscribe = (channel) =>
            {
                Console.WriteLine("订阅客户端：开始订阅" + channel);
            };
            //取消订阅频道时
            subscription.OnUnSubscribe = (a) => { Console.WriteLine("订阅客户端：取消订阅");  };

            //订阅频道
            subscription.SubscribeToChannels(txtChannel.Text);
        }

        private void receiveRedis(IRedisSubscription rsScription, string channel, string msg)
        {
            addScription add = new addScription(addScr);
            this.gridSubscribe.Invoke(add,channel,msg);
        }

        delegate void addScription(string channel, string msg);
        private void addScr(string channel, string msg) {
            DataGridViewRow gr = new DataGridViewRow();
            gr.CreateCells(gridSubscribe);
            gr.Cells[0].Value = channel;
            gr.Cells[1].Value = msg;
            gridSubscribe.Rows.Add(gr);
        }

        private void btnEndSubscription_Click(object sender, EventArgs e)
        {
            //subscription.UnSubscribeFromAllChannels();
            tSubscription.Abort();
        }

        private void btnContent_Click(object sender, EventArgs e)
        {
            byte[] PushContent = System.Text.Encoding.Default.GetBytes(txtContent.Text);
            clientV.Publish(txtChannel.Text, PushContent);
        }
    }
}
