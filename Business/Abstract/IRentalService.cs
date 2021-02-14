using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Upate(Rental rental);
        IResult Delete(Rental rental);

        IDataResult<List<Rental>> GetAll();
        IDataResult<Rental> GetById(int id);
        //bool IsReturn(int id);
        IResult IsCarAvailable(int carId);
    }
}
