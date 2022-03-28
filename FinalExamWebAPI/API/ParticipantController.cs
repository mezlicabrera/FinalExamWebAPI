using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalExamWebAPI.Data;
using FinalExamWebAPI.Models;
using System.Linq;
using System;


namespace FinalExamWebAPI.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParticipantController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult PostParticipant(/*int ParticipantId,*/ string FirstName, string LastName, string Gender, DateTime BirthDate, string EmailAddress)
        {

            Participant participant = new Participant();

            
           // participant.ParticipantId = ParticipantId;
            participant.FirstName = FirstName;
            participant.LastName = LastName;
            participant.Gender = Gender;
            participant.BirthDate = BirthDate;
            participant.EmailAddress = EmailAddress;
            
            _context.Participants.Add(participant);
            _context.SaveChanges();

            return new JsonResult(participant);
        }

        // UPDATE > PUT
        // PUT /api/Participant/1
        [HttpPut("{ParticipantId}")]
        public IActionResult PutParticipant(int ParticipantId, Participant participant)
        {
            if (ParticipantId != participant.ParticipantId)
            {
                return BadRequest();
            }
         
            _context.Entry(participant).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
            
            return NoContent();
        }

        // DELETE > DELETE
        // DELETE /api/Participant/2
        [HttpDelete("{ParticipantId}")]
        public IActionResult DeleteParticipant(int ParticipantId)
        {
            var participant = _context.Participants.Find(ParticipantId);

            if (participant == null)
            {
                return NotFound();
            }

            _context.Participants.Remove(participant);

            _context.SaveChanges();

            return NoContent();
        }

        // GET ALL PARTICIPANTS
        public IActionResult GetPArticipants()
        {
            var participants = _context.Participants.OrderBy(p => p.FirstName).ToList();
            return new JsonResult(participants);
        }

        // GET SEARCH BY LAST NAME
        [Route("FilteredParticipantsLastName")]
        public IActionResult FilteredParticipantsLastName(string LastName)
        {
            var participantsLastName = _context.Participants.Where(p => p.LastName.Contains(LastName)).OrderBy(p => p.LastName).ToList();
            return new JsonResult(participantsLastName);
        }

        // GET SEARCH BY EMAIL ADDRESS
        [Route("FilteredParticipantsEmailAddress")]
        public IActionResult FilteredParticipantsEmailAddress(string EmailAddress)
        {
            var participantsEmailAddress = _context.Participants.Where(p => p.EmailAddress.Contains(EmailAddress)).OrderBy(p => p.EmailAddress).ToList();
            return new JsonResult(participantsEmailAddress);
        }

        // GET SEARCH BY BIRTH DATE
        [Route("FilteredParticipantsBirthDate")]
        public IActionResult FilteredParticipantsBirthDate(DateTime BirthDate)
        {
            var participantsBirthDate = _context.Participants.Where(p => p.BirthDate == BirthDate).OrderBy(p => p.BirthDate).ToList();
            return new JsonResult(participantsBirthDate);
        }

        // list of all participants by birth date
        [Route("ParticipantsByBirthDate")]
        public IActionResult GetParticipantsByBirthDate()
        {
            var participants = _context.Participants
                              .OrderBy(p => p.BirthDate)
                              .ToList();

           /* var participants = from p in _context.Participants
                         select p;*/

            return new JsonResult(participants);
        }

        // list of all participants by gender = "M"
        [Route("ParticipantsByGender")]
        public IActionResult GetParticipantsByGender()
        {
            var participants = _context.Participants
                                .Where(p => p.Gender.Contains("M"))
                                .OrderBy(p => p.Gender)
                                .ToList();

            return new JsonResult(participants);
        }

    }
}




