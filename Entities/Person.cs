using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _23crbcyr.Entities
{
    /// <summary>
    /// table person
    /// </summary>
    [Table("person")]
    public class Person
    {
        /// <summary>
        /// id and primary key of table. autoincrement.
        /// </summary>
        [Key]
        public int id
        {
            get; set;
        }

        /// <summary>
        /// chilean rut
        /// </summary>
        [Required]
        [StringLength(11, MinimumLength = 3, ErrorMessage = "Plase enter a rut in formar 11222333-K")]
        public string rut
        {
            get; set;
        }

        /// <summary>
        /// name of person
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Min lenght for name is 1 and max is 255 characters.")]
        public string name
        {
            get; set;
        }

        /// <summary>
        /// last name of person
        /// </summary>
        [Required]
        [StringLength(255, MinimumLength = 1, ErrorMessage = "Min lenght for lastname is 1 and max is 255 characters.")]
        public string lastName
        {
            get; set;
        }

        /// <summary>
        /// age of person
        /// </summary>
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid age")]
        public int age
        {
            get; set;
        }



    }
}
