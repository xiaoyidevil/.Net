namespace ImageHanlder
{
    partial class PanelDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnZType = new System.Windows.Forms.Button();
            this.txtAngle = new System.Windows.Forms.TextBox();
            this.txtNum = new System.Windows.Forms.TextBox();
            this.btnDrawBow = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DrawZType_RT = new System.Windows.Forms.Button();
            this.btnDrawZType_LT = new System.Windows.Forms.Button();
            this.btnDrawZType_LB = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 436);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Crimson;
            this.panel3.Controls.Add(this.btnDrawZType_LB);
            this.panel3.Controls.Add(this.btnDrawZType_LT);
            this.panel3.Controls.Add(this.DrawZType_RT);
            this.panel3.Controls.Add(this.btnZType);
            this.panel3.Controls.Add(this.txtAngle);
            this.panel3.Controls.Add(this.txtNum);
            this.panel3.Controls.Add(this.btnDrawBow);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(44, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(836, 50);
            this.panel3.TabIndex = 3;
            // 
            // btnZType
            // 
            this.btnZType.Location = new System.Drawing.Point(384, 13);
            this.btnZType.Name = "btnZType";
            this.btnZType.Size = new System.Drawing.Size(102, 25);
            this.btnZType.TabIndex = 3;
            this.btnZType.Text = "DrawZType_RB";
            this.btnZType.UseVisualStyleBackColor = true;
            this.btnZType.Click += new System.EventHandler(this.btnZType_Click);
            // 
            // txtAngle
            // 
            this.txtAngle.Location = new System.Drawing.Point(278, 16);
            this.txtAngle.Name = "txtAngle";
            this.txtAngle.Size = new System.Drawing.Size(100, 21);
            this.txtAngle.TabIndex = 2;
            this.txtAngle.Text = "45";
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(160, 16);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(100, 21);
            this.txtNum.TabIndex = 1;
            this.txtNum.Text = "2";
            // 
            // btnDrawBow
            // 
            this.btnDrawBow.Location = new System.Drawing.Point(24, 16);
            this.btnDrawBow.Name = "btnDrawBow";
            this.btnDrawBow.Size = new System.Drawing.Size(89, 22);
            this.btnDrawBow.TabIndex = 0;
            this.btnDrawBow.Text = "DrawBow";
            this.btnDrawBow.UseVisualStyleBackColor = true;
            this.btnDrawBow.Click += new System.EventHandler(this.btnDrawBow_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(880, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(23, 50);
            this.panel4.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(44, 50);
            this.panel2.TabIndex = 0;
            // 
            // DrawZType_RT
            // 
            this.DrawZType_RT.Location = new System.Drawing.Point(492, 13);
            this.DrawZType_RT.Name = "DrawZType_RT";
            this.DrawZType_RT.Size = new System.Drawing.Size(102, 25);
            this.DrawZType_RT.TabIndex = 4;
            this.DrawZType_RT.Text = "DrawZType_RT";
            this.DrawZType_RT.UseVisualStyleBackColor = true;
            this.DrawZType_RT.Click += new System.EventHandler(this.DrawZType_RT_Click);
            // 
            // btnDrawZType_LT
            // 
            this.btnDrawZType_LT.Location = new System.Drawing.Point(602, 14);
            this.btnDrawZType_LT.Name = "btnDrawZType_LT";
            this.btnDrawZType_LT.Size = new System.Drawing.Size(102, 25);
            this.btnDrawZType_LT.TabIndex = 5;
            this.btnDrawZType_LT.Text = "DrawZType_LT";
            this.btnDrawZType_LT.UseVisualStyleBackColor = true;
            this.btnDrawZType_LT.Click += new System.EventHandler(this.btnDrawZType_LT_Click);
            // 
            // btnDrawZType_LB
            // 
            this.btnDrawZType_LB.Location = new System.Drawing.Point(710, 14);
            this.btnDrawZType_LB.Name = "btnDrawZType_LB";
            this.btnDrawZType_LB.Size = new System.Drawing.Size(102, 25);
            this.btnDrawZType_LB.TabIndex = 6;
            this.btnDrawZType_LB.Text = "DrawZType_LB";
            this.btnDrawZType_LB.UseVisualStyleBackColor = true;
            this.btnDrawZType_LB.Click += new System.EventHandler(this.btnDrawZType_LB_Click);
            // 
            // PanelDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 486);
            this.Controls.Add(this.panel1);
            this.Name = "PanelDemo";
            this.Text = "PanelDemo";
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PanelDemo_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDrawBow;
        private System.Windows.Forms.TextBox txtNum;
        private System.Windows.Forms.TextBox txtAngle;
        private System.Windows.Forms.Button btnZType;
        private System.Windows.Forms.Button DrawZType_RT;
        private System.Windows.Forms.Button btnDrawZType_LT;
        private System.Windows.Forms.Button btnDrawZType_LB;
    }
}