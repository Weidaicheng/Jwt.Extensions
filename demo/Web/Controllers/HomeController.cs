using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using JWT;
using JWT.Extensions.Entity;
using JWT.Extensions.Utility;
using Microsoft.AspNetCore.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public const string secret = "abcde";
        private readonly IJwtEncoder _jwtEncoder;
        private readonly IJwtDecoder _jwtDecoder;

        public HomeController(IJwtEncoder jwtEncoder, IJwtDecoder jwtDecoder)
        {
            _jwtEncoder = jwtEncoder;
            _jwtDecoder = jwtDecoder;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        /// <summary>
        /// Get token
        /// </summary>
        /// <returns></returns>
        public IActionResult GetToken()
        {
            var timeStamp = UtilityHelper.GetTimeStamp();
            var payload = new Payload()
            {
                exp = timeStamp + 60
            };

            //encode
            var token = _jwtEncoder.Encode(payload, secret);
            return Content(token);
        }

        /// <summary>
        /// verify token
        /// </summary>
        /// <param name="jwt"></param>
        /// <returns></returns>
        public IActionResult TokenVerify(string jwt)
        {
            try
            {
                //decode
                var json = _jwtDecoder.Decode(jwt, secret, true);
                return Content(json);
            }
            catch(Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
