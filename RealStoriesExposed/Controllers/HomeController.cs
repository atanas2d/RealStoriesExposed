using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealStoriesExposed.Data;
using RealStoriesExposed.Models;
using RealStoriesExposed.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealStoriesExposed.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var stories = Mapper.Map<List<Story>, List<StoryViewModel>>(Data.Stories.All().ToList());

            return View(stories);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}