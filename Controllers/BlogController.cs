using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogBackEnd.Models;
using BlogBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlogBackEnd.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogitemService _data;

        //need to create a variable to hold our data and create constructor
        public BlogController(BlogitemService dataFromService)
        {
            _data = dataFromService;
            
        }
        //add each individual end point
        //AddBlogItems
        [HttpPost("AddBlogItems")]
         public bool AddBlogItem(BlogitemModel newBlogItem){
            return _data.AddBlogItem(newBlogItem);
        
         
        }
        //GetAllBlogItems
        [HttpGet("GetAllBlogItems")]
       public IEnumerable<BlogitemModel> GetAllBlogItems(){
                return _data.GetAllBlogItems();
            }
        //GetBlogItemsByCategory
       [ HttpGet("GetItemsByCategory/{Category}")]
        public IEnumerable<BlogitemModel> GetItemsByCategory(string Category){
                return _data.GetItemsByCategory(Category);
            }
        //GetAllBlogItemsByTags
       [ HttpGet("GetItemsByTag/{Tag}")]
        public List<BlogitemModel> GetItemsByTag(string Tag){
                return _data.GetItemsByTag(Tag);
            }

        //GetBlogItemsByDate
        [ HttpGet("GetItemsByDate/{Date}")]
        public IEnumerable<BlogitemModel> GetItemsByDate(string Date){
                return _data.GetItemsByDate(Date);
            }
        

        //UpdateBlogItems
         [ HttpPost("UpdateBlogItems")]
        public bool UpdateBlogItems(BlogitemModel BlogUpdate){
                return _data.UpdateBlogItems(BlogUpdate);
            }
        //DeleteBlogItems
        [HttpPost("DeleteBlogItem/{BlogItemToDelete}")]
        public bool DeleteBlogItem(BlogitemModel BlogDelete){
            return _data.DeleteBlogItem(BlogDelete);
        }
        
    }
}