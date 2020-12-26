using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webapp
{
    public class StationDto
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50,ErrorMessage ="Name should be 1-50 characters"),MinLength(1)]
        public string Name { get; set; }
        [StringLength(100, ErrorMessage = "Location should be 1-100 characters"), MinLength(1)]
        public string Location { get; set; }
        public string ContactInfo { get; set; }
        public string MailAddress { get; set; }
        public string StationBoundries { get; set; }
    }
}