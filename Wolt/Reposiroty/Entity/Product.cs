using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiroty.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category ? Category { get; set; }
        public int? StoreId { get; set; }
        [ForeignKey("StoreId")]
        public virtual Store ? Store { get; set; }
        public string UrlImage { get; set; }
        public virtual ICollection<Order> Orders { get; set; }


    }
}
