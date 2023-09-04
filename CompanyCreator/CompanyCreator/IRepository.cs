using TaskEmployee = CompanyCreator.Task.Employee;
using SolutionEmployee = CompanyCreator.Solution.Employee;

namespace CompanyCreator;

public interface IRepository
{
    public System.Threading.Tasks.Task SaveEmployees(List<TaskEmployee> employees);
    public System.Threading.Tasks.Task SaveEmployees(List<SolutionEmployee> employees);
}