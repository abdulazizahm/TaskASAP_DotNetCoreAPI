
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA_DAL.Models
{
    public enum Role_Name { Admin,User }
    public enum User_Status { InActive, Active, Declined, Block }
    public class ApplicationUser:IdentityUser
    {
        public ApplicationUser()
        {
            Created_at = DateTime.Now;
        }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [MaxLength(20)]
        public string LastName { get; set; }

        public string Address { get; set; }
        public bool IsActive { get; set; }

        public User_Status User_Status { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Created_at = DateTime.Now;
        public string Photo { get; set; }

        //[Required]
        [StringLength(14)]
        public string SSN { get; set; }

        public virtual List<Person> Applicants { get; set; } // make Applicant (Hired)

    }
}
