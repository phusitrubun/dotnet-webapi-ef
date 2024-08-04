using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.DTOs.Meeting;
using dotnet_webapi_ef.Models;

namespace dotnet_webapi_ef.Mappers
{
    public static class MeetingMapper
    {
        //method to map from DTO => Model ( clinet => api)
        public static Meeting ToMeeting(this MeetingDTO meeting){
            return new Meeting{
                Idx = meeting.Idx,
                Detail = meeting.Detail,
                Meetingdatetime = meeting.Meetingdatetime,
                Latitude = meeting.Latitude,
                Longitude = meeting.Longitude
            };
        }

        public static MeetingDTO ToMeetingDTO(this Meeting meeting){
            return new MeetingDTO{
                Idx = meeting.Idx,
                Detail = meeting.Detail,
                Meetingdatetime = meeting.Meetingdatetime,
                Latitude = meeting.Latitude,
                Longitude = meeting.Longitude
            };
        }
    }
}