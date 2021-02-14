using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectDbContext>, IRentalDal
    {
        public bool IsCarAvailable(int carId)
        {
            using( ReCapProjectDbContext context = new ReCapProjectDbContext()  )
            {
                var result = context.Rentals.SingleOrDefault(c => c.CarId == carId );
                if (result != null)
                {
                    return result.ReturnDate == null ? false : true;
                }                    
                else return true;
            }
        }
    }
}
