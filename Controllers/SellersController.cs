using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Models.ViewModel;
using SalesWebMvc.Services;

namespace SalesWebMvc.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService; //SellerService receive the data from the DB, in this case called SalesWebMvcContext. So this is a connecting (making a service) between View and DbContext.
    private readonly DepartmentService _departmentService; //To create an option to select the department a seller is from.

    public SellersController(SellerService sellerService, DepartmentService departmentService)
    {
        _sellerService = sellerService;
        _departmentService = departmentService;
    }


    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }

    public IActionResult Create()
    {
        var departments = _departmentService.FindAll(); //Find all the departments from the DB.
        var viewModel = new SellerFormViewModel { Departments = departments }; //Pass the data from DB to the list created on the SellerFormViewModel instatiating it.
        return View(viewModel); //Show in the page.
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
       _sellerService.Insert(seller);
       return RedirectToAction(nameof(Index));
    }



}
