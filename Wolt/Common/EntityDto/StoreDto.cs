using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityDto
{
    public class StoreDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public string Password { get; set; }
    }
}
