using Reposiroty.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.EntityDto
{
    public class OrderDto
    {
        public int? Id { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public string OrderingName { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsTaken { get; set; }
        public bool IsDone { get; set; }

    }
}
