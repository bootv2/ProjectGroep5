using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWinkelGroep5.Models
{
    public class WinkelmandModel
    {
        public WinkelmandModel()
        {
            items = new List<WinkelmandItemModel>();
        }
        public List<WinkelmandItemModel> items{get;set;}
    }
}