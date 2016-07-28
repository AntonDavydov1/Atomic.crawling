using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models.ViewModels
{
    
    public class StatisticsModel
    {
        [Display(Name="Player name")]
        [Editable(false)]
        public string name { get; set; }

        [Display(Name = "Player raiting")]
        [Editable(false)]
        public int raiting { get; set; }

        [Display(Name="Count in Lichess database")]
        [Editable(false)]
        public int lichessCount { get; set; }

        [Display(Name="Count in local database")]
        [Editable(false)]
        public int localCount { get; set; }

        [Display(Name="Completion percentage")]
        [Editable(false)]
        public float percentage { get; set; }

    }
}