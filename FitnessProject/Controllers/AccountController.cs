
using FitnessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor.Generator;

namespace FitnessProject.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            FitnessWebDbEntities db = new FitnessWebDbEntities();

            var data = db.Users.Where(s => s.username.Equals(username) && s.password.Equals(password));
            if (data.Count() > 0)
            {
                Session["User_id"] = data.FirstOrDefault().id;
                Session["IsLoggedIn"] = true;
                return RedirectToAction("Index", "Home");
            }
            return View();

        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User model)
        {
            FitnessWebDbEntities db = new FitnessWebDbEntities();

            try
            {
                // Kiểm tra xem username đã tồn tại chưa
                if (IsUsernameAvailable(model.username))
                {
                    // Thêm người dùng vào cơ sở dữ liệu
                    db.Users.Add(model);
                    db.SaveChanges();

                    // Đã lưu thành công, có thể thực hiện các công việc khác nếu cần

                    return RedirectToAction("Login");
                }
                else
                {
                    // Username đã tồn tại, có thể thông báo lỗi hoặc thực hiện các bước khác
                    Session["IsRegister"] = true;
                }
            }
            catch (Exception)
            {
                // Xử lý lỗi (ở đây bạn có thể ghi log hoặc thực hiện các bước khác)
                Session["IsRegister"] = true;

            }

            // Trả về View với thông báo kết quả
            return RedirectToAction("Register");
        }

        // Hàm kiểm tra xem username đã tồn tại hay chưa
        private bool IsUsernameAvailable(string username)
        {
            FitnessWebDbEntities db = new FitnessWebDbEntities();

            // Kiểm tra xem có người dùng nào có username như vậy chưa
            return !db.Users.Any(u => u.username == username);
        }
        public ActionResult Logout()
        {
            // Xóa thông tin đăng nhập hoặc bất kỳ thông tin khác trong Session
            Session.Clear();

            // Có thể thực hiện các bước khác như đặt lại cookies, đưa người dùng về trang chủ, ...

            // Chuyển hướng người dùng đến trang đăng nhập hoặc trang chủ
            return RedirectToAction("index", "Home");
        }


    }
}