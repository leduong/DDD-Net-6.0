using System;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Task
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }

        [Required]
        public Priority Priority { get; set; }

        [FutureDate(ErrorMessage = "Due date must be a future date")]
        public DateTime DueDate { get; set; }
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date;
            if (DateTime.TryParse(value.ToString(), out date))
            {
                return date > DateTime.Now;
            }
            return false;
        }
    }
}
