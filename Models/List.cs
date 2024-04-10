using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMPTodoListBcknd.Models
{
    public class List
    {
       
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [ForeignKey("Task")]
        public int ListId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        // Foreign Key
        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        // Navigation property
        public virtual User? User { get; set; } 
        [Required]
        public DateTime DateRegistered { get; set; }
    }
}