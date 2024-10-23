using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eBookStore.Controllers
{
    public class AuthController : Controller
    {
        private const string UserFilePath = @"Data\users.json";
        private List<User> Users;

        public AuthController()
        {
            LoadUsersFromFile();
        }

        private void LoadUsersFromFile()
        {
            if (System.IO.File.Exists(UserFilePath))
            {
                var json = System.IO.File.ReadAllText(UserFilePath);
                Users = JsonConvert.DeserializeObject<List<User>>(json) ?? new List<User>();
            }
            else
            {
                Users = new List<User>();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user, string confirm_password)
        {
            if (!ModelState.IsValid)
            {
                TempData["ErrorMessage"] = "Please fill out all required fields.";
                return View(user);
            }

            if (Users.Any(u => u.email_address == user.email_address))
            {
                TempData["ErrorMessage"] = "Email address already exists.";
                return View(user);
            }

            // So sánh mật khẩu với confirm_password
            if (user.password != confirm_password)
            {
                TempData["ErrorMessage"] = "Passwords do not match.";
                return View(user);
            }

            // Thêm người dùng mới vào danh sách
            Users.Add(new User
            {
                email_address = user.email_address,
                password = user.password
            });

            System.IO.File.WriteAllText(UserFilePath, JsonConvert.SerializeObject(Users));
            TempData["SuccessMessage"] = "Registration successful. Please login.";
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(user.email_address) || string.IsNullOrEmpty(user.password))
            {
                TempData["ErrorMessage"] = "Please provide a valid email and password.";
                return View(user);
            }

            var existingUser = Users.FirstOrDefault(u => u.email_address == user.email_address && u.password == user.password);

            if (existingUser != null)
            {
                HttpContext.Session.SetString("email_address", existingUser.email_address);
                // TempData["SuccessMessage"] = "Login successful.";
                return RedirectToAction("Index", "Home");
            }

            TempData["ErrorMessage"] = "Invalid email or password.";
            return View(user);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("email_address");
            return RedirectToAction("Index", "Home");
        }
    }
}