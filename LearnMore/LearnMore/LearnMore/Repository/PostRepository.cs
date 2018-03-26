using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using Entities;
using MvcJqGrid;

namespace LearnMore.Repository
{
    public class PostRepository
    {
        JustBlogEntities objDB = new JustBlogEntities();

        public IQueryable<Post> All()
        {
            return objDB.Posts;
        }

        public Post FindBy(int id)
        {
            return objDB.Posts.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Return collection of posts based on pagination parameters.
        /// </summary>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        public IList<Post> Posts(int pageNo, int pageSize)
        {

            var posts = objDB.Posts
                        .Where(p => p.Published)
                        .OrderByDescending(p => p.PostedOn)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return objDB.Posts
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                  .ToList();
        }


        /// <summary>
        /// Return total no. of all or published posts.
        /// </summary>
        /// <param name="checkIsPublished">True to count only published posts</param>
        /// <returns></returns>
        public int TotalPosts(bool checkIsPublished = true)
        {
            return objDB.Posts.Count(p => checkIsPublished || p.Published);
        }


        /// <summary>
        /// Return collection of posts belongs to a particular category.
        /// </summary>
        /// <param name="categorySlug">Category's url slug</param>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        public IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            var posts = objDB.Posts
                        .Where(p => p.Published && p.Category.UrlSlug.Equals(categorySlug))
                        .OrderByDescending(p => p.PostedOn)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                //.Fetch(p => p.Category)
                        .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return objDB.Posts
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                //.FetchMany(p => p.Tags)
                  .ToList();
        }


        /// <summary>
        /// Return total no. of posts belongs to a particular category.
        /// </summary>
        /// <param name="categorySlug">Category's url slug</param>
        /// <returns></returns>
        public int TotalPostsForCategory(string categorySlug)
        {
            return objDB.Posts.Count(p => p.Published && p.Category.UrlSlug.Equals(categorySlug));
        }

        /// <summary>
        /// Return collection of posts belongs to a particular tag.
        /// </summary>
        /// <param name="tagSlug">Tag's url slug</param>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        public IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            var posts = objDB.Posts
                            .Where(p => p.Published && p.PostTagMaps.Any(c=>c.Tag.UrlSlug.Equals(tagSlug)))
                            .OrderByDescending(p => p.PostedOn)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                //.Fetch(p => p.Category)
                            .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return objDB.Posts
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                //.FetchMany(p => p.Tags)
                  .ToList();
        }

        /// <summary>
        /// Return total no. of posts belongs to a particular tag.
        /// </summary>
        /// <param name="tagSlug">Tag's url slug</param>
        /// <returns></returns>
        public int TotalPostsForTag(string tagSlug)
        {
            return objDB.Posts.Count(p => p.Published && p.PostTagMaps.Any(t=>t.Tag.UrlSlug.Equals(tagSlug)));
        }

        /// <summary>
        /// Return collection of posts that matches the search text.
        /// </summary>
        /// <param name="search">search text</param>
        /// <param name="pageNo">Page index</param>
        /// <param name="pageSize">Page size</param>
        /// <returns></returns>
        public IList<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            var posts = objDB.Posts
                        .Where(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.PostTagMaps.Any(c=>c.Tag.Name.Equals(search))))
                        .OrderByDescending(p => p.PostedOn)
                        .Skip(pageNo * pageSize)
                        .Take(pageSize)
                        .ToList();

            var postIds = posts.Select(p => p.Id).ToList();

            return objDB.Posts
                  .Where(p => postIds.Contains(p.Id))
                  .OrderByDescending(p => p.PostedOn)
                //.FetchMany(p => p.Tags)
                  .ToList();
        }

        /// <summary>
        /// Return total no. of posts that matches the search text.
        /// </summary>
        /// <param name="search">search text</param>
        /// <returns></returns>
        public int TotalPostsForSearch(string search)
        {
            return objDB.Posts.Count(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.PostTagMaps.Any(t=>t.Tag.Name.Equals(search))));
        }

        /// <summary>
        /// Return post based on the published year, month and title slug.
        /// </summary>
        /// <param name="year">Published year</param>
        /// <param name="month">Published month</param>
        /// <param name="titleSlug">Post's url slug</param>
        /// <returns></returns>
        public Post Post(int year, int month, string titleSlug)
        {

            var query = objDB.Posts
                           .FirstOrDefault(p => p.PostedOn.Year == year
                               && p.PostedOn.Month == month
                               && p.UrlSlug.Equals(titleSlug));

            return query;
        }

        /// <summary>
        /// Return post based on the published year, month and title slug.
        /// </summary>
        /// <param name="year">Published year</param>
        /// <param name="month">Published month</param>
        /// <param name="day">Published day</param>
        /// <param name="titleSlug">Post's url slug</param>
        /// <returns></returns>
        public Post Post(int year, int month, int day, string titleSlug)
        {

            var query = objDB.Posts
                           .FirstOrDefault(p => p.PostedOn.Year == year
                               && p.PostedOn.Month == month
                               && p.PostedOn.Day == day
                               && p.UrlSlug.Equals(titleSlug));

            return query;
        }

        public int Add(Post model)
        {
            try
            {
                objDB.Posts.Add(model);
                return objDB.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(Post model)
        {
            try
            {
                Post post = All().FirstOrDefault(t => t.Id == model.Id);
                if (post != null)
                {
                    post.Title = model.Title;
                    post.ShortDescription = model.ShortDescription;
                    post.Description = model.Description;
                    post.Meta = model.Meta;
                    post.UrlSlug = model.UrlSlug;
                    post.Modified = DateTime.Now;
                    post.Category = model.Category;
                }
                return objDB.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #region
        public IQueryable<Post> GetRecords(GridSettings gridSettings, string pDefaultSortColumn = "Id")
        {
            var records = All()
                .OrderBy(string.IsNullOrEmpty(gridSettings.SortColumn.Trim()) ? pDefaultSortColumn : gridSettings.SortColumn + " " + gridSettings.SortOrder);
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public IQueryable<Post> GetRecords(GridSettings gridSettings, Expression<Func<Post, bool>> filter, string pDefaultSortColumn = "1")
        {
            var records = All().Where(filter).OrderBy(string.IsNullOrEmpty(gridSettings.SortColumn.Trim()) ? pDefaultSortColumn : gridSettings.SortColumn + " " + gridSettings.SortOrder);
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public IQueryable<Post> GetRecords(GridSettings gridSettings, Func<IQueryable<Post>, IOrderedQueryable<Post>> orderBy)
        {
            var records = orderBy(All()).AsQueryable();
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public int CountRecords(GridSettings gridSettings)
        {
            return gridSettings.IsSearch ? gridSettings.Where.rules.Aggregate(All(), FilterRecords).Count() : All().Count();
        }
        public int CountRecords(GridSettings gridSettings, Expression<Func<Post, bool>> filter)
        {
            return All().Where(filter).Count();
        }

        /// <summary>
        /// To filter records
        /// </summary>
        /// <param name="records"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        private static IQueryable<Post> FilterRecords(IQueryable<Post> records, Rule rule)
        {
            //Implement filter
            return records;
        }

        #endregion
    }
}
