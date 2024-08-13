using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Server.Domain
{
     public abstract class BaseEntity
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "Requred field")]
        [MaxLength(100), MinLength(1,ErrorMessage ="Lenqth 2 - 100")]
        public string Name { get; set; }
    }
}
