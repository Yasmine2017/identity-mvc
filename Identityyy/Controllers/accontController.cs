using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Identityyy.Models;
using System.Security.Claims;

namespace Identityyy.Controllers
{
    [AllowAnonymous]
    public class accontController : Controller
    {
        mainDBcontect context = new mainDBcontect();
        // GET: accont
        [HttpGet]
        [HandleError(View = "Error")]
        
        public ActionResult register()
        {
            return View();
        }
        public ActionResult register(reg user)
        {
            if(ModelState.IsValid)
            {
                context.regs.Add(user);
                context.SaveChanges();
                var identity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Name,user.fullname),
                    new Claim("password",user.password)
                }, "ApplicationCookie");
                var ctx = Request.GetOwinContext();
                var autTh = ctx.Authentication;
                autTh.SignIn(identity);
                return RedirectToAction("Index", "booklist");
            }
            return View();
        }
        [HttpGet]

        public ActionResult login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult login(reg model)
        {
           // if(ModelState.IsValid)
            //{
                var query = from sure in context.regs
                            where sure.password == model.password
                            select sure;
                if(query!=null)
                {
                    var identity = new ClaimsIdentity(new List<Claim>()
                    {
                        new Claim(ClaimTypes.Name,model.fullname),
                        new Claim("password",model.password)
                    }, "ApplicationCookie");
                    var ctx = Request.GetOwinContext();
                    var auth = ctx.Authentication;
                    auth.SignIn(identity);
                    return RedirectToAction("Index", "booklist");
                }
                return View();
            //}else
            //return View();
        }
        public ActionResult logout()
        {
            var ctx = Request.GetOwinContext();
            var autTh = ctx.Authentication;
            autTh.SignOut("ApplicationCookie");
            return RedirectToAction("login");
        }
    }
}