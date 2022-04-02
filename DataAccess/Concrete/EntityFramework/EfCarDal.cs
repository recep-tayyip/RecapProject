using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, Rental_CarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (Rental_CarContext context=new Rental_CarContext())
            {
                //CarName, BrandName, ColorName, DailyPrice
                var result = from car in context.Cars
                    join b in context.Brands on car.BrandId equals b.Id
                    join c in context.Colors on car.ColorId equals c.Id
                    select new CarDetailDto
                    {
                        CarName = car.Description,
                        BrandName = b.Name,
                        ColorName = c.Name,
                        DailyPrice = car.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
