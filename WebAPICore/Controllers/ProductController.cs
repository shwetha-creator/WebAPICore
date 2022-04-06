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
    public class ProductController : ControllerBase
    {
        AppDBContext _db;
        public ProductController(AppDBContext db)
        {
            _db = db;
        }
        //GET: api/product
        //get the list of products 
        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _db.Products.ToList();

        }
        //GET: api/product/{id}
        [HttpGet("{id}")]
        //get the product detaisl for teh given id 
        public Product GetProduct(int id)
        {

            return _db.Products.Find(id);

        }
        //POST : api/controller
        //creating the product 
        [HttpPost]

        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]// for error
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]  // for success
        public IActionResult AddProduct(Product model)
        {
            try
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }

        }

        //PUT : api/controller
        //for updating the product
        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, Product model)
        {
           // var product = _db.Products.Find(id);

            try
            {
                //if (product != null)
                //{
                    if (id != model.ProductId)
                        return StatusCode(StatusCodes.Status400BadRequest);

                    _db.Products.Update(model);
                    _db.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK);
                //}
                //else
                //{
                //    return StatusCode(StatusCodes.Status400BadRequest);
                //}
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }
        }
    
          

        [HttpDelete("{id}")]
        //delete the product detaisl for teh given id 
        public IActionResult DeleteProduct(int id)
        {
            
                Product product = _db.Products.Find(id);
                if (product != null)
                {
                    _db.Products.Remove(product);
                    _db.SaveChanges();
                    return StatusCode(StatusCodes.Status200OK);
                }
            return StatusCode(StatusCodes.Status400BadRequest);
           
        }
    }
}
