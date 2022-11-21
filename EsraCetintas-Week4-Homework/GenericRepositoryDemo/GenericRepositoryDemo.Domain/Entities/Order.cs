using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string OrderedBy { get; set; }
        public decimal OrderPrice { get; set; }
        public string Adress { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
