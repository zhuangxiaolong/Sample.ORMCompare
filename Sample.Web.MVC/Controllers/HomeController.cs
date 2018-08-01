using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sample.Repository.Dapper;
using Sample.Repository.EF.Models;
using Sample.Repositoy.Interface;
using Sample.Web.MVC.Models;

namespace Sample.Web.MVC.Controllers
{
    public class HomeController : Controller
    {
        private IMusicRepository _musicRepository;
        private IUserRepository _userRepository;

        private IMusicRepository_ADONET _musicRepository_adonet;
        private IUserRepository_ADONET _userRepository_ADONET;

        private MusicStoreContext _efContext;
        public HomeController(
            IMusicRepository musicRepository,
            IUserRepository userRepository,
            IMusicRepository_ADONET musicRepository_adonet,
            IUserRepository_ADONET userRepository_ADONET,
            MusicStoreContext efContext)
        {
            _musicRepository = musicRepository;
            _userRepository = userRepository;

            _musicRepository_adonet = musicRepository_adonet;
            _userRepository_ADONET = userRepository_ADONET;

            _efContext = efContext;
        }

        public IActionResult Index()
        {
            var tryNum = 500;
            ViewData["tryNum"] = tryNum;
            //dapper
            var startTime = DateTime.Now;
            ViewData["startTime_dapper"] = startTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
            for (int i = 0; i < tryNum; i++)
            {
                var lst = _userRepository.List();
                ViewData["dataNum_dapper"] = lst.Count();
            }
            var endTime = DateTime.Now;
            ViewData["endTime_dapper"] = endTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
            TimeSpan ts = endTime - startTime;
            ViewData["spentTime_dapper"] = string.Format("{0} Minutes {1} Seconds {2} Milliseconds", ts.Minutes, ts.Seconds, ts.Milliseconds);

            //ado.net
            var startTime2 = DateTime.Now;
            ViewData["startTime_adonet"] = startTime2.ToString("yyyy-MM-dd HH:mm:ss:fff");
            for (int i = 0; i < tryNum; i++)
            {
                var lst2 = _userRepository_ADONET.List();
                ViewData["dataNum_adonet"] = lst2.Count();
            }
            var endTime2 = DateTime.Now;
            ViewData["endTime_adonet"] = endTime2.ToString("yyyy-MM-dd HH:mm:ss:fff");
            var ts2 = endTime2 - startTime2;
            ViewData["spentTime_adonet"] = string.Format("{0} Minutes {1} Seconds {2} Milliseconds", ts2.Minutes, ts2.Seconds, ts2.Milliseconds);

            //ef
            var startTime3 = DateTime.Now;
            ViewData["startTime_ef"] = startTime3.ToString("yyyy-MM-dd HH:mm:ss:fff");
            for (int i = 0; i < tryNum; i++)
            {
                var lst3 = _efContext.TUser.ToList();
                ViewData["dataNum_ef"] = lst3.Count();
            }
            var endTime3 = DateTime.Now;
            ViewData["endTime_ef"] = endTime3.ToString("yyyy-MM-dd HH:mm:ss:fff");
            var ts3 = endTime3 - startTime3;
            ViewData["spentTime_ef"] = string.Format("{0} Minutes {1} Seconds {2} Milliseconds", ts3.Minutes, ts3.Seconds, ts3.Milliseconds);

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {


            var tryNum = 10;
            ViewData["tryNum"] = tryNum;
            //dapper
            var startTime = DateTime.Now;
            ViewData["startTime_dapper"] = startTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
            for (int i = 0; i < tryNum; i++)
            {
                var lst = _musicRepository.List();
                ViewData["dataNum_dapper"] = lst.Count();
            }
            var endTime = DateTime.Now;
            ViewData["endTime_dapper"] = endTime.ToString("yyyy-MM-dd HH:mm:ss:fff");
            TimeSpan ts = endTime - startTime;
            ViewData["spentTime_dapper"] = string.Format("{0} Seconds {1} Milliseconds", ts.Seconds, ts.Milliseconds);

            //ado.net
            var startTime2 = DateTime.Now;
            ViewData["startTime_adonet"] = startTime2.ToString("yyyy-MM-dd HH:mm:ss:fff");
            for (int i = 0; i < tryNum; i++)
            {
                var lst2 = _musicRepository_adonet.List();
                ViewData["dataNum_adonet"] = lst2.Count();
            }
            var endTime2 = DateTime.Now;
            ViewData["endTime_adonet"] = endTime2.ToString("yyyy-MM-dd HH:mm:ss:fff");
            var ts2 = endTime2 - startTime2;
            ViewData["spentTime_adonet"] = string.Format("{0} Seconds {1} Milliseconds", ts2.Seconds, ts2.Milliseconds);

            //ef
            var startTime3 = DateTime.Now;
            ViewData["startTime_ef"] = startTime3.ToString("yyyy-MM-dd HH:mm:ss:fff");
            for (int i = 0; i < tryNum; i++)
            {
                var lst3 = _efContext.TMusic.ToList();
                ViewData["dataNum_ef"] = lst3.Count();
            }
            var endTime3 = DateTime.Now;
            ViewData["endTime_ef"] = endTime3.ToString("yyyy-MM-dd HH:mm:ss:fff");
            var ts3 = endTime3 - startTime3;
            ViewData["spentTime_ef"] = string.Format("{0} Seconds {1} Milliseconds", ts3.Seconds, ts3.Milliseconds);

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
}
