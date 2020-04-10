using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;

namespace MVC_initialize.Controllers
{
    public class ManageEmailsController : Controller
    {
        // GET: ManageEmails
        private DbProvider db;

        public ManageEmailsController()
        {db=new DbProvider();
            
        }
        public ActionResult ActivationEmail(string id)
        {
           

            return PartialView();
        }
        public ActionResult RecoveryPassword()
        {
            return PartialView();
        }
    }
}