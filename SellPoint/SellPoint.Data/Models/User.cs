using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellPoint.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string UserNameEntidad { get; set; }
        [StringLength(30)]
        public string PasswordEntidad { get; set; }
    }
}
