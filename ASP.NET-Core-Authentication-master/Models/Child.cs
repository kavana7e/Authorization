using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Authentication.Models
{
    public class Child
    {
        public int ID { get; set; }
        [StringLength(30, ErrorMessage = "Please enter your first name using 30 characters or less.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }=String.Empty;
        [Required]
        [StringLength(30, ErrorMessage = "Please enter your last name using 30 characters or less.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = String.Empty;
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        public ICollection<ParentChild> Parents { get; set; }=new List<ParentChild>();

    }
}
