using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _23crbcyr.Entities
{
    [Table("person")]
    public class Person
    {
        [Key]
        public int id
        {
            get; set;
        }
        public string rut
        {
            get; set;
        }

        public string name
        {
            get; set;
        }

        public string lastName
        {
            get; set;
        }

        public int age
        {
            get; set;
        }

    }
}
