using Projet_RIO71_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projet_RIO71_app.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        //Regestration post action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] CLIENT client, HttpPostedFileBase file)
        {
            bool Status = false;
            string message = "";

            string pic = null;
            if (file != null)
            {
                pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Images/ClientBase"), pic);
                file.SaveAs(path);
            }

            client.Photo = pic;

            //Model validation 
            if (ModelState.IsValid)
            {
                //Email is elready exist
                #region //Email is already Exist 
                var isExist = IsEmailExist(client.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(client);
                }
                #endregion

                //Generate activation code 
                #region Generate Activation Code 
                client.ActivationCode = Guid.NewGuid();
                #endregion

                //Password hashing
                #region  Password Hashing 
                client.Password = Crypto.Hash(client.Password);
                client.ConfirmPassword = Crypto.Hash(client.ConfirmPassword);
                #endregion
                client.IsEmailVerified = false;

                //Save to database 
                #region Save to Database
                using (M3IDatabaseEntities dc = new M3IDatabaseEntities())
                {
                    dc.CLIENTs.Add(client);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(client.EmailID, client.ActivationCode.ToString());
                    message = "Registration successfully done. Account activation link " + " has been sent to your email id:" + client.EmailID;
                    Status = true;
                }
                #endregion

            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View(client);
        }


        //Login 
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        //Login POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ClientLogin login)
        {

            #region Essai 1

            if (login.EmailID != null && login.Password != null)
            {
                M3IDatabaseEntities model;
                model = new M3IDatabaseEntities();

                var password = Crypto.Hash(login.Password);

                var v = model.CLIENTs.Where(a => a.EmailID == login.EmailID && a.Password == password).FirstOrDefault();
                if (v != null)
                {
                    int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                    var ticket = new FormsAuthenticationTicket(login.EmailID, login.RememberMe, timeout);
                    string encrypted = FormsAuthentication.Encrypt(ticket);
                    var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                    cookie.Expires = DateTime.Now.AddMinutes(timeout);
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);
                    return RedirectToAction("Catalogue", "Home");
                }
                else
                {
                    Admin z = model.Admins.Where(a => a.EmailID == login.EmailID && a.Password == login.Password).FirstOrDefault();
                    if (z != null)
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }

            //return RedirectToAction("Index", "Home");
            ViewBag.Message = "Password or Email are incorrecte !";
            return View(login);
            #endregion
        }

        //Logout
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Client");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (M3IDatabaseEntities dc = new M3IDatabaseEntities())
            {
                var v = dc.CLIENTs.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
        
        }


        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode)
        {

            #region Essait 1
            var verifyUrl = "/Client/VerifyAccount/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("mon-email@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "mot-de-passe-de-mon-email"; // Replace with actual password
            string subject = "Your account is successfully created!";

            string body = "<br/><br/>We are excited to tell you that your Dotnet Awesome account is" +
               " successfully created. Please click on the below link to verify your account" +
               " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            }) ;//  smtp.Send(message);  Dans mon email envoie un erreur (Alert)

            #endregion


        }
    }
}