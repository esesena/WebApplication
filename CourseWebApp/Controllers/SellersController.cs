using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CourseWebApp.Data;
using CourseWebApp.Models;
using CourseWebApp.Services;

namespace CourseWebApp.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;

    public SellersController(SellerService sellerService)
    {
        _sellerService = sellerService;
    }

    // GET: Sellers
    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }
}