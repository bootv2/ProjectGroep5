using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebWinkelGroep5.Models
{
    public class BestellingModel
    {
        public BestellingModel()
        {
            items = new List<WinkelmandItemModel>();
        }

        public void fromWinkelmandModel(WinkelmandModel model)
        {
            items = model.items;
        }

        public List<WinkelmandItemModel> items{get;set;}
    }
}