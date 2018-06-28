using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Demo2.Model
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        [ForeignKey("ClassId")]
        public virtual Class Classes{ get; set; }
    }
}
