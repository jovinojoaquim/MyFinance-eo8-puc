using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_netcore.Infrastructure;
using myfinance_web_netcore.Models;

namespace myfinance_web_netcore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MyFinanceDBContext _banco;

    public HomeController(ILogger<HomeController> logger, MyFinanceDBContext banco)
    {
        _logger = logger;
        _banco = banco;
    }

    public IActionResult Index()
    {
        var nomePrimeiroItemPlanoConta = _banco.PlanoConta.FirstOrDefault().Nome;
        ViewBag.Teste = nomePrimeiroItemPlanoConta;
        return View();
    }

    public IActionResult PUC()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
