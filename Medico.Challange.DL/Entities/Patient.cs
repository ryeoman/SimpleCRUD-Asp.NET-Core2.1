using System;
using System.Collections.Generic;
using System.Text;

namespace Medico.Challange.DL.Entities
{
    public class Patient: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PlaceOfBirth { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}
