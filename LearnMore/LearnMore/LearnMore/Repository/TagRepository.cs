using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using Entities;
using MvcJqGrid;

namespace LearnMore.Repository
{
    public class TagRepository
    {
        JustBlogEntities objDB = new JustBlogEntities();

        public IQueryable<Tag> All()
        {
            return objDB.Tags;
        }

        public Tag FindBy(int id)
        {
            return objDB.Tags.FirstOrDefault(t => t.Id == id);
        }

        /// <summary>
        /// Return tag based on url slug.
        /// </summary>
        /// <param name="tagSlug"></param>
        /// <returns></returns>
        public Tag Tag(string tagSlug)
        {
            return objDB.Tags.FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }

        public int Add(Tag model)
        {
            try
            {
                objDB.Tags.Add(model);
                return objDB.SaveChanges();
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public int Update(Tag model)
        {
             try
             {
                    Tag tag = All().FirstOrDefault(t => t.Id == model.Id);
                    if (tag != null)
                    {
                        tag.Name = model.Name;
                        tag.UrlSlug = model.UrlSlug;
                        tag.Description = model.Description;
                    }
                    return objDB.SaveChanges();
             }
             catch (Exception)
             {
                 return 0;
             }
         }

      #region

        public IQueryable<Tag> GetRecords(GridSettings gridSettings, string pDefaultSortColumn = "Id")
        {
            var records = All()
                .OrderBy(string.IsNullOrEmpty(gridSettings.SortColumn.Trim())
                    ? pDefaultSortColumn
                    : gridSettings.SortColumn + " " + gridSettings.SortOrder);
            return records.Skip((gridSettings.PageIndex - 1)*gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public IQueryable<Tag> GetRecords(GridSettings gridSettings, Expression<Func<Tag, bool>> filter, string pDefaultSortColumn = "1")
        {
            var records = All().Where(filter).OrderBy(string.IsNullOrEmpty(gridSettings.SortColumn.Trim()) ? pDefaultSortColumn : gridSettings.SortColumn + " " + gridSettings.SortOrder);
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public IQueryable<Tag> GetRecords(GridSettings gridSettings, Func<IQueryable<Tag>, IOrderedQueryable<Tag>> orderBy)
        {
            var records = orderBy(All()).AsQueryable();
            return records.Skip((gridSettings.PageIndex - 1) * gridSettings.PageSize).Take(gridSettings.PageSize);
        }

        public int CountRecords(GridSettings gridSettings)
        {
            return gridSettings.IsSearch ? gridSettings.Where.rules.Aggregate(All(), FilterRecords).Count() : All().Count();
        }

        public int CountRecords(GridSettings gridSettings, Expression<Func<Tag, bool>> filter)
        {
            return All().Where(filter).Count();
        }

        /// <summary>
        /// To filter records
        /// </summary>
        /// <param name="records"></param>
        /// <param name="rule"></param>
        /// <returns></returns>
        private static IQueryable<Tag> FilterRecords(IQueryable<Tag> records, Rule rule)
        {
            //Implement filter
            return records;
        }
      #endregion
    }
}
