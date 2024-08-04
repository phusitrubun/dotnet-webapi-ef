using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.DTOs.Trip;
using dotnet_webapi_ef.Models;

namespace dotnet_webapi_ef.Mappers
{
    public static class TripMapper
    {
        //Method to map from model => DTO
        public static TripDTO ToTripDTO(this Trip trip)
        {
            return new TripDTO
            {
                Idx = trip.Idx,
                Name = trip.Name,
                Country = trip.Country,
                Destinationid = trip.Destinationid,
                Price = trip.Price,
                Duration = trip.Duration,
                Coverimage = trip.Coverimage,
                Detail = trip.Detail,
                Destination = trip.Destination.ToDesDTO()
            };
        }
    }
}