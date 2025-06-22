using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_Project.Models
{
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Teacherid { get; set; }

        [MinLength(5)]
        [MaxLength(50)]
        public string TeacherName { get; set; }

        [Range(22, 70)]
        public int TeacherAge { get; set; }
    }
}
