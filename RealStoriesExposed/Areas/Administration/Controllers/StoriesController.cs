using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using RealStoriesExposed.Models;
using RealStoriesExposed.Areas.Administration.ViewModels;
using RealStoriesExposed.Controllers;
using RealStoriesExposed.Common;
using Microsoft.AspNet.Identity;

namespace RealStoriesExposed.Areas.Administration.Controllers
{
    public class StoriesController : BaseController
    {
        [Authorize]
        // GET: Administration/Stories
        public ActionResult Index()
        {
            var stories = Mapper.Map<List<Story>, List<StoryViewModel>>(Data.Stories.All().ToList());

            return View(stories);
        }

        [Authorize]
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


        [Authorize]
        // GET: Administration/Stories/Create
        public ActionResult Create()
        {
            var storyVM = new StoryViewModel();

            string currentUserId = User.Identity.GetUserId().ToString();
            var usersList = Data.Users.All();
            if (RealStoriesExposed.Common.Constants.AdminsIDs.Contains(currentUserId))
            {
                storyVM.Users = new SelectList(usersList, "Id", "Email");
            } else
            {
                storyVM.Users = new SelectList(usersList.Where(u => u.Id == currentUserId), "Id", "Email");
            }            

            return View(storyVM); 
        }

        // POST: Administration/Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryViewModel story)
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

        [Authorize]
        // GET: Administration/Stories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = Data.Stories.Find(id);
            StoryViewModel storyVM = Mapper.Map<StoryViewModel>(story); 
           
            if (story == null)
            {
                return HttpNotFound();
            }

            string currentUserId = User.Identity.GetUserId().ToString();
            var usersList = Data.Users.All();
            if (RealStoriesExposed.Common.Constants.AdminsIDs.Contains(currentUserId))
            {
                storyVM.Users = new SelectList(usersList, "Id", "Email");
            }
            else
            {
                storyVM.Users = new SelectList(usersList.Where(u => u.Id == currentUserId), "Id", "Email");
            }

            return View(storyVM);
        }

        // POST: Administration/Stories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StoryViewModel storyVM)
        {
            var story = Mapper.Map<Story>(storyVM);
            if (ModelState.IsValid)
            {                
                Data.Stories.Update(story);
                Data.Stories.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(story);
        }

        [Authorize]
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
        [Authorize]
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
