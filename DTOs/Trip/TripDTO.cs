using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.DTOs.Destinations;
using dotnet_webapi_ef.Models;

namespace dotnet_webapi_ef.DTOs.Trip
{
    public class TripDTO
    {
        //DTO => โครงสร้างข้อมูลที่จะใช้ตอนรับเข้ากับส่งออกไปจาก WebAPI

        public int Idx { get; set; }
        public string Name { get; set; } = null!;
        public string Country { get; set; } = null!;
        public int Destinationid { get; set; }
        public string Coverimage { get; set; } = null!;
        public string Detail { get; set; } = null!;
        public int Price { get; set; }
        public int Duration { get; set; }
    //     public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public virtual DestinationDTO Destination { get; set; } = null!;
    }
}