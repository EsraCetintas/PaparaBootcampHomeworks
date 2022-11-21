using GenericRepositoryDemo.Data.Abstract;
using GenericRepositoryDemo.Data.Context;
using GenericRepositoryDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepositoryDemo.Data.Concrete.EntityFramework
{
   public class EfOrderDal : RepositoryBase<Order, AppDbContext>, IOrderDal
    {
        public EfOrderDal():base(new AppDbContext())
        {

        }
    }
}
