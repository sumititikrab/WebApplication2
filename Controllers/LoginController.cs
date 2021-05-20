using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BussinessLogic;
using BussinessObject;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        private TransactionMaster transactionMaster = new TransactionMaster();
        // GET: Login
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "UserName,Password")] UserMaster userMaster)
        {
            try
            {
                string user= transactionMaster.UserLogin(userMaster);
                if (string.IsNullOrEmpty(user))
                {
                    ViewBag.SucessMessage = "Welcome "+user;
                    return View();
                }
                else
                {
                    ViewBag.SucessMessage = "Welcome sumit";
                    //ViewBag.ErrorMessage = "Please Check!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.ToString();
                return View();
            }
        }
    }
}