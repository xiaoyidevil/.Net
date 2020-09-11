namespace redisDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnectTest = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.btnGetDemoValue = new System.Windows.Forms.Button();
            this.GridAllKeys = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDemoValue = new System.Windows.Forms.TextBox();
            this.btnSetDemoValue = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.btnSubscribe = new System.Windows.Forms.Button();
            this.gridSubscribe = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEndSubscription = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnContent = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GridAllKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubscribe)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnectTest
            // 
            this.btnConnectTest.Location = new System.Drawing.Point(738, 62);
            this.btnConnectTest.Name = "btnConnectTest";
            this.btnConnectTest.Size = new System.Drawing.Size(98, 23);
            this.btnConnectTest.TabIndex = 0;
            this.btnConnectTest.Text = "测试链接";
            this.btnConnectTest.UseVisualStyleBackColor = true;
            this.btnConnectTest.Click += new System.EventHandler(this.btnConnectTest_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(113, 8);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(619, 21);
            this.txtIP.TabIndex = 1;
            this.txtIP.Text = "192.168.0.4";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "ip";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "端口";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(113, 35);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(619, 21);
            this.txtPort.TabIndex = 3;
            this.txtPort.Text = "6379";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "密码";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(113, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(619, 21);
            this.txtPassword.TabIndex = 5;
            this.txtPassword.Text = "123456789";
            // 
            // btnShowAll
            // 
            this.btnShowAll.Location = new System.Drawing.Point(738, 101);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(98, 23);
            this.btnShowAll.TabIndex = 7;
            this.btnShowAll.Text = "显示所有key";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // btnGetDemoValue
            // 
            this.btnGetDemoValue.Location = new System.Drawing.Point(738, 222);
            this.btnGetDemoValue.Name = "btnGetDemoValue";
            this.btnGetDemoValue.Size = new System.Drawing.Size(98, 23);
            this.btnGetDemoValue.TabIndex = 8;
            this.btnGetDemoValue.Text = "获取demo值";
            this.btnGetDemoValue.UseVisualStyleBackColor = true;
            this.btnGetDemoValue.Click += new System.EventHandler(this.btnGetDemoValue_Click);
            // 
            // GridAllKeys
            // 
            this.GridAllKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAllKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.GridAllKeys.Location = new System.Drawing.Point(113, 101);
            this.GridAllKeys.Name = "GridAllKeys";
            this.GridAllKeys.RowTemplate.Height = 23;
            this.GridAllKeys.Size = new System.Drawing.Size(619, 115);
            this.GridAllKeys.TabIndex = 9;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 222);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 11;
            this.label4.Text = "height";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDemoValue
            // 
            this.txtDemoValue.Location = new System.Drawing.Point(113, 222);
            this.txtDemoValue.Name = "txtDemoValue";
            this.txtDemoValue.Size = new System.Drawing.Size(619, 21);
            this.txtDemoValue.TabIndex = 10;
            // 
            // btnSetDemoValue
            // 
            this.btnSetDemoValue.Location = new System.Drawing.Point(844, 222);
            this.btnSetDemoValue.Name = "btnSetDemoValue";
            this.btnSetDemoValue.Size = new System.Drawing.Size(98, 23);
            this.btnSetDemoValue.TabIndex = 12;
            this.btnSetDemoValue.Text = "设置demo值";
            this.btnSetDemoValue.UseVisualStyleBackColor = true;
            this.btnSetDemoValue.Click += new System.EventHandler(this.btnSetDemoValue_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "channel";
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(113, 257);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(619, 21);
            this.txtChannel.TabIndex = 14;
            this.txtChannel.Text = "test";
            // 
            // btnSubscribe
            // 
            this.btnSubscribe.Location = new System.Drawing.Point(738, 255);
            this.btnSubscribe.Name = "btnSubscribe";
            this.btnSubscribe.Size = new System.Drawing.Size(98, 23);
            this.btnSubscribe.TabIndex = 15;
            this.btnSubscribe.Text = "订阅";
            this.btnSubscribe.UseVisualStyleBackColor = true;
            this.btnSubscribe.Click += new System.EventHandler(this.btnSubscribe_Click);
            // 
            // gridSubscribe
            // 
            this.gridSubscribe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridSubscribe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gridSubscribe.Location = new System.Drawing.Point(113, 284);
            this.gridSubscribe.Name = "gridSubscribe";
            this.gridSubscribe.RowTemplate.Height = 23;
            this.gridSubscribe.Size = new System.Drawing.Size(619, 126);
            this.gridSubscribe.TabIndex = 16;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Column1";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Column2";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // btnEndSubscription
            // 
            this.btnEndSubscription.Location = new System.Drawing.Point(844, 255);
            this.btnEndSubscription.Name = "btnEndSubscription";
            this.btnEndSubscription.Size = new System.Drawing.Size(98, 23);
            this.btnEndSubscription.TabIndex = 17;
            this.btnEndSubscription.Text = "结束订阅";
            this.btnEndSubscription.UseVisualStyleBackColor = true;
            this.btnEndSubscription.Click += new System.EventHandler(this.btnEndSubscription_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(113, 416);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(619, 21);
            this.txtContent.TabIndex = 19;
            this.txtContent.Text = "test";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(54, 419);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "推送内容";
            // 
            // btnContent
            // 
            this.btnContent.Location = new System.Drawing.Point(738, 414);
            this.btnContent.Name = "btnContent";
            this.btnContent.Size = new System.Drawing.Size(98, 23);
            this.btnContent.TabIndex = 20;
            this.btnContent.Text = "推送";
            this.btnContent.UseVisualStyleBackColor = true;
            this.btnContent.Click += new System.EventHandler(this.btnContent_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 492);
            this.Controls.Add(this.btnContent);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnEndSubscription);
            this.Controls.Add(this.gridSubscribe);
            this.Controls.Add(this.btnSubscribe);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.btnSetDemoValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDemoValue);
            this.Controls.Add(this.GridAllKeys);
            this.Controls.Add(this.btnGetDemoValue);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.btnConnectTest);
            this.Controls.Add(this.label5);
            this.Name = "Form1";
            this.Text = "redis demo";
            ((System.ComponentModel.ISupportInitialize)(this.GridAllKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSubscribe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnectTest;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button btnGetDemoValue;
        private System.Windows.Forms.DataGridView GridAllKeys;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDemoValue;
        private System.Windows.Forms.Button btnSetDemoValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Button btnSubscribe;
        private System.Windows.Forms.DataGridView gridSubscribe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btnEndSubscription;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnContent;
    }
}

