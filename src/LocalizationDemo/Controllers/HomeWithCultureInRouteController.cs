using LocalizationDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;


namespace LocalizationDemo.Controllers
{
    //
    // This doesn't work.
    //
    //[ServiceFilter(typeof(LanguageActionFilter))]
    //[Route("{culture}/[controller]")]
    public class HomeWithCultureInRouteController : Controller
    {
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly IHtmlLocalizer<HomeController> _htmlLocalizer;
        private readonly IHtmlLocalizer<SharedResource> _sharedHtmlLocalizer;

        public HomeWithCultureInRouteController(IStringLocalizer<HomeController> localizer, IHtmlLocalizer<HomeController> htmlLocalizer, IHtmlLocalizer<SharedResource> sharedHtmlLocalizer)
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
            return View(student);
        }
    }
}
