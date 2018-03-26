using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using Entities;
using MvcJqGrid;

namespace LearnMore.Repository
{
    public class CategoryRepository
    {

        JustBlogEntities objDB = new JustBlogEntities();

        public IQueryable<Category> All()
        {
            return objDB.Categories;
        }

        public Category FindBy(int id)
        {
            return All().FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Return category based on url slug.
        /// </summary>
        /// <param name="categorySlug">Category's url slug</param>
        /// <returns></returns>
        public Category Category(string categorySlug)
        {
            return objDB.Categories.FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }

        public int Add(Category model)
        {
            try
            {
                objDB.Categories.Add(model);
                return objDB.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(Category model)
        {
            try
            {
                Category category = All().FirstOrDefault(t => t.Id == model.Id);
                if (category != null)
                {
                    category.Name = model.Name;
                    category.UrlSlug = model.UrlSlug;
                    category.Description = model.Description;
                }

                return objDB.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        #region
        public IQueryable<Category> GetRecords(GridSettings gridSettings, string pDefaultSortColumn = "Id")
        {
            var records = All()
                .OrderBy(string.IsNullOrEmpty(gridSettings.SortColumn.Trim()) ? pDefaultSortColumn : gridSettings.SortColumn + " " + gridSettings.SortOrder);
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public IQueryable<Category> GetRecords(GridSettings gridSettings, Expression<Func<Category, bool>> filter, string pDefaultSortColumn = "1")
        {
            var records = All().Where(filter).OrderBy(string.IsNullOrEmpty(gridSettings.SortColumn.Trim()) ? pDefaultSortColumn : gridSettings.SortColumn + " " + gridSettings.SortOrder);
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public IQueryable<Category> GetRecords(GridSettings gridSettings, Func<IQueryable<Category>, IOrderedQueryable<Category>> orderBy)
        {
            var records = orderBy(All()).AsQueryable();
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public int CountRecords(GridSettings gridSettings)
        {
            return gridSettings.IsSearch ? gridSettings.Where.rules.Aggregate(All(), FilterRecords).Count() : All().Count();
        }
        public int CountRecords(GridSettings gridSettings, Expression<Func<Category, bool>> filter)
        {
            return All().Where(filter).Count();
        }

        /// <summary>
        /// To filter records
        /// </summary>
        /// <param name="records"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        private static IQueryable<Category> FilterRecords(IQueryable<Category> records, Rule rule)
        {
            //Implement filter
            return records;
        }

        #endregion
    }
}
