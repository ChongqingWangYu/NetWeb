﻿using System;
using System.Web.Mvc;
using WebApplication.Service;
using WebApplication.Models;
using System.Collections.Generic;

namespace WebApplication.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register(string userName,string password,string phone,string email)
        {
            if (!ModelState.IsValid)
            {
                return Content("error");
            }
            User user = new User();
            user.UserName = userName;
            user.Password = password;
            user.Phone = phone;
            user.Email = email;
            bool reslut = userService.Register(user);
            if (reslut)
            {
                return Content("注册成功！");
            }
            else
            {
                return Content("注册失败！");
            }
        }

        public ActionResult Login(string userName,string password)
        {
            if (!ModelState.IsValid)
            {
                return Content("error");
            }
            User user = new User();
            user.UserName = userName;
            user.Password = password;
            bool reslut= userService.Login(user);
            if (reslut)
            {
                return View("Main");
            }
            else
            {
                return Content("登录失败");
            }
        }

        [HttpGet]
        public ActionResult FindByAll()
        {
            return Content(userService.FindByAll());
        }
        public ActionResult DeleteUser(string userName)
        {
            return Content(userService.DeleteUser(userName));
        }
        public ActionResult FindUserByUserName(string userName)
        {
            return Content(userService.FindUserByUserName(userName));
        }
        public ActionResult UpdateUser(string oldName,string newName,string newPassword,string newPhone,string newEmail)
        {
            User user = new User();
            user.UserName = newName;
            user.Password = newPassword;
            user.Phone = newPhone;
            user.Email = newEmail;
            bool reslut = userService.UpdateUser(oldName, user);
            if (reslut)
            {
                return Content("修改成功！");
            }
            else
            {
                return Content("修改失败！");
            }
        }
    }
}