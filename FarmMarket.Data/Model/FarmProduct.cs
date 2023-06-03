using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmMarket.Data.Model
{
    public class FarmProduct : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        public int Amount { get; set; }

    }
}
