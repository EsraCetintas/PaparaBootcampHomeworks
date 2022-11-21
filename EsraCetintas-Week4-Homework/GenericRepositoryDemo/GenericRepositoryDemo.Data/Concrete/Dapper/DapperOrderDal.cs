using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Data.Context;
using GenericRepositoryDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Concrete.Dapper
{
   public class DapperOrderDal : DapperRepositoryBase<Order>, IOrderDal
    {
        public DapperOrderDal():base("Orders",new DapperDbContext())
        {

        }
    }
}
