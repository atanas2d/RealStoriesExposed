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
    
        private SelectList _accessibleUsers;
        private List<Story> _accessibleStories;

        private IStoriesService StoriesService;
        private IUsersService UsersService;
        private SelectList AccessibleUsers {
            get {
                return _accessibleUsers ?? new SelectList(UsersService.GetAccessibleUsers(User.Identity.GetUserId()), "Id", "Email");
            }
            set { _accessibleUsers = value; }
        }

        
        public List<Story> AccessibleStories {
            get {
                return _accessibleStories ?? StoriesService.GetAccessibleStories(User.Identity.GetUserId()).ToList();
            }
            set { _accessibleStories = value; }
        }

        public StoriesController(IStoriesService _storiesService, IUsersService usersService)
        {
            this.StoriesService = _storiesService;
            this.UsersService = usersService;
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
            Story story = StoriesService.Find(id);
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
                StoriesService.Add(dbStory);
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
            var story = StoriesService.Find(id);
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
                StoriesService.Update(story);
                StoriesService.SaveChanges();
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
            Story story = StoriesService.Find(id);
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
            Story story = StoriesService.Find(id);
            StoriesService.Delete(story);
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
