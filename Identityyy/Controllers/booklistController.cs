using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Identityyy.Models;
using Identityyy.VM;

namespace Identityyy.Controllers
{
    [Authorize]
    public class booklistController : Controller
    {
        bookEntities db = new bookEntities();

        // GET: booklist
        public ActionResult Index()
        {
            IEnumerable<listbook> b1 = from bb in db.listbook
                                       select bb;
            return View(b1.ToList<listbook>());
        }

        public ActionResult Borrowingbooks(int id)
        {
            bookajax selectbook = (from sb in db.listbook
                                   select new bookajax()
                                   {
                                       id = sb.id,
                                       namebook = sb.namebook,
                                       cover = sb.cover
                                   }).FirstOrDefault();
            List<bookajax> OrderList = new List<bookajax>();
            if (TempData["List1"] != null)
            {
                OrderList = (List<bookajax>)TempData["List1"];
            }
            OrderList.Add(selectbook);

            TempData["List1"] = OrderList;
            return PartialView("_GetORderList", OrderList);
        }
    }
}