using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JewelleryStore.Model
{
     public class ComputeGoldPriceMessage
    {
        public int WeightInGrams { get; set; }
        public int RatePerGram { get; set; }
    }
}
