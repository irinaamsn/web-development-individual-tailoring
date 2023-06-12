 using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Gibrid.Models
{
    public class SignUpDetail
    {
        public int Id { get; set; }
        //public string? UserId { get; set; }
        //public User? user { get; set; }//who sign and login
        public int SpecialistId { get; set; }
        public virtual Specialist specialist { get; set; }//his sign
        public string SpecialistName { get; set; }
        public bool isDelete { get; set; }
        public bool isServiced { get; set; }
        public int TimeSignId { get; set; }
       // public virtual Time? Times { get; set; }
        public DateTime Time { get; set; }//
        public int SignUpId { get; set; }
        public SignUp? SignUp { get; set; }//his data
        public string UserId { get; set; }
        public virtual User User { get; set; }

    }
}
