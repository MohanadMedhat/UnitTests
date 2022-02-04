using TestNinja.Mocking;

namespace TestNinja.Mocking
{
    public interface IEmployeeRedirect
    {
        ActionResult Redirect(string employee);
    }

    public class EmployeeRedirect : IEmployeeRedirect
    {
        private RedirectResult _re;

        public EmployeeRedirect()
        {
            _re = new RedirectResult();
        }
        public ActionResult Redirect(string employee)
        {
            return new RedirectResult();
        }
    }
}