using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ClassPlayer;
using System.Threading;

namespace NetworkGameClient_LL
{
    public partial class Form1 : Form
    {
        IPAddress ip = IPAddress.Loopback;
        Color color = Color.White;
        TcpClient client;
        NetworkStream clientStream;
               
        public Form1()
        {
            InitializeComponent();
            comboColor.Items.Add(Color.Red.Name);
            comboColor.Items.Add(Color.Orange.Name);
            comboColor.Items.Add(Color.Yellow.Name);
            comboColor.Items.Add(Color.Green.Name);
            comboColor.Items.Add(Color.LightBlue.Name);
            comboColor.Items.Add(Color.Blue.Name);
            comboColor.Items.Add(Color.Violet.Name);
            comboColor.SelectedIndex = 0;

            comboMap.Items.Add("Лес");
            comboMap.Items.Add("Пустыня");
            comboMap.Items.Add("Арктика");
            comboMap.Items.Add("Подземелье");
            comboMap.Items.Add("Космос");
            comboMap.SelectedIndex = 0;

            string myHost = System.Net.Dns.GetHostName();
            string myIP = System.Net.Dns.GetHostByName(myHost).AddressList[0].ToString();
            txtIP.Text = IPAddress.Loopback.ToString();
            txtName.Text = "Новый игрок";
            ip = System.Net.Dns.GetHostByName(myHost).AddressList[0];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                int selected = comboColor.SelectedIndex;
                //color = Color.FromName("Red");
               // ip = IPAddress.Parse(txtIP.Text);
                color = Color.FromName(comboColor.Items[selected].ToString());
               // MessageBox.Show(color.Name);
               ClassPlayer.Player newPlayer = new Player(command.connect, txtName.Text, comboMap.SelectedIndex+1, ip, new Point(50, 50), color);

               client = new TcpClient();
               client.Connect(new IPEndPoint(IPAddress.Parse(txtIP.Text), 777));

               clientStream = client.GetStream();
               BinaryFormatter bf = new BinaryFormatter();
               bf.Serialize(clientStream, newPlayer);
               clientStream.Flush();

               NetGame ng = new NetGame(newPlayer);
               ng.BackColor = Color.Gold;
               ng.ShowDialog();
              // Application.Run(ng);


               this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
}
