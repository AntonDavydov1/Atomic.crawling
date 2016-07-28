using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace Chess.Atomic.Crawling.Models.ViewModels
{
    public class WathcModel
    {
        public class WatchViewModel 
        {
            public string section { get; set; }
            public string timeElapsed { get; set; }
            public string timePercentage { get; set; }
        }

        public Stopwatch totalTime { get; set; }

        public Stopwatch[] t { get; set; }

        public List<WatchViewModel> data;

                
        public WathcModel()
        {
            totalTime = new Stopwatch();

            t = new Stopwatch[11];

            for (int i = 0; i < t.Length; ++i)
            {
                t[i] = new Stopwatch();
            }
        }

        public void ConvertResults()
        {
            data = new List<WatchViewModel>();

            data.Add(new WatchViewModel { section = "Total", timeElapsed = totalTime.Elapsed.ToString(), timePercentage = "100%" });

            if (totalTime.Elapsed.TotalMilliseconds > 0)
            {
                for (int i = 1; i < t.Length; ++i)
                {
                    data.Add(new WatchViewModel { section = i.ToString(), timeElapsed = t[i].Elapsed.ToString(), timePercentage = ((t[i].Elapsed.TotalMilliseconds / totalTime.Elapsed.TotalMilliseconds) * 100).ToString() });

                }
            }
        }
    }
}