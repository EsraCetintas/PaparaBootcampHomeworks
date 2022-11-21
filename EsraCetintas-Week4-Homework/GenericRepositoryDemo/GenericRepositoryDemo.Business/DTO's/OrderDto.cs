using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Business.DTO_s
{
    public class OrderDto
    {
        public decimal OrderPrice { get; set; }
        public string Adress { get; set; }
        public string OrderedBy { get; set; }
    }
}
