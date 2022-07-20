using System;
using System.ComponentModel.DataAnnotations;

namespace todo_asp_mvc.Models
{
    public class Todo
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }
}
