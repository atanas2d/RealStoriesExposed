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
using RealStoriesExposed.Data;
using RealStoriesExposed.Services.Contracts;

namespace RealStoriesExposed.Areas.Administration.Controllers
{
    public class StoriesController : BaseController
    {
        private IStoryService storyService;
        private IUsersService usersService;
        private SelectList _accessibleUsers;
        private List<Story> _accessibleStories;

        private SelectList AccessibleUsers {
            get {
                return _accessibleUsers ?? new SelectList(getAccessibleUsers(), "Id", "Email");
            }
            set { _accessibleUsers = value; }
        }

        
        public List<Story> AccessibleStories {
            get {
                return _accessibleStories ?? getAccessibleStories().ToList();
            }
            set { _accessibleStories = value; }
        }

        public StoriesController(IStoryService storyService, IUsersService usersService)
        {
            this.storyService = storyService;
            this.usersService = usersService;
        }


        private IQueryable<ApplicationUser> getAccessibleUsers()
        {
            string currentUserId = User.Identity.GetUserId().ToString();
            if (RealStoriesExposed.Common.Constants.AdminsIDs.Contains(currentUserId))
            {
                return usersService.GetAll();
            }
            else
            {
                return usersService.GetAll().Where(u => u.Id == currentUserId);
            }
        }

        private IQueryable<Story> getAccessibleStories()
        {
            string currentUserId = User.Identity.GetUserId().ToString();
            if (!Common.Constants.AdminsIDs.Contains(currentUserId))
            {
                return storyService.GetAll().Where(s => s.AuthorId == currentUserId);
            }

            return storyService.GetAll();
        }

        [Authorize]
        // GET: Administration/Stories
        public ActionResult Index()
        {
            var stories = Mapper.Map<List<Story>, List<StoryViewModel>>(AccessibleStories);
            
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
            Story story = storyService.Find(id);
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

            storyVM.Users = AccessibleUsers;       

            return View(storyVM); 
        }

        // POST: Administration/Stories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryViewModel storyVM)
        {
            storyVM.Users = AccessibleUsers;

            if (ModelState.IsValid)
            {
                var dbStory = Mapper.Map<Story>(storyVM);
                dbStory.CreatedOn = DateTime.Now;
                storyService.Add(dbStory);
                storyService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storyVM);
        }

        [Authorize]
        // GET: Administration/Stories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = storyService.Find(id);
            StoryViewModel storyVM = Mapper.Map<StoryViewModel>(story); 
           
            if (story == null)
            {
                return HttpNotFound();
            }

            storyVM.Users = AccessibleUsers;

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
            storyVM.Users = AccessibleUsers;
                       
            if (ModelState.IsValid)
            {
                var story = Mapper.Map<Story>(storyVM);
                storyService.Update(story);
                storyService.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(storyVM);
        }

        [Authorize]
        // GET: Administration/Stories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Story story = storyService.Find(id);
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
            Story story = storyService.Find(id);
            storyService.Delete(story);
            storyService.SaveChanges();
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
