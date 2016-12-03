using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RealStoriesExposed.Data;
using RealStoriesExposed.Models;
using AutoMapper;
using RealStoriesExposed.Areas.Administration.ViewModels;
using RealStoriesExposed.Controllers;

namespace RealStoriesExposed.Areas.Administration.Controllers
{
    public class StoriesController : BaseController
    {
        // GET: Administration/Stories
        public ActionResult Index()
        {
            var stories = Mapper.Map<List<Story>, List<StoryViewModel>>(Data.Stories.All().ToList());

            return View(stories);
        }

        // GET: Administration/Stories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = Data.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // GET: Administration/Stories/Create
        public ActionResult Create()
        {
            var StoryVM = new StoryViewModel();
            StoryVM.Users = new SelectList(Data.Users.All(), "Id", "Email"); 

            return View(StoryVM); 
        }

        // POST: Administration/Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Content,CreatedOn")] StoryViewModel story)
        {
            if (ModelState.IsValid)
            {
                var dbStory = Mapper.Map<Story>(story);
                dbStory.CreatedOn = DateTime.Now;
                Data.Stories.Add(dbStory);
                Data.Stories.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(story);
        }

        // GET: Administration/Stories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = Data.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Administration/Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Content,CreatedOn")] Story story)
        {
            if (ModelState.IsValid)
            {
                Data.Stories.Update(story);
                Data.Stories.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        // GET: Administration/Stories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = Data.Stories.Find(id);
            if (story == null)
            {
                return HttpNotFound();
            }
            return View(story);
        }

        // POST: Administration/Stories/Delete/5
        [HttpPost, ActionName("Delete")] 
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Story story = Data.Stories.Find(id);
            Data.Stories.Delete(story);
            Data.Stories.SaveChanges();
            return RedirectToAction("Index");
        } 

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
