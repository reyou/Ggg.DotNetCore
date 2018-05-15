using System;
using System.ComponentModel.DataAnnotations;

namespace TutoPoint.ViewModels
{
    public class EmployeeEditViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}