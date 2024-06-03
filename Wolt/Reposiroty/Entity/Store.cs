using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiroty.Entity
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public string Password { get; set; }
        public string? UrlImage { get; set; }
        public virtual ICollection<Product>? ProductList{ get; set; }
    }
}
