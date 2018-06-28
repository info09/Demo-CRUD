using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Demo2.Model
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students{ get; set; }
    }
}
