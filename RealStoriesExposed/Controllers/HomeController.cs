﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using RealStoriesExposed.Data;
using RealStoriesExposed.Models;
using RealStoriesExposed.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RealStoriesExposed.Services.Contracts;

namespace RealStoriesExposed.Controllers
{
    public class HomeController : BaseController
    {
        private IStoriesService _storiesService;
        public HomeController(IStoriesService service)
        {
            _storiesService = service;
        }

        public ActionResult Index()
        {
            var stories = Mapper.Map<List<Story>, List<StoryViewModel>>(_storiesService.GetAll().ToList());

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

        // GET: /Story/5
        public ActionResult Story(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var storyDB = _storiesService.Find(id);
            var storyVM = Mapper.Map<StoryViewModel>(storyDB);
            return View(storyVM);
        }
    }
}