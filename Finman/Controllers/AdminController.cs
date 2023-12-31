﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Finman.Models;
using System.Linq;
using System.Diagnostics;
using Microsoft.Ajax.Utilities;
using System.Data.Entity;

namespace fin.Controllers
{
    public class AdminController : Controller
    {
        FinManEntities entity = new FinManEntities();
        // GET: Admin
        public ActionResult AdminLogin()
        {
            return View();
        }

        public ActionResult AdminHome()
        {
            return View();
        }

        public ActionResult AdminContact()
        {
            return View();
        }

        public ActionResult AddProfilesData()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddProfilesData(profilesData profile)
        {
            /* profilesData obj = new profilesData();
             obj.profiles = profiles.profiles;
             obj.value = profiles.value;*/

            Debug.WriteLine(profile.profiles + profile.value);

            if(profile.Id == 0)
            {
                entity.profilesDatas.Add(profile);
                entity.SaveChanges();
            }
            else
            {
                entity.Entry(profile).State = EntityState.Modified;
                entity.SaveChanges();
            }
            return RedirectToAction("profilesData");

        }

        public ActionResult profilesData() 
        { 
            var res = entity.profilesDatas.ToList();
            return View(res);
        }

        public ActionResult Delete(int Id)
        {
            var res = entity.profilesDatas.Where(x=> x.Id == Id).First();
            entity.profilesDatas.Remove(res);
            entity.SaveChanges();

            var list = entity.profilesDatas.ToList();
            return View("profilesData", list);

        }
        public ActionResult DeleteQuestion(int Id)
        {
            var res = entity.Questionss.Where(x => x.Id == Id).First();
            entity.Questionss.Remove(res);
            entity.SaveChanges();

            var list = entity.Questionss.ToList();
            return RedirectToAction("ModifyQuestions");
           /* return View("ModifyQuestions", list);*/

        }


        [HttpPost]
        public ActionResult AdminLogin(AdminLogin credentials)
        {
            bool userExists = entity.AdminLogins.Any(model => model.AdminEmail == credentials.AdminEmail && model.AdminPassword == credentials.AdminPassword);
            AdminLogin admin = entity.AdminLogins.FirstOrDefault(model => model.AdminEmail == credentials.AdminEmail && model.AdminPassword == credentials.AdminPassword);
            if (userExists)
            {
                FormsAuthentication.SetAuthCookie(admin.AdminEmail, false);
                return RedirectToAction("AdminHome", "Admin");
            }
            ModelState.AddModelError("", "Email or Password is wrong");
            return View();
        }
        public ActionResult AdminSignout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin");
        }

        public ActionResult ModifyQuestions()
        {
            /*List<Questions> questions= entity.Questionss.ToList();
            ViewData["Question"] = questions;

            return View();*/

            var res = entity.Questionss.ToList();
            ViewData["Question"] = res;
            Debug.WriteLine("Hi"+res.Count);
            return View(res);
        }
        public ActionResult AddQuestion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddQuestion(Questions question)
        {
            /*if (question.Id == 0)
            {*/
                Debug.WriteLine(question.QuestionName + question.NoOfOptions);
                entity.Questionss.Add(question);
                entity.SaveChanges();
            /*}
            else
            {
                entity.Entry(question).State = EntityState.Modified;
                entity.SaveChanges();
            }*/
            return RedirectToAction("ModifyQuestions");
        }
        public ActionResult AddOption()
        {
            return View();
        }
    }
}