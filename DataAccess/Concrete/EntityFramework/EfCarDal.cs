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
    public class EfCarDal : EfEntityRepositoryBase<Car, Car_DbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (Car_DbContext context=new Car_DbContext())
            {
                //CarName, BrandName, ColorName, DailyPrice
                var result = from car in context.Cars
                    join b in context.Brands on car.BrandId equals b.BrandId
                    join c in context.Colors on car.ColorId equals c.ColorId
                    select new CarDetailDto
                    {
                        CarName = car.Description,
                        BrandName = b.BrandName,
                        ColorName = c.ColorName,
                        DailyPrice = car.DailyPrice
                    };
                return result.ToList();
            }
        }
    }
}
