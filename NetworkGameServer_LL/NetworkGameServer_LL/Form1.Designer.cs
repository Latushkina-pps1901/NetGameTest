namespace NetworkGameServer_LL
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.listBox_Game1 = new System.Windows.Forms.ListBox();
            this.listBox_Game2 = new System.Windows.Forms.ListBox();
            this.listBox_Game3 = new System.Windows.Forms.ListBox();
            this.listBox_Game4 = new System.Windows.Forms.ListBox();
            this.listBox_Game5 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "lP адрес";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(68, 6);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(148, 20);
            this.txtIP.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(313, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Порт";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(360, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(75, 20);
            this.txtPort.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(505, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // listBox_Game1
            // 
            this.listBox_Game1.FormattingEnabled = true;
            this.listBox_Game1.Items.AddRange(new object[] {
            "Map 1"});
            this.listBox_Game1.Location = new System.Drawing.Point(8, 57);
            this.listBox_Game1.Name = "listBox_Game1";
            this.listBox_Game1.Size = new System.Drawing.Size(148, 264);
            this.listBox_Game1.TabIndex = 5;
            // 
            // listBox_Game2
            // 
            this.listBox_Game2.FormattingEnabled = true;
            this.listBox_Game2.Items.AddRange(new object[] {
            "Map 2"});
            this.listBox_Game2.Location = new System.Drawing.Point(162, 57);
            this.listBox_Game2.Name = "listBox_Game2";
            this.listBox_Game2.Size = new System.Drawing.Size(148, 264);
            this.listBox_Game2.TabIndex = 6;
            // 
            // listBox_Game3
            // 
            this.listBox_Game3.FormattingEnabled = true;
            this.listBox_Game3.Items.AddRange(new object[] {
            "Map 3"});
            this.listBox_Game3.Location = new System.Drawing.Point(316, 57);
            this.listBox_Game3.Name = "listBox_Game3";
            this.listBox_Game3.Size = new System.Drawing.Size(148, 264);
            this.listBox_Game3.TabIndex = 7;
            // 
            // listBox_Game4
            // 
            this.listBox_Game4.FormattingEnabled = true;
            this.listBox_Game4.Items.AddRange(new object[] {
            "Map 4"});
            this.listBox_Game4.Location = new System.Drawing.Point(470, 57);
            this.listBox_Game4.Name = "listBox_Game4";
            this.listBox_Game4.Size = new System.Drawing.Size(148, 264);
            this.listBox_Game4.TabIndex = 8;
            // 
            // listBox_Game5
            // 
            this.listBox_Game5.FormattingEnabled = true;
            this.listBox_Game5.Items.AddRange(new object[] {
            "Map 5"});
            this.listBox_Game5.Location = new System.Drawing.Point(624, 57);
            this.listBox_Game5.Name = "listBox_Game5";
            this.listBox_Game5.Size = new System.Drawing.Size(148, 264);
            this.listBox_Game5.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 333);
            this.Controls.Add(this.listBox_Game5);
            this.Controls.Add(this.listBox_Game4);
            this.Controls.Add(this.listBox_Game3);
            this.Controls.Add(this.listBox_Game2);
            this.Controls.Add(this.listBox_Game1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Server";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox listBox_Game1;
        private System.Windows.Forms.ListBox listBox_Game2;
        private System.Windows.Forms.ListBox listBox_Game3;
        private System.Windows.Forms.ListBox listBox_Game4;
        private System.Windows.Forms.ListBox listBox_Game5;
    }
}

