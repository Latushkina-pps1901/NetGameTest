using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Drawing;


namespace ClassPlayer
{
    
        [Serializable]
        public enum command
        {
            connect,
            play,
            disconnect
        }

        [Serializable]
        public class Player
        {
            public command Command { get; set; }
            public string Name { get; set; }
            public int Map_num { get; set; }
            public IPAddress IP { get; set; }
            public Point Points { get; set; }
            public Color Color { get; set; }
            public Player(command _command, string name, int map, IPAddress ip, Point p, Color c)
            {
                Command = _command;
                Name = name;
                Map_num = map;
                IP = ip;
                Points = p;
                Color = c;
            }
            public Player()
            {
                Command = command.connect;
                Name = "";
                Map_num = 0;
                IP = IPAddress.Any;
                Points = new Point(0, 0);
                Color = Color.White;
            }
        }
   
}
