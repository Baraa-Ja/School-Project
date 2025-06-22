using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School_Project.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentid { get; set; }
        [MinLength(5)]
        [MaxLength(50)]
        public string StudentName { get; set; }
        public bool Isactive { get; set; }
        [Range(5,30)]
        public int age { get; set; }

        public string PhotoName { get; set; }
    }
}
