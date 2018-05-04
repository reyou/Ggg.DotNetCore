using System;
using System.ComponentModel.DataAnnotations;

namespace TutoPoint.Models
{
    /// <summary>
    /// https://stackoverflow.com/questions/11173562/entity-framework-error-cannot-insert-explicit-value-for-identity-column-in-tabl
    /// </summary>
    public partial class Employee
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
