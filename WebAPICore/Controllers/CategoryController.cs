using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        AppDBContext _db;
        public CategoryController(AppDBContext db)
        {
            _db = db;
        }
        //GET: api/category
        //get the list of categories 
        [HttpGet]
        public IEnumerable<Category> GetCategories()
        {
            return _db.Categories.ToList();

        }
    }
}
