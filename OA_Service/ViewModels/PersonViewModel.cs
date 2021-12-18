using Microsoft.AspNetCore.Http;
using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class PersonViewModel
    {
        public int ID { get; set; }
        [Required, MinLength(5,ErrorMessage = "Name Must be at least 5 Characters")]
        public string Name { get; set; }
        [Required, MinLength(5, ErrorMessage = "FamilyName Must be at least 5 Characters")]
        public string FamilyName { get; set; }

        [Required, DataType(DataType.EmailAddress)]
        public string EMailAdress { get; set; }

        [Required, Range(20, 60, ErrorMessage = "The Age is must be between 20 and 60")]
        public int Age { get; set; }
        //[JsonIgnore]
        public virtual List<Address> Addresses { get; set; }

    }
}
