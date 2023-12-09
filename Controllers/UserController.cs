using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class AccountController : Controller
    {
        private BookingCareEntities1 dbContext; // Replace 'YourDbContext' with your actual DbContext class name

        public AccountController()
        {
            dbContext = new BookingCareEntities1(); // Initialize your DbContext instance
        }

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = dbContext.AdminSystems.FirstOrDefault(u => u.UserName == username && u.Password == password);
            if (user != null)
            {
                // Authentication successful
                // Get the user's role
                var role = dbContext.Roles.FirstOrDefault(r => r.RoleID == user.RoleID)?.RoleName;

                // Store the role in the authentication cookie or session variable
                var claims = new[]
                {
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, user.UserName),
                    new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Role, role)
                };

                var identity = new System.Security.Claims.ClaimsIdentity(claims, "ApplicationCookie");
                var authManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
                authManager.SignIn(new AuthenticationProperties { IsPersistent = false }, identity);

                // Redirect to the appropriate page based on the user's role
                if (role == "StaffSystem")
                {
                    return RedirectToAction("Index", "Staff");
                }
                else if (role == "AdminSystem")
                {
                    return RedirectToAction("Index", "Admin");
                }
                // Handle other roles accordingly

                // If the role doesn't match any specific page, redirect to a default page
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Authentication failed
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }

        // GET: Account/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(string username, string password)
        {
            var user = dbContext.AdminSystems.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                // Username is available, proceed with registration
                user = new AdminSystem
                {
                    UserName = username,
                    Password = password,
                    RoleID = "RoleID" // Assign the appropriate role ID based on the user type
                };
                dbContext.AdminSystems.Add(user);
                dbContext.SaveChanges();

                // Registration successful
                // Perform any additional logic, such as setting authentication cookies or session variables
                return RedirectToAction("Login");
            }
            else
            {
                // Username is already taken
                ViewBag.ErrorMessage = "Username is already taken.";
                return View();
            }
        }
    }
}