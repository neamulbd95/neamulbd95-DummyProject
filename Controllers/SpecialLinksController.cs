using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    public class SpecialLinksController : Controller
    {
        // In-memory storage for demo purposes
        // In a real application, you would use a database
        private static List<SpecialLink> _specialLinks = new List<SpecialLink>
        {
            new SpecialLink { Id = 1, Title = "Google", Url = "https://www.google.com", CreatedAt = DateTime.Now.AddDays(-1) },
            new SpecialLink { Id = 2, Title = "GitHub", Url = "https://www.github.com", CreatedAt = DateTime.Now.AddDays(-2) }
        };
        private static int _nextId = 3;

        public IActionResult Index()
        {
            return View(_specialLinks);
        }

        [HttpGet]
        public IActionResult GetLinks()
        {
            return Json(_specialLinks);
        }

        [HttpPost]
        public IActionResult CreateLinks([FromBody] List<SpecialLinkRequest> linkRequests)
        {
            try
            {
                var newLinks = new List<SpecialLink>();
                
                foreach (var request in linkRequests)
                {
                    if (!string.IsNullOrWhiteSpace(request.Title) && !string.IsNullOrWhiteSpace(request.Url))
                    {
                        var newLink = new SpecialLink
                        {
                            Id = _nextId++,
                            Title = request.Title.Trim(),
                            Url = request.Url.Trim(),
                            CreatedAt = DateTime.Now
                        };
                        
                        _specialLinks.Add(newLink);
                        newLinks.Add(newLink);
                    }
                }

                return Json(new { success = true, message = $"Successfully created {newLinks.Count} link(s)", data = newLinks });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error creating links: " + ex.Message });
            }
        }

    }
}
