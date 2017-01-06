using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.AspNetCore.Mvc.Localization;
using LocalizationDemo.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System;

namespace LocalizationDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;        
        private readonly IHtmlLocalizer<HomeController> _htmlLocalizer;
        private readonly IHtmlLocalizer<SharedResource> _sharedHtmlLocalizer;

        public HomeController(IStringLocalizer<HomeController> localizer, IHtmlLocalizer<HomeController> htmlLocalizer, IHtmlLocalizer<SharedResource> sharedHtmlLocalizer)
        {
            _localizer = localizer;
            _htmlLocalizer = htmlLocalizer;
            _sharedHtmlLocalizer = sharedHtmlLocalizer;
        }

        [HttpGet]
        public IActionResult Index()
        {
            Student student = new Student();
            ViewData["StringLocalizer"] = _localizer["String localizer"];
            ViewData["StringLocalizerWithParameter"] = _localizer["String localizer with parameter - {0}", "Parameter"];
            ViewData["HtmlLocalizer"] = _htmlLocalizer["<b>Test html localizer</b>"];
            ViewData["HtmlLocalizerWithParameter"] = _htmlLocalizer["<b>Test html localizer with parameter</b> <i>{0}</i>", "Parameter"];
            ViewData["SharedHtmlLocalizer"] = _sharedHtmlLocalizer["<b>Shared html localizer</b>"];
            ViewData["SharedHtmlLocalizerWithParameter"] = _sharedHtmlLocalizer["<b>Shared html localizer with paramter</b> <i>{0}</i>", "Parameter"];

            student.SelectedCulture = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            return View(student);
        }

        [HttpPost]
        public IActionResult Index(Student student)
        {
            ViewData["StringLocalizer"] = _localizer["String localizer"];
            ViewData["StringLocalizerWithParameter"] = _localizer["String localizer with parameter - {0}", "Parameter"];
            ViewData["HtmlLocalizer"] = _htmlLocalizer["<b>Test html localizer</b>"];
            ViewData["HtmlLocalizerWithParameter"] = _htmlLocalizer["<b>Test html localizer with parameter</b> <i>{0}</i>", "Parameter"];
            ViewData["SharedHtmlLocalizer"] = _sharedHtmlLocalizer["<b>Shared html localizer</b>"];
            ViewData["SharedHtmlLocalizerWithParameter"] = _sharedHtmlLocalizer["<b>Shared html localizer with paramter</b> <i>{0}</i>", "Parameter"];
            student.SelectedCulture = HttpContext.Request.Cookies[CookieRequestCultureProvider.DefaultCookieName];
            return View(student);
        }

        [HttpPost]
        public IActionResult SetCulture(string SelectedCulture)
        {
            //RequestCulture requestCulture = new RequestCulture(culture);
            //string cookieCulture = CookieRequestCultureProvider.MakeCookieValue(requestCulture);
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddDays(1);
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, SelectedCulture);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult TestViewLocalizer()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
