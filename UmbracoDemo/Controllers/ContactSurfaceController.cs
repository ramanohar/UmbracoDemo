using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;
using UmbracoDemo.Models;

namespace UmbracoDemo.Controllers
{
    public class ContactSurfaceController : SurfaceController
    {
        // GET: ContactSurface
        public ActionResult GetContactUs()
        {
            return View("ContactUs",new ContactUsModel());
        }

        public ActionResult PostContactDetails(ContactUsModel model)
        {

            MailMessage email = new MailMessage(model.Email, "manohar.ra@gmail.com");
            email.Subject = "Contact Form Request";
            email.Body = model.Message;

            try
            {
                //Connect to SMTP credentials set in web.config
                SmtpClient smtp = new SmtpClient();

                //Try & send the email with the SMTP settings
                smtp.Send(email);
            }
            catch (Exception ex)
            {
                //Throw an exception if there is a problem sending the email
                throw ex;
            }

            //Update success flag (in a TempData key)
            TempData["IsSuccessful"] = true;

            //All done - lets redirect to the current page & show our thanks/success message
            return RedirectToCurrentUmbracoPage();
            return RedirectToCurrentUmbracoPage();
        }
    }
}