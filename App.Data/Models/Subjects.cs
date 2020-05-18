using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Data.Models
{
    public class Subjects
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

    }
}
