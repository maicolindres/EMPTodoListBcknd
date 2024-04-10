
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMPTodoListBcknd.Models

{
    public class User
    {
        [Key]
       // [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        [ForeignKey("List")]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Password { get; set; }
        [Required]
        public DateTime DateRegistered { get; set; }
        
    }
}