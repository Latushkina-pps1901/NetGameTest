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
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using ClassPlayer;
using System.Threading;

namespace NetworkGameServer_LL
{
    public partial class Form1 : Form
    {
       // IAsyncResult BeginAccept(AsyncCallback callback, object state);
        static int port = 777;
        IPAddress IPaddress = IPAddress.Any;
        //Socket server;
        TcpListener listener;
        TcpClient client;
        Dictionary<TcpClient, Player> players = new Dictionary<TcpClient, Player>();
        Thread trSend;
        Player newPlayer = new Player();
        bool isSerververRunning = false;

        public Form1()
        {
            InitializeComponent();
            txtIP.Text = IPAddress.Any.ToString();
            txtPort.Text = "777";
            listener = new TcpListener(new IPEndPoint(IPAddress.Any, 777));
            listener.Start(10);
        }



        private void SendPlayer(Player newPlayer)
        {
            if (newPlayer.Map_num > 0 && players.Count > 0)
            {
                try
                {

                    foreach (var p in players)
                    {
                        if (newPlayer.Map_num == p.Value.Map_num)
                        {
                            if (p.Key.Connected)
                            {
                                NetworkStream stream = p.Key.GetStream();
                                BinaryFormatter binf = new BinaryFormatter();
                                binf.Serialize(stream, newPlayer);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
         }

        private void RecivePlayer()
        {
            //listener.Start(10);
            client = listener.AcceptTcpClient();
            NetworkStream clientStream = client.GetStream();

            if (client.Connected)
            {
                try
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    newPlayer = (Player)bf.Deserialize(clientStream);
                    if (newPlayer != null && newPlayer.Map_num != 0)
                    {
                        switch (newPlayer.Command)
                        {
                            case command.connect:
                                players.Add(client, newPlayer);
                                SendPlayer(newPlayer);
                                switch (newPlayer.Map_num)
                                {
                                    case 1:
                                        listBox_Game1.Items.Add(newPlayer.Name);
                                        break;
                                    case 2:
                                        listBox_Game2.Items.Add(newPlayer.Name);
                                        break;
                                    case 3:
                                        listBox_Game3.Items.Add(newPlayer.Name);
                                        break;
                                    case 4:
                                        listBox_Game4.Items.Add(newPlayer.Name);
                                        break;
                                    case 5:
                                        listBox_Game5.Items.Add(newPlayer.Name);
                                        break;
                                }
                                break;
                            case command.disconnect:
                                players.Remove(client);
                                client.Close();
                                break;

                            case command.play:
                                players[client].Points = newPlayer.Points;
                                SendPlayer(newPlayer);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            //client.Close();
           
        }

        private void CallAccept(IAsyncResult iar)
        {
            Socket server = (Socket)iar.AsyncState;
            Socket client = server.EndAccept(iar);
        }

        public enum Command
        {
            connect,
            play,
            disconnect
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isSerververRunning == false)
            {

                try
                {
                    port = Convert.ToInt32(txtPort.Text);
                    IPaddress = IPAddress.Parse(txtIP.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                while (true)
                {
                    try
                    {
                        RecivePlayer();
                        SendPlayer(newPlayer);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        listener.Stop();
                        foreach (var c in players)
                        {
                            c.Key.Close();
                            players.Remove(c.Key);
                        }
                    }
                }
                isSerververRunning = true;
            }
           
        }
    
    }
}
