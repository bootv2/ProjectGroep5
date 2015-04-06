using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWinkelGroep5.Models
{
    public class BestellingModel
    {
        public int bestellingId = -1;
        public int userId = -1;
        public BestellingModel()
        {
            items = new List<WinkelmandItemModel>();
        }

        public void fromWinkelmandModel(WinkelmandModel model)
        {
            if(items != null)
                items = model.items;
        }

        public List<WinkelmandItemModel> items{get;set;}


            public string From { get; set; }
            public string To { get; set; }
            public string Subject { get; set; }
            public string Body { get; set; }

    }
}