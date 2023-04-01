using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Models
{
    public class item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int? categoryId { get; set; }
        public int? createdBy { get; set; }
        public int? modifiedBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public DateTime? createdOn { get; set; }

        public string category { get; set; }
        public double? price{get;set;}

    }
}
