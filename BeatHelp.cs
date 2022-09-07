using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using System.IO;
namespace BeatService
{
    public class BeatHelp
    {
        private readonly System.Timers.Timer _timer;
        public BeatHelp()
        {
            _timer=new System.Timers.Timer(1000){AutoReset=true};
            _timer.Elapsed+=TimerElapsed;
        }
        private void TimerElapsed(object sender, ElapsedEventArgs args)
        {
            string[] lines=new string[]{DateTime.Now.ToString()};
            System.IO.File.AppendAllLines(@"C:\Temp\beater.txt",lines);
        }   
        public void Start()
        {
            _timer.Start();
        }
        public void Stop()
        {
            _timer.Stop();
        }
    }
}