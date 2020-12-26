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
        [Required(AllowEmptyStrings = false, ErrorMessage = "CNIC is required")]
        public string CNIC{ get; set; }
        public string Address{ get; set; }
        public string Gender{ get; set; }
        [Range(1,120)]
        public int Age{ get; set; }
        [Display(Name = "Crime Info")]
        public string CrimeInfo{ get; set; }
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Of Crime")]
        public DateTime DateOfCrime{ get; set; }
        public string Contact{ get; set; }
        [Display(Name = "Case Images")]
        public string CaseImages{ get; set; }

        public int StationId { get; set; }
        public Station Station { get; set; }
    }
    public class CrimeCaseDto
    {
        public int Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "CNIC is required")]
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        [Range(1, 120)]
        public int Age { get; set; }
        [Display(Name = "Crime Info")]
        public string CrimeInfo { get; set; }
        [DataType(DataType.Date)]   
        public DateTime Date { get; set; }
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
        public string Contact { get; set; }
        [Display(Name = "Case Images")]
        public string CaseImages { get; set; }
        public int StationId { get; set; }
        public IEnumerable<HttpPostedFileBase> ImageFile { get; set; }
    }
}