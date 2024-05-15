using BlogMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Text;

namespace BlogMvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            var posts = getAllPosts();
            ViewData["Title"] = "Ana Sayfa";
            return View(posts);
        }
        
        public IActionResult Hakkimda()
        {
            ViewData["Title"] = "Hakkýmda";
            return View();
        }
        public IActionResult Iletisim()
        {
            ViewData["Title"] = "Ýletiþim";
            return View();
        }
        public IActionResult OrnekPost(string slug="")
        {
            ViewData["Title"] = "Örnek Gönderi";
            using StreamReader reader = new StreamReader("AppData/posts/" + slug + ".txt");
            string txt = reader.ReadToEnd();

            return View("OrnekPost",txt);
        }
        public List<Post> getAllPosts()
        {
            var posts = new List<Post>();
            using StreamReader reader = new StreamReader("AppData/posts/index.txt");
            var postsTxt = reader.ReadToEnd();
            var postsLines = postsTxt.Split('\n');
            foreach (var postLine in postsLines)
            {
                var postParts = postLine.Split('|');
                posts.Add(
                    new Post()
                    {
                        Title = postParts[0],
                        Summary = postParts[1],
                        ImgUrl = postParts[2],
                        Slug = postParts[3]
                    }
                );
            }
            return posts;
        }
    }
}
