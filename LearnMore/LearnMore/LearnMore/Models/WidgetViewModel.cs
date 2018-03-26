using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using LearnMore.Repository;

namespace LearnMore.Models
{
    public class WidgetViewModel
    {

        public IList<Category> Categories { get; private set; }

        public IList<Tag> Tags { get; private set; }

        public IList<Post> LatestPosts { get; private set; }

        public WidgetViewModel(PostRepository postRepository, TagRepository tagRepository, CategoryRepository categoryRepository)
        {
            Categories = categoryRepository.All().ToList();
            Tags = tagRepository.All().ToList();
            LatestPosts = postRepository.All().ToList();
        }
    }
}
