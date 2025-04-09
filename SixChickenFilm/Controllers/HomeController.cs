using Microsoft.AspNetCore.Mvc;
using SixChickenFilm.Models;
using System.Diagnostics;
using SixChickenFilm.Models;


namespace SixChickenFilm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ListPhim()
        {
            return View();
        }
        public IActionResult Chitietphim(string ten)
        {
            // Dữ liệu giả
            var phim = new Phim
            {
                Id = 1,
                Ten = ten,
                MoTa = "Một bộ phim cực kỳ hấp dẫn!",
                DaoDien = "Dean DeBlois",
                DienVien = "Mason Thames, Nico Parker",
                TheLoai = "Hành động, Hài",
                KhoiChieu = new DateTime(2025, 6, 13),
                QuocGia = "Mỹ",
                Poster = "/image/ADL-poster-doc.jpg",
                Trailer = "https://img.youtube.com/vi/GOeKx7L8yyk/maxresdefault.jpg"
            };

            var suatChieus = new List<SuatChieu>
    {
        new SuatChieu { Id = 1, GioChieu = DateTime.Today.AddHours(19.5), DinhDang = "2D Phụ Đề", Rap = "CGV", DiaDiem = "Vincom", PhimId = 1 },
        new SuatChieu { Id = 2, GioChieu = DateTime.Today.AddHours(22.25), DinhDang = "2D Phụ Đề", Rap = "Lotte", DiaDiem = "Landmark", PhimId = 1 }
    };

            var viewModel = new PhimChiTietViewModel
            {
                Phim = phim,
                SuatChieus = suatChieus
            };

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
