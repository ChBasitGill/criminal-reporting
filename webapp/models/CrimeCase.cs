using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace criminal.reporting.models
{
    public class CrimeCase
    {
        public int Id{ get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name should be 1-50 characters")]
        public string Name{ get; set; }
        public string Address{ get; set; }
        public string Gender{ get; set; }
        public int Age{ get; set; }
        public string CrimeInfo{ get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Of Crime")]
        public DateTime DateOfCrime{ get; set; }
        public string Contact{ get; set; }
        [Display(Name = "Case Images")]
        public string CaseImages{ get; set; }
    }
    public class CrimeCaseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string CrimeInfo { get; set; }
        [DataType(DataType.Date)]   
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string Contact { get; set; }
        public string CaseImages { get; set; }
        public IEnumerable<HttpPostedFileBase> ImageFile { get; set; }
    }
}