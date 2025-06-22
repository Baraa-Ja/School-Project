using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace School_Project.Models
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Roomid { get; set; }

        [MinLength(3)]
        [MaxLength(50)]
        public string RoomName { get; set; }

    }
}
