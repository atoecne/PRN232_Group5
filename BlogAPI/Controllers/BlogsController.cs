using BlogAPI.DTOs;
using BlogAPI.Models;
using BlogAPI.Services.Interfaces;
using BlogService.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _service;

        public BlogsController(IBlogService service)
        {
            _service = service;
        }

        // GET: api/Blogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReadBlogDto>>> GetBlogs()
        {
            var blogs = await _service.GetAllAsync();
            return Ok(blogs);
        }

        // GET: api/Blogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReadBlogDto>> GetBlog(int id)
        {
            var blog = await _service.GetByIdAsync(id);
            return blog == null ? NotFound() : Ok(blog);
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<ReadBlogDto>>> Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
                return BadRequest("Keyword is required.");

            var results = await _service.SearchAsync(keyword);
            return Ok(results);
        }


        // POST: api/Blogs
        [HttpPost]
        //[Authorize(Roles = "Admin,Staff")]
        public async Task<ActionResult<ReadBlogDto>> PostBlog(CreateBlogDto dto)
        {
            var createdBlog = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetBlog), new { id = createdBlog.BlogId }, createdBlog);
        }

        // PUT: api/Blogs/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> PutBlog(int id, UpdateBlogDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        // DELETE: api/Blogs/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin,Staff")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
    }
}