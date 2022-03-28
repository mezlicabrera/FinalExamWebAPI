using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FinalExamWebAPI.Models
{
    public class Participant
    {
        [Key]
        public int ParticipantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public string EmailAddress { get; set; }

    }
}

