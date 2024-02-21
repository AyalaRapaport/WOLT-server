using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reposiroty.Entity
{
    public class Courier
    {
        public int Id { get; set; }
        public string IdCourier { get; set; }
        public bool IsActive { get; set; }
        public double XCoordinate { get; set; } 
        public double YCoordinate { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastShipment { get; set; }
    }
}
