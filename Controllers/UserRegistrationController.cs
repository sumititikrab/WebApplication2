using BussinessObject;
using BussinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UserRegistrationController : Controller
    {
        private TransactionMaster transactionMaster = new TransactionMaster();

        // GET: UserRegistration
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "UserID,UserName,EmailId,Phone,Password,ConfirmPassword")] UserMaster userMaster)
        {
            try
            {
                if (ModelState.IsValid && userMaster.Password == userMaster.ConfirmPassword)
                {
                    userMaster.UserID = Guid.NewGuid();
                    transactionMaster.UserRegistration(userMaster);
                    ViewBag.SucessMessage = "Registration Sucessfully Done!";
                    return View();
                }
                else
                {
                    ViewBag.ErrorMessage = "Please Check!";
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