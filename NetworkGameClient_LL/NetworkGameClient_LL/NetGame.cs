using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassPlayer;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace NetworkGameClient_LL
{
    public partial class NetGame : Form
    {
        Player myPlayer;
        Keys pressedKey = Keys.None;
        Dictionary<IPAddress, Player> players = new Dictionary<IPAddress, Player>();
        TcpListener tcpListener;
        TcpClient client = new TcpClient();
        Thread threadListen;
        NetworkStream ns;

        public NetGame(Player p)
        {
           InitializeComponent();
           myPlayer = p;
           myPlayer.Command = command.play;
           DrawPlayer(myPlayer.Points, myPlayer.Color);
          // tcpListener = new TcpListener(p.IP, 888);
           client.Connect(p.IP, 777);
           ns = client.GetStream();
           threadListen = new Thread(ListenServer);
           threadListen.IsBackground = true;
           threadListen.Start();
            
        }

        private void NetGame_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKey = e.KeyCode;
            KeyPressWorker(pressedKey);
        }

        public void DrawPlayer(Point p, Color c)
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.Gold);
            g.FillEllipse(new SolidBrush(c), p.X - 5, p.Y - 5, 10, 10);
            
        }

        private void NetGame_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.Gold);
            e.Graphics.FillEllipse(new SolidBrush(myPlayer.Color), myPlayer.Points.X - 5, myPlayer.Points.Y - 5, 10, 10);
            
        }

        private void KeyPressWorker(Keys k)
        {
            if (k == Keys.Right)
            {
                if (myPlayer.Points.X + 5 <= 800)
                {
                    int x = myPlayer.Points.X + 5;
                    int y = myPlayer.Points.Y;
                    myPlayer.Points = new Point(x, y);
                }
            }

            if (k == Keys.Left)
            {
                if (myPlayer.Points.X - 5 >= 20)
                {
                    int x = myPlayer.Points.X - 5;
                    int y = myPlayer.Points.Y;
                    myPlayer.Points = new Point(x, y);
                }
            }

            if (k == Keys.Up)
            {
                if (myPlayer.Points.Y - 5 >= 20)
                {
                    int x = myPlayer.Points.X;
                    int y = myPlayer.Points.Y - 5;
                    myPlayer.Points = new Point(x, y);
                }
            }

            if (k == Keys.Down)
            {
                if (myPlayer.Points.Y + 5 <= 800)
                {
                    int x = myPlayer.Points.X;
                    int y = myPlayer.Points.Y + 5;
                    myPlayer.Points = new Point(x, y);
                }
            }

            DrawPlayer(myPlayer.Points, myPlayer.Color);
            SendPlayerToServer();
        }

        private void NetGame_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKey = Keys.None;
        }

        private void NetGame_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
        }

        private void ListenServer()
        {
            while (true)
            {
                if (ns != null && client.Connected && ns.DataAvailable)
                {
                    try
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        Player newPlayer = (Player)bf.Deserialize(ns);
                    
                    
                        if (players.Count == 0)
                        {
                            players.Add(newPlayer.IP, newPlayer);
                        }
                        else
                        {
                            if (players.ContainsKey(newPlayer.IP))
                            {
                                players[newPlayer.IP].Points = new Point(newPlayer.Points.X, newPlayer.Points.Y);
                            }
                            else
                            {
                                players.Add(newPlayer.IP, newPlayer);
                            }
                            if (players[newPlayer.IP].Command == command.disconnect)
                            {
                                players.Remove(newPlayer.IP);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                if (players.Count > 0)
                {
                    foreach (var p in players)
                    {
                        DrawPlayer(p.Value.Points, p.Value.Color);
                    }
                }

                Thread.Sleep(150);
            }
        }

        private void SendPlayerToServer()
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ns, myPlayer);
            ns.Flush();
            //ns.Close();
            //client.Close();
        }

    }
}
