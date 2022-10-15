using CourseWebApp.Data;
using CourseWebApp.Models;
using System.Linq;

namespace CourseWebApp.Services;
public class DepartmentService
{
    private readonly CourseWebAppContext _context;
    public DepartmentService(CourseWebAppContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }
}
