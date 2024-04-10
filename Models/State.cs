using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMPTodoListBcknd.Models
{
    public class State
    {
        [Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [ForeignKey("Task")]
        public int StateId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime DateRegistered { get; set; }
        
    }
}