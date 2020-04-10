using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using DataLayer.Model;
using DataLayer.Repositories;
using DataLayer.Services;
using DataLayer.ViewModels;
using System.Web.Security;
using DataLayer.Context;
using Utilities;

namespace MVC_initialize.Controllers
{
    public class AccountController : Controller
    {
        private UnitOfWork db;

        public AccountController()
        {
            db=new UnitOfWork();
        }
        // GET: Account
        [Route("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register")]
        public ActionResult Register(RegisterViewModel register)
        {
            
            if (!db.AccountRepository.isExistEmail(register.Email) && !db.AccountRepository.isExitUserName(register.UserName))
            {
                Users user = new Users
                {
                    Email = register.Email.Trim().ToLower(),
                    Password = FormsAuthentication.HashPasswordForStoringInConfigFile(register.Password, "MD5"),
                    ActiveCode = Guid.NewGuid().ToString(),
                    IsActive = false,
                    RegisterDate = DateTime.Now,
                    RoleId = 1,
                    UserName = register.UserName
                };
                db.AccountRepository.addUser(user);
                db.Save();


                //Send Activation Email
                IGmailSender emailSender=new SendMail();
                string body = PartialToStringClass.RenderPartialView("ManageEmails", "ActivationEmail", user);
                emailSender.SendGmail(user.Email,"ایمیل فعالسازی",body);
                //End Send Activation Email


                return View("SuccessRegister", user);
            }
            if(db.AccountRepository.isExistEmail(register.Email))
            {
                ModelState.AddModelError("Email","ایمیل وارد شده تکراری است");
            }
            else
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده تکراری است");
            }
            return View();
        }

        public ActionResult ActiveUser(string id)
        {

            var user = db.AccountRepository.getUserByActivationCode(id);
            
            if(user==null)
                return HttpNotFound();
            
            user.IsActive = true;
            user.ActiveCode = Guid.NewGuid().ToString();
            db.Save();
            ViewBag.UserName = user.UserName;
            return View();
        }
        [Route("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginViewModel login,string ReturnUrl="/")
        {
            if (ModelState.IsValid)
            {
                string hashPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(login.Password, "MD5");
                var user = db.AccountRepository.getUserByEmailAndHashedPassword(login.Email,hashPassword);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        FormsAuthentication.SetAuthCookie(user.UserName, login.RememberMe);
                        return Redirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "حساب کاربری شما فعال نشده است");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با اطلاعات وارد شده یافت نشد");
                }
            }

            return View(login);
        }
        [Route("LogOut")]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
        [Route("ForgotPassword")]
        public ActionResult ForgotPassword()
        {
           
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordViewModel forgot)
        {
            if (ModelState.IsValid)
            {
                var user = db.AccountRepository.getUserByEmail(forgot.Email);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        IGmailSender emailSender = new SendMail();
                        string bodyEmail =
                            PartialToStringClass.RenderPartialView("ManageEmails", "RecoveryPassword", user);
                        emailSender.SendGmail(user.Email, "بازیابی کلمه عبور", bodyEmail);
                        return View("SuccessForgotPassword", user);
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "حساب کاربری شما فعال نیست");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری یافت نشد");
                }
            }
            return View();
        }

        public ActionResult RecoveryPassword(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult RecoveryPassword(string id, RecoveryPasswordViewModel recovery)
        {
            if (ModelState.IsValid)
            {
                var user = db.AccountRepository.getUserByActivationCode(id);
                if (user == null)
                {
                    return HttpNotFound();
                }

                user.Password = FormsAuthentication.HashPasswordForStoringInConfigFile(recovery.Password, "MD5");
                user.ActiveCode = Guid.NewGuid().ToString();
                db.Save();
                return Redirect("/Login?recovery=true");
            }
            return View();
        }

    }
}