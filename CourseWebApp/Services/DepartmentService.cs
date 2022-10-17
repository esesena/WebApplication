using CourseWebApp.Data;
using CourseWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CourseWebApp.Services;
public class DepartmentService
{
    private readonly CourseWebAppContext _context;
    public DepartmentService(CourseWebAppContext context)
    {
        _context = context;
    }

    public async Task<List<Department>> FindAllAsync()
    {
        return await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }
}
