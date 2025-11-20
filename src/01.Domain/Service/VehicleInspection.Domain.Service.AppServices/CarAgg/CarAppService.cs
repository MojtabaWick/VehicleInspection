using System;
using System.Collections.Generic;
using System.Text;
using VehicleInspection.Domain.Core.CarAgg.Contracts;
using VehicleInspection.Domain.Core.CarAgg.Dtos;

namespace VehicleInspection.Domain.Service.AppServices.CarAgg
{
    public class CarAppService(ICarService carService) : ICarAppService
    {
        public List<CarDto> GetCarList(int manufacturerId)
        {
            return carService.GetManufacturerCarList(manufacturerId);
        }
    }
}