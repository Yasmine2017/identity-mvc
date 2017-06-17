using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Identityyy.Models
{
    public partial class reg
    {
        [Key]
        public int id { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int noaccount { get; set; }
    }
}