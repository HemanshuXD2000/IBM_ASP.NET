using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OrganicStore.Models;
using System.Drawing;

namespace OrganicStore.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }




        [HttpPost]
        public IActionResult Login(User user)
        {
            
            SqlConnection conn = new SqlConnection(ConnectionMod.getConnString());
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from Users where username='" + user.username + "'and password='" + user.password + "'");
                cmd.Connection = conn;
                int OBJ = Convert.ToInt32(cmd.ExecuteScalar());
                if(OBJ > 0)
                {
                    //Session["name"] = user.username;
                    //Response.Redirect("Products.cshtml");
                    
                return RedirectToAction("Details","Product");

                }
                else
                {
                //Response.Redirect("Signup.cshtml");
                ViewBag.NotValidUser = user;
                ModelState.AddModelError(user.username, "Invalid Username and password.");
                /*Response.WriteAsync("<script>alert('User Not Found!')</script>");
                Response.Redirect("Index.cshtml");*/
                ViewData.Add(user.username , "Invalid User and pass");
  
            }
                
            /*string username = user.username;
            string password = user.password;
            return RedirectToAction("Products","Home", user);*//*
            return View("Login","Login")*/;
            return RedirectToAction("Index", "Home", user);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
