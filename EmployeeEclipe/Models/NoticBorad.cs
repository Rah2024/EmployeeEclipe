#nullable disable
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeEclipe.Models
{
    public class NoticBorad
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Notice Name ")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Notice Description ")]

        public string Description { get; set; }
        [Display(Name = "Notice Upload file ")]

        public DateTime NoticDate { get; set; }
        public string UploadFile { get; set; }

        [NotMapped]

        public IFormFile UploadName { get; set; }
    }
}
