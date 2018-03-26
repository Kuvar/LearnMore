using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LearnMore.Repository;
using LearnMore.Models;
using Entities;

namespace LearnMore.Controllers
{
    public class BlogController : Controller
    {

        private readonly PostRepository _postRepository = new PostRepository();
        private readonly TagRepository _tagRepository = new TagRepository();
        private readonly CategoryRepository _categoryRepository = new CategoryRepository();
        private readonly CommentRepository _commentRepository = new CommentRepository();

        //
        // GET: /Blog/

        public ActionResult Index(int p = 1)
        {
            var viewModel = new ListViewModel(_postRepository, p);
            ViewBag.Title = "Latest Posts";
            return View(viewModel);
        }

        /// <summary>
        /// Child action that returns the sidebar partial view.
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        public PartialViewResult Sidebars()
        {
            var widgetViewModel = new WidgetViewModel(_postRepository, _tagRepository, _categoryRepository);
            return PartialView("_Sidebars", widgetViewModel);
        }

        /// <summary>
        /// Return a particular post based on the puslished year, month and url slug.
        /// </summary>
        /// <param name="year">Published year</param>
        /// <param name="month">Published month</param>
        /// <param name="title">Url slug</param>
        /// <returns></returns>
        public ViewResult Post(int year, int month, string title)
        {
            var post = _postRepository.Post(year, month, title);

            if (post == null)
                throw new HttpException(404, "Post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                throw new HttpException(401, "The post is not published");

            return View(post);
        }

        public ViewResult ReadMore(int year, int month, int day, string title)
        {
            var post = _postRepository.Post(year, month, day, title);

            if (post == null)
                throw new HttpException(404, "Post not found");

            if (post.Published == false && User.Identity.IsAuthenticated == false)
                throw new HttpException(401, "The post is not published");

            return View("post", post);
        }

        /// <summary>
        /// Return the posts belongs to a category.
        /// </summary>
        /// <param name="category">Url slug</param>
        /// <param name="p">Pagination number</param>
        /// <returns></returns>
        public ViewResult Category(string id, int p = 1)
        {
            var viewModel = new ListViewModel(_postRepository, _tagRepository, _categoryRepository, id, "Category", p);

            if (viewModel.Category == null)
                throw new HttpException(404, "Category not found");

            ViewBag.Title = String.Format(@"Latest posts on category ""{0}""", viewModel.Category.Name);
            return View("Index", viewModel);
        }

        /// <summary>
        /// Return the posts belongs to a tag.
        /// </summary>
        /// <param name="tag">Url slug</param>
        /// <param name="p">Pagination number</param>
        /// <returns></returns>
        public ViewResult Tag(string id, int p = 1)
        {

            var viewModel = new ListViewModel(_postRepository, _tagRepository, _categoryRepository, id, "Tag", p);

            if (viewModel.Tag == null)
                throw new HttpException(404, "Tag not found");

            ViewBag.Title = String.Format(@"Latest posts tagged on ""{0}""", viewModel.Tag.Name);
            return View("Index", viewModel);
        }


        public PartialViewResult AddComment(int id)
        {
            Comment model = new Comment();
            model.PostId = id;
            return PartialView("_AddComment", model);
        }

        [HttpPost]
        public ActionResult AddComment(Comment model)
        {
            if (ModelState.IsValid)
            {

                model.Post = _postRepository.FindBy(model.PostId);
                model.CommentedDate = DateTime.Now;
                model.IsActive = false;
                _commentRepository.Add(model);

                return Json(true, "_AddComment");
            }

            return Json(false, "_AddComment");
        }

        public ActionResult Comments(List<Comment> model)
        {
            return PartialView(model);
        }

    }
}
