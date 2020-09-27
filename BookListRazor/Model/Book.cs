using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //This is for [key] and [required]

namespace BookListRazor.Model
{
    public class Book
    {
        [Key] //This helps in creating an ID value automatically
        public int Id { get; set; }

        [Required] //This makes the Name a required field
        public string Name { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        

    }
}

