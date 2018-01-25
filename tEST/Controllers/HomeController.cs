using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tEST.Models;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Text;

namespace tEST.Controllers
{
    public class HomeController : Controller
    {
        string theEvent;
        string folderLocation;
        string configFile;
        DataColOptions dco = new DataColOptions();


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutComtec()
        {

            return View();
        }

        public IActionResult SignUp()
        {
            ViewData["Message"] = "Sign Up to Comtec For a Catalogue.";

            return View();
        }

        public IActionResult AdminPass()
        {
            ViewData["Message"] = "Admin Page";

            return View();


        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult PrizeDraw()
        {

            return View();
        }

        public IActionResult PrizeDrawEnter(string firstname, string lastname, string company, string email, long phoneNumber) {

            if (firstname == null || lastname == null || company == null || email == null)
            {


                Index();
                return View("PrizeDraw");
            }

            Customer cust = new Customer
            {
                fname = firstname.Trim(),
                lname = lastname.Trim(),
                company = company.Trim(),
                email = email.Trim(),
                phone = phoneNumber


            };
            string path;
            List<string> customerData = new List<string>
            {
                "Firstname: " + cust.fname,
                "Surname: " + cust.lname,
                "Company: " + cust.company,
                "Email: " + cust.email,
                "Phone Number: " + cust.phone.ToString().Trim()
            };

            path = "C:/ComtecShowApp/ICELIVE/PRIZEDRAW/" + cust.fname + " " + cust.lname + " - " + cust.company + " ICELIVE " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".txt";
            System.IO.File.WriteAllLines(path: path, contents: customerData);

            ViewData["Message"] = "Thank you for Signing Up to the Prize Draw!";
            return View("SaveDetails");
        }


        public ActionResult SaveDetails(string firstname, string lastname, string company, string email, long phoneNumber, bool A = false, bool B = false,
            bool C = false, bool D = false, bool E = false, bool F = false, bool G = false, bool H = false, bool I = false, bool J = false, bool K = false,
            bool L = false, bool M = false, bool N = false, bool O = false, bool prizeDraw = false)
        {
            

            if (firstname == null || lastname == null || company == null || email == null)
            {


                Index();
                return View("SignUp");
            }

            Customer cust = new Customer
            {
                fname = firstname.Trim(),
                lname = lastname.Trim(),
                company = company.Trim(),
                email = email.Trim(),
                phone = phoneNumber


            };

            if (A)
            {
                cust.products.Add("Structured Cabling");
            }
            if (B)
            {
                cust.products.Add("Fibre Optic Cabling");
            }
            if (C)
            {
                cust.products.Add("Trunking & Cable Management");
            }
            if (D)
            {
                cust.products.Add("Voice Cabling");
            }
            if (E)
            {
                cust.products.Add("Cabinets & Accessories");
            }
            if (F)
            {
                cust.products.Add("Active Equipment");
            }
            if (G)
            {
                cust.products.Add("Tools");
            }
            if (H)
            {
                cust.products.Add("Site Equipment");
            }
            if (I)
            {
                cust.products.Add("Fixings & Fastenings");
            }
            if (J)
            {
                cust.products.Add("Labelling Solutions");
            }
            if (K)
            {
                cust.products.Add("External Cabling");
            }
            if (L)
            {
                cust.products.Add("Telephony");
            }
            if (M)
            {
                cust.products.Add("Test & Measurement");
            }
            if (N)
            {
                cust.products.Add("Power, Cabling & Accessories");
            }
            if (O)
            {
                cust.products.Add("Audio Visual & Coax");
            }




            //do stuff here...



            string path;
            List<string> customerData = new List<string>
            {
                "Firstname: " + cust.fname,
                "Surname: " + cust.lname,
                "Company: " + cust.company,
                "Email: " + cust.email,
                "Phone Number: " + cust.phone.ToString().Trim()
            };
            foreach (string s in cust.products)
            {
                customerData.Add(s);
            }

            if (prizeDraw)
            {
                ViewData["Message"] += " \n You have also been entered into our prize draw!";
                List <string> prizeCustData = new List<string>
                {
                    "Firstname: " + cust.fname,
                    "Surname: " + cust.lname,
                    "Company: " + cust.company,
                    "Email: " + cust.email,
                    "Phone Number: " + cust.phone.ToString().Trim()
                };
                path = "C:/ComtecShowApp/ICELIVE/PRIZEDRAW/" + cust.fname + " " + cust.lname + " - " + cust.company + " ICELIVE " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".txt";
                System.IO.File.WriteAllLines(path: path, contents: prizeCustData);
            }

            path = "C:/ComtecShowApp/ICELIVE/SIGNUP/" + cust.fname + " " + cust.lname + " - " + cust.company + " ICELIVE " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".txt";
            System.IO.File.WriteAllLines(path: path, contents: customerData);



            //SmtpClient cv = new SmtpClient
            //{
            //    Host = "mail.comtec-comms.com",
            //    Port = 995,
            //    EnableSsl = true,
            //    DeliveryMethod = SmtpDeliveryMethod.Network,
            //    UseDefaultCredentials = false,
            //    Credentials = new NetworkCredential("italerts@cg.local", "c0mtec999$")
            //};
            //using (var message = new MailMessage("italerts@comtec-comms.com", email)
            //{
            //    IsBodyHtml = true,
            //    Subject = "CometcIceLive",
            //    Body = "Thank you " + firstname + " " + lastname + " for Signing Up To Comtec IceLive 2018! Your business is always welcome!"

            //})
            //{
            //    ServicePointManager.Expect100Continue = false;
            //    cv.Send(message);
            //}

            ViewData["Message"] = "Thank you for Submitting your details!";
            return View();

        }

        public ActionResult Admin(string password)
        {
            if (password != "Comtec415")
            {
                return View("AdminPass");
            }
            else
            {
                return View();
            }
        }

        public ActionResult SetConfig(string theEvent, string saveFolder, string Fname, string Lname, string Company, string Email, string PhoneNumber)
        {

            return View("AdminPass");
        }
    }
}
