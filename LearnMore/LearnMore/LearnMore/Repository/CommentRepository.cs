using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;

namespace LearnMore.Repository
{
    public class CommentRepository
    {
        JustBlogEntities objDB = new JustBlogEntities();

        public IQueryable<Comment> All()
        {
            return objDB.Comments;
        }

        public Comment FindBy(int id)
        {
            return objDB.Comments.FirstOrDefault(t => t.Id == id);
        }

        public int Add(Comment model)
        {
            objDB.Comments.Add(model);
            return objDB.SaveChanges();
        }
    }
}
