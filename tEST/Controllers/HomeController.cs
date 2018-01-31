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
            ViewData["Message"] = "to Comtec For a Catalogue.";

            return View();
        }

        public IActionResult AdminPass()
        {
            ViewData["Message"] = "Admin Page";

            return View();


        }

        public ActionResult ComtecWeb()
        {

            return View("ComtecWeb");
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult PrizeDraw()
        {

            return View("PrizeDraw");
        }

        public IActionResult PrizeDrawEnter(string firstname, string lastname, string company, string email, long phoneNumber, string industry)
        {

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
                phone = phoneNumber,
                industry = industry.Trim()


            };
            string path;
            List<string> customerData = new List<string>
            {
                "Firstname: " + cust.fname,
                "Surname: " + cust.lname,
                "Company: " + cust.company,
                "Email: " + cust.email,
                "Phone Number: " + "0" + cust.phone.ToString().Trim(),
                "Industry: " + cust.industry
            };

            path = "C:/ComtecShowApp/ISE/PRIZEDRAW/";
            System.IO.Directory.CreateDirectory(path);
            string ppath = cust.fname + " " + cust.lname + " - " + cust.company + " ISE " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".txt";
            System.IO.File.WriteAllLines(path: path + ppath, contents: customerData);

            ViewData["Message"] = "Thank you for Signing Up to the Prize Draw!";
            return View("SaveDetails");
        }


        public ActionResult SaveDetails(string firstname, string lastname, string company, string email, long phoneNumber, string industry, bool A = false, bool B = false,
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
                phone = phoneNumber,
                industry = industry.Trim()


            };
            bool intFlag = false;
            if (A)
            {
                cust.products.Add("Structured Cabling");
                intFlag = true;
            }
            if (B)
            {
                cust.products.Add("Fibre Optic Cabling");
                intFlag = true;
            }
            if (C)
            {
                cust.products.Add("Trunking & Cable Management");
                intFlag = true;
            }
            if (D)
            {
                cust.products.Add("Voice Cabling");
                intFlag = true;
            }
            if (E)
            {
                cust.products.Add("Cabinets & Accessories");
                intFlag = true;
            }
            if (F)
            {
                cust.products.Add("Active Equipment");
                intFlag = true;
            }
            if (G)
            {
                cust.products.Add("Tools");
                intFlag = true;
            }
            if (H)
            {
                cust.products.Add("Site Equipment");
                intFlag = true;
            }
            if (I)
            {
                cust.products.Add("Fixings & Fastenings");
                intFlag = true;
            }
            if (J)
            {
                cust.products.Add("Labelling Solutions");
                intFlag = true;
            }
            if (K)
            {
                cust.products.Add("External Cabling");
                intFlag = true;
            }
            if (L)
            {
                cust.products.Add("Telephony");
                intFlag = true;
            }
            if (M)
            {
                cust.products.Add("Test & Measurement");
                intFlag = true;
            }
            if (N)
            {
                cust.products.Add("Power, Cabling & Accessories");
                intFlag = true;
            }
            if (O)
            {
                cust.products.Add("Audio Visual & Coax");
                intFlag = true;
            }





            //do stuff here...



            string path;
            List<string> customerData = new List<string>
            {
                "Firstname: " + cust.fname,
                "Surname: " + cust.lname,
                "Company: " + cust.company,
                "Email: " + cust.email,
                "Phone Number: " + "0" + cust.phone.ToString().Trim(),
                "Industry: " + cust.industry
            };
            if (intFlag)
            {
                customerData.Add("");
                customerData.Add("Interested in the following products:");
                customerData.Add("");
            }
            foreach (string s in cust.products)
            {
                customerData.Add(s);
            }

            if (prizeDraw)
            {
                ViewData["Message"] += " \n You have also been entered into our prize draw!";
                List<string> prizeCustData = new List<string>
                {
                    "Firstname: " + cust.fname,
                    "Surname: " + cust.lname,
                    "Company: " + cust.company,
                    "Email: " + cust.email,
                    "Phone Number: " + "0" + cust.phone.ToString().Trim(),
                    "Industry: " + cust.industry
                };
                path = "C:/ComtecShowApp/ISE/PRIZEDRAW/";
                System.IO.Directory.CreateDirectory(path);
                string ppath = cust.fname + " " + cust.lname + " - " + cust.company + " ISE " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".txt";
                System.IO.File.WriteAllLines(path: path + ppath, contents: prizeCustData);
            }

            path = "C:/ComtecShowApp/ISE/SIGNUP/";
            
            System.IO.Directory.CreateDirectory(path);
            string path2 = cust.fname + " " + cust.lname + " - " + cust.company + " ISE " + DateTime.Today.Day.ToString() + "-" + DateTime.Today.Month.ToString() + "-" + DateTime.Today.Year.ToString() + ".txt";
            System.IO.File.WriteAllLines(path: path + path2, contents: customerData);



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
            //    Subject = "CometcISE",
            //    Body = "Thank you " + firstname + " " + lastname + " for Signing Up To Comtec ISE 2018! Your business is always welcome!"

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
