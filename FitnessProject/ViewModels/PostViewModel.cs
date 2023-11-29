using FitnessProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FitnessProject.ViewModels
{
    public class PostViewModel
    {
        public List<Post> Posts { get; set; }
        public Post Post { get; set; }
        public string FullName { get; set; }
        public List<Category> Categories { get; set; }

        public PostViewModel()
        {
            Categories = new List<Category>();
        }
    }
}
