using CourseWebApp.Data;
using CourseWebApp.Models;
using System.Linq;

namespace CourseWebApp.Services;
public class SellerService
{
    private readonly CourseWebAppContext _context;
    public SellerService(CourseWebAppContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }
}
