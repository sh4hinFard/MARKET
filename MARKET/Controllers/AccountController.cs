using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAL;
using MARKET.Models;
using MARKET.Repositoris;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using MARKET.Service;
using Microsoft.AspNetCore.Authorization;

namespace MARKET.Controllers
{
    public class AccountController : Controller
    {
        private db _db;
        private IViewRenderService _viewRenderService;
        public AccountController(db db, IViewRenderService viewRenderService)
        {
            _db = db;
            _viewRenderService = viewRenderService;
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        
        [Route("Register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var checkUserName = _db.users.Any(u => u.username == register.UserName);
                if (checkUserName)
                {
                    ModelState.AddModelError("UserName", "نام کاربری شما تکراری می باشد");
                    return View(register);
                }
                var email = FixText.FixEmail(register.Email);
                var checkEmail = _db.users.Any(u => u.email == email);
                if (checkEmail)
                {
                    ModelState.AddModelError("Email", "ایمیل شما تکراری می باشد");
                    return View(register);
                }
                Be.User user = new Be.User()
                {
                    ActiveCode = NameGenarator.NameGeneratedUniq(),
                    email = email,
                    IsActive = false,
                    password = PasswordHash.EncodePasswordMd5(register.Password),
                    RegisterDate = DateTime.Now,
                    RoleId = 2,
                    username = register.UserName
                };
                _db.users.Add(user);
                _db.SaveChanges();
                var body = _viewRenderService.RenderToStringAsync("_ActiveCode", user);
                MessageSender.Send(email, "فعالسازی حساب کاربری", body);
                ViewBag.Success = true;
                return View();
            }
            return View(register);
        }


        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("Login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var email = FixText.FixEmail(login.Email);
                var pass = PasswordHash.EncodePasswordMd5(login.Password);
                var user = _db.users.FirstOrDefault(u => u.password == pass && u.email == email);
                if (user != null)
                {
                    if (user.IsActive)
                    {
                        var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim(ClaimTypes.Name,user.username),
                            new Claim (ClaimTypes.Role,"admin")

                        };
                        var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties { IsPersistent = login.RememberMe };
                        HttpContext.SignInAsync(principal, properties);
                        ViewBag.Success = true;
                        return View();
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "حساب کاربری شما فعال نمی باشد");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با این مشخصات یافت نشد");
                    return View(login);
                }
            }
            return View(login);
        }

        public IActionResult ActiveAccount(string id)
        {
            var user = _db.users.SingleOrDefault(u => u.ActiveCode == id);
            if (user != null && !user.IsActive)
            {
                user.IsActive = true;
                user.ActiveCode = NameGenarator.NameGeneratedUniq();
                _db.SaveChanges();
                ViewBag.Success = true;
                return View(user);
            }
            return View();
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [Route("ForgotPassword")]
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel forgotPassword)
        {
            if (ModelState.IsValid)
            {
                var user = _db.users.SingleOrDefault(u => u.email == FixText.FixEmail(forgotPassword.Email));
                if (user != null)
                {
                    var body = _viewRenderService.RenderToStringAsync("_ForgotPass", user);
                    MessageSender.Send(user.email, "تغییر کلمه عبور", body);
                    ViewBag.Success = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", "کاربری با این ایمیل یافت نشد");
                    return View(forgotPassword);
                }
            }
            return View(forgotPassword);
        }

        public IActionResult ResetPassword(string id)
        {
            ResetPasswordViewModel resetPassword = new ResetPasswordViewModel()
            {
                ActiveCode = id
            };
            return View(resetPassword);
        }

        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel resetPassword)
        {
            if (ModelState.IsValid)
            {
                var user = _db.users.SingleOrDefault(u => u.ActiveCode == resetPassword.ActiveCode);
                if (user == null)
                {
                    return NotFound();
                }
                user.password = PasswordHash.EncodePasswordMd5(resetPassword.Password);
                _db.users.Update(user);
                _db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(resetPassword);
        }

        public IActionResult ListUsers()
        {
            var model = _db.users.ToList();
            return View(model);
        }
    }
}


      

    



