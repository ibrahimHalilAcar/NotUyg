using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Deneme.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Deneme.Controllers
{
    //[Route("[controller]")]
    public class NotController : Controller
    {
        private readonly ILogger<NotController> _logger;
        private readonly GVT gvt;

        public NotController(ILogger<NotController> logger, GVT gvt)
        {
            _logger = logger;
            this.gvt = gvt;
        }

        public IActionResult Index()
        {
            var a = gvt.Notlar.ToList();
            return View(a);
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Not p1)
        {
            gvt.Notlar.Add(p1);
            gvt.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Detay(int id)
        {
            var b = gvt.Notlar.SingleOrDefault(x => x.Id == id);
            return View(b);
        }

        [HttpGet]
        public IActionResult Duzenle(int id)
        {
            var Duzenle = gvt.Notlar.SingleOrDefault(x => x.Id == id);
            return View(Duzenle);
        }
        [HttpPost]
        public IActionResult Duzenle(Not y)
        {
           
            var Bul =gvt.Notlar.SingleOrDefault(x => x.Id==y.Id);
            Bul.Baslik = y.Baslik;
            Bul.Icerik = y.Icerik;
            gvt.SaveChanges();
           

            return RedirectToAction("Index");
        }

        public IActionResult Sil(int id)
        {
            var Sil = gvt.Notlar.SingleOrDefault(x => x.Id == id);
            if (Sil != null)
            {
                gvt.Notlar.Remove(Sil);
                gvt.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}