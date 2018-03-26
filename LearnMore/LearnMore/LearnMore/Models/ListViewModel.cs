using System;
using System.Collections.Generic;
using System.Linq;
using LearnMore.Repository;
using Entities;

namespace LearnMore.Models
{
    public class ListViewModel
    {

        public IList<Post> Posts { get; private set; }

        public int TotalPosts { get; private set; }

        public Category Category { get; private set; }

        public Tag Tag { get; private set; }

        public string Search { get; private set; }

        public ListViewModel(PostRepository postRepository, int p)
        {
            Posts = postRepository.Posts(p - 1, 10);
            TotalPosts = postRepository.TotalPosts();
        }

        public ListViewModel(PostRepository postRepository, TagRepository tagRepository, CategoryRepository categoryRepository, string text, string type, int p)
        {
            switch (type)
            {
                case "Category":
                    Posts = postRepository.PostsForCategory(text, p - 1, 10);
                    TotalPosts = postRepository.TotalPostsForCategory(text);
                    Category = categoryRepository.Category(text);
                    break;

                case "Tag":
                    Posts = postRepository.PostsForTag(text, p - 1, 10);
                    TotalPosts = postRepository.TotalPostsForTag(text);
                    Tag = tagRepository.Tag(text);
                    break;

                default:
                    Posts = postRepository.PostsForSearch(text, p - 1, 10);
                    TotalPosts = postRepository.TotalPostsForSearch(text);
                    Search = text;
                    break;
            }
        }

    }
}
