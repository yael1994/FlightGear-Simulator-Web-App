﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace Ex3.Models
{
    public class InfoModel
    {
        private static InfoModel s_instace = null;

        public static InfoModel Instance
        {
            get
            {
                if (s_instace == null)
                {
                    s_instace = new InfoModel();
                }
                return s_instace;
            }
        }


        public FlightModel Flight { get; private set; }
        public InfoModel()
        {
            Flight = new FlightModel();
        }

        public int time { get; set; }

        public void startServer(string ip, int port)
        {
            Client.getInstance().Connect(ip, port);
        }
        public void readServer()
        {
           Client.getInstance().Write();
        }
        public void readServerTime()
        { 
                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        Client.getInstance().Write();
                    }
                }
                ); t.Start(); 
        }
    }
}