using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService; //SellerService receive the data from the DB, in this case called SalesWebMvcContext. So this is a connecting (making a service) between View and DbContext.

    public SellersController(SellerService sellerService)
    {
        _sellerService = sellerService;
    }


    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
       _sellerService.Insert(seller);
       return RedirectToAction(nameof(Index));
    }

}
