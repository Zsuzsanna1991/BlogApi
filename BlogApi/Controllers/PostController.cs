using BlogApi.Models;
using BlogApi.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewPost(AddPostDto addPostDto)
        {
            try
            {
                var post = new Post
                {
                    Title = addPostDto.Title,
                    Content = addPostDto.Content,
                    Category = addPostDto.Category,
                    BloggerId = addPostDto.BloggerId
                };


                using (var context = new BlogDbContext())
                {
                    if (post != null)
                    {
                        context.post.Add(post);
                        context.SaveChanges();
                        return StatusCode(201, new { message = "Sikeres hozzáadás", result = post });

                    }

                    return StatusCode(404, new { message = "Sikertelen hozzáadás", result = post });

                }

            }
            catch (Exception ex)
            {

                return BadRequest(new { message = ex.Message, result = "" });
            }
        }


        [HttpGet]
        public ActionResult GetAllPost()
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    return Ok(new { message = "Sikeres lekérés", result = context.post.ToList() });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(400, new { message = ex.Message, result = "" });
            }
        }


        [HttpGet("byid")]
        public ActionResult GetPostById (int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var post = context.post.FirstOrDefault(x => x.Id == id);

                    if (post != null)
                    {
                        return Ok(new {message = "Sikeres lekérdezés", result = post});
                    }

                    return StatusCode(404, new { message = "Nincs ilyen id", result = post });

                }
            }
            catch (Exception ex)
            {

                return StatusCode(404, new { message = ex.Message, result = "" });

            }
        }


        [HttpDelete]
        public ActionResult DeletePost(int id)
        {
            try
            {
                using (var context = new BlogDbContext())
                {
                    var post = context.post.FirstOrDefault(y => y.Id == id);

                    if (post != null)
                    {
                        context.post.Remove(post);
                        context.SaveChanges();
                        return Ok(new { message = "Sikeres törlés", result = post });
                    }

                    return StatusCode(404, new { message = "Nincs ilyen id", result = post });

                }

            }
            catch (Exception ex)
            {

                return StatusCode(404, new { message = ex.Message, result = "" });
            }
        }
    }
}
