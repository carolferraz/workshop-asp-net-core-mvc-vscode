using SalesWebMvc.Models;
namespace SalesWebMvc.Services;

public class DepartmentService
{
    private readonly SalesWebMvcContext _context; //SalesWebMvcContext is our connection to DB by DbContext. So SellerService Get the information from DB and will be connected to Insert/Update/Delete data in DB by SalesWebMvcContext.

    public DepartmentService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy( item => item.Name ).ToList();
    }

}