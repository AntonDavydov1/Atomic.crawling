using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Chess.Atomic.Crawling.Models
{
    public class UpdatesInfo
    {
        [Key]
        public string playerName { get; set; }

        [DataType(DataType.Date)]
        public DateTime lastUpdate { get; set; }
    }
}