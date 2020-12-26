using System.ComponentModel.DataAnnotations;

namespace criminal.reporting.models
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        [Required(AllowEmptyStrings =false,ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Location is required")]
        public string Location { get; set; }
        [Display(Name = "Contact Information")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Contact Information is required")]
        public string ContactInfo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mail Address is required")]
        [Display(Name = "Mail Address")]
        public string MailAddress { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Station Boundries is required")]
        [Display(Name = "Station Boundries")]
        public string StationBoundries { get; set; }
    }
}