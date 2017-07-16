using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class Player
    {
        [Key]
        public string id { get; set; }

        public int raiting { get; set; }

        //public int localCount { get; set; }

        //public int lichessCount { get; set; }

    }
}