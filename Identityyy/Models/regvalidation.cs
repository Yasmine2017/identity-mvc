using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identityyy.Models
{
    [MetadataType(typeof(regvalidation))]

    public partial class reg
    {
    }
   
    public class regvalidation
    {
        [Required(ErrorMessage = "*")]
        public string fullname { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        [StringLength(maximumLength: 10, MinimumLength = 5, ErrorMessage = "length between 5 to 10")]
        public string password { get; set; }
        [Required(ErrorMessage = "*")]


        public int noaccount { get; set; }
    }
}