using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_Project.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Courseid { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string CourseName { get; set; }
        public int TeacherID { get; set; }
        public Teacher Teacher { get; set; }

        [Range(0, 25)]
        public int RoomCapacity { get; set; }
    }
}
