using OA_DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OA_Service.ViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }
        [Required, MinLength(10, ErrorMessage = "Address Must be at least 10 Characters")]
        public string DetailsOfAddress { get; set; }
        public int Person_Id { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
    }
}
