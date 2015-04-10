using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWinkelGroep5.Models
{
    public enum BestellingS
    { 
        Verwerkt, Ingepakt, Onderweg
    }
    
    public class BestellingStatus
    {
        public BestellingStatus bestellingStatus { get; set; }
        public int bestellingId { get; set; }
        public int userId { get; set; }

        public AccountModel user { get; set; }
    }
}