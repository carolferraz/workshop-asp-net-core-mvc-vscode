using SalesWebMvc.Models;

namespace SalesWebMvc.Services;

public class SellerService
{
    private readonly SalesWebMvcContext _context; //SalesWebMvcContext is our connection to DB by DbContext. So SellerService Get the information from DB and will be connected to Insert/Update/Delete data in DB by SalesWebMvcContext.

    public SellerService(SalesWebMvcContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller obj)
    {
        obj.Department = _context.Department.First();
        _context.Add(obj);
        _context.SaveChanges();
    }

}
