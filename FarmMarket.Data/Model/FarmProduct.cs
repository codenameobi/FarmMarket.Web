using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmMarket.Data.Model
{
    [Table("farmproducts")]
    [Index(nameof(Name), IsUnique = true)]
    public class FarmProduct : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Unit { get; set; }
        public int Amount { get; set; }

    }
}
