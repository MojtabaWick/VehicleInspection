using System;
using System.Collections.Generic;
using System.Text;
using VehicleInspection.Domain.Core.ManufacturerAgg.Contracts;
using VehicleInspection.Domain.Core.ManufacturerAgg.Dtos;

namespace VehicleInspection.Domain.Service.AppServices.ManufacturerAgg
{
    public class ManufacturerAppService(IManufacturerService ManufacturerService) : IManufacturerAppService
    {
        public List<ManufacturerDto> GetManufacturer()
        {
            return ManufacturerService.GetManufacturersList();
        }
    }
}