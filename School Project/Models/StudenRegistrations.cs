using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_Project.Models
{
    public class StudenRegistrations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RegistrationId { get; set; }

        public int Studentid { get; set; }
        public Student student { get; set; }

        public int Courseid { get; set; }
        public Course course { get; set; }
    }
}
