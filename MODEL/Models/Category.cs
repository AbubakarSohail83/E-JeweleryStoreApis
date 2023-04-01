using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.Models
{
    public class Category
    {
        public int id { get; set; }
        public string categoryName { get; set; }
        public DateTime? createdOn { get; set; }
        public int? createdBy { get; set; }
        public DateTime? modifiedOn { get; set; }
        public int? modifedBy { get; set; }
    }
}
