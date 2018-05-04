using System;
using System.Collections.Generic;
using System.Linq;
using TutoPoint.Models;

namespace TutoPoint.Repositories
{
    // ReSharper disable once InconsistentNaming
    public class SQLEmployeeData
    {
        private FirstAppDemoDbContext _context { get; }
        public SQLEmployeeData(FirstAppDemoDbContext context)
        {
            _context = context;
        }
        public void Add(Employee emp)
        {
            if (emp.Id == default(Guid))
            {
                emp.Id = Guid.NewGuid();
            }
            _context.Add(emp);
            _context.SaveChanges();
        }
        public Employee Get(Guid id)
        {
            Employee firstOrDefault = _context.Employee.FirstOrDefault(e => e.Id == id);
            return firstOrDefault;
        }
        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employees = _context.Employee.ToList();
            return employees;
        }
    }
}
