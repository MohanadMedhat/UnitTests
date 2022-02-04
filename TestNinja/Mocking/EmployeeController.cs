using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private readonly IEmployeeStorage _storage;
        private readonly IEmployeeRedirect _redirect;
        

        public EmployeeController(IEmployeeStorage storage, IEmployeeRedirect redirect)
        {
            _storage = storage;
            _redirect = redirect;
        }

        public ActionResult DeleteEmployee(int id)
        {
           _storage.DeleteEmployee(id);
           
            return RedirectToAction("Employees");
        }

        public ActionResult RedirectToAction(string employees)
        {
           return _redirect.Redirect(employees);
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }
    
    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}