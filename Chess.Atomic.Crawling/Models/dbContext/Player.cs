using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class GameInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int index { get; set; }
        [Key]
        public string id { get; set; }
        public bool rated { get; set; }
        public string variant { get; set; }
        public string speed { get; set; }
        public string perf { get; set; }
        public long createdAt { get; set; }
        public int turns { get; set; }
        public string status { get; set; }
        public int clockInitial { get; set; }
        public int clockIncrement { get; set; }
        public int clockTotalTime { get; set; }
        public int? raitingWhite { get; set; }
        public string idWhite { get; set; }
        public int? raitingBlack { get; set; }
        public string idBlack { get; set; }
        public string moves { get; set; }
        public string winner { get; set; }
        public string url { get; set; }
        public DateTime timeCreated { get; set; }

    }
}