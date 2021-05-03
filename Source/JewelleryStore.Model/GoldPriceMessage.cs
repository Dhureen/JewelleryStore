using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryStore.Model
{
     public class GoldPriceMessage
    {
        public int WeightInGrams { get; set; }
        public int RatePerGram { get; set; }
        public int TotalPrice { get; set; }
    }
}
