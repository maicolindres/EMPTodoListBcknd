using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace EMPTodoListBcknd.Models
{
    public class Task
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
        public String Image { get; set; }
        // Foreign Key
        [Required]
        [ForeignKey("State")]
        public int StateId { get; set; }
        // Navigation property
        public virtual State? State { get; set; }
        // Foreign Key
        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        // Navigation property
        public virtual Category? Category { get; set; }
        // Foreign Key
        [Required]
        [ForeignKey("List")]
        public int ListId { get; set; }
        // Navigation property
        public virtual List? List { get; set; }
        [Required]
        public DateTime EndDate{ get; set; }
        [Required]
        public DateTime DateRegistered { get; set; }
        
    }
}