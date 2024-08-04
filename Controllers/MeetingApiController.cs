using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.Data;
using dotnet_webapi_ef.DTOs.Meeting;
using dotnet_webapi_ef.Mappers;
using dotnet_webapi_ef.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_webapi_ef.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetingApiController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public MeetingApiController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var meet = _context.Meetings;
            return Ok(meet);
        }

        [HttpGet("{id}")]
        public IActionResult GetMeetid([FromRoute] int id)
        {
            var meet = _context.Meetings.Find(id);
            if (meet == null)
            {
                return NotFound();
            }
            return Ok(meet);
        }

        [HttpPost]
        public IActionResult InsertMeeting([FromBody] MeetingDTO meetingDTO)
        {
            Meeting meeting = meetingDTO.ToMeeting();
            _context.Meetings.Add(meeting);
            int affect = _context.SaveChanges();

            if (affect > 0)
            {
                return CreatedAtAction(nameof(GetMeetid), new { id = meeting.Idx }, meeting.ToMeetingDTO());
            }
            return StatusCode(400);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeeting([FromRoute] int id)
        {
            Meeting meeting = _context.Meetings.Find(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
                int affect = _context.SaveChanges();
                if (affect > 0)
                {
                    return Ok();
                }
            }
            return StatusCode(400);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeeting([FromRoute] int id, [FromBody] MeetingDTO meetingDTO)
        {
            Meeting meeting = _context.Meetings.Find(id);
            if (meeting != null)
            {
                meeting.Detail = meetingDTO.Detail;
                meeting.Meetingdatetime = meetingDTO.Meetingdatetime;
                meeting.Latitude = meetingDTO.Latitude;
                meeting.Longitude = meetingDTO.Longitude;

                _context.Meetings.Update(meeting);
                int affect = _context.SaveChanges();
                if (affect > 0)
                {
                    return Accepted(meeting.ToMeetingDTO());
                }
            }
            return StatusCode(400);
        }
    }
}