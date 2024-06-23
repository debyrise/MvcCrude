using mvcEmployee.Models;

namespace mvcEmployee.Service
{
    public interface IEmployeeService
    {

        void CREATEEMPLOYEE(Employees model);
        IEnumerable<Employees> GetAllEmployee();
    }
}
