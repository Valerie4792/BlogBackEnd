using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using BlogBackEnd.Models;
using BlogBackEnd.Services.Context;

namespace BlogBackEnd.Services
{
    public class BlogitemService
    {
        private readonly DataContext _context;
        public BlogitemService(DataContext context)
        {
            _context = context;
            
        }
        public bool AddBlogItem(BlogitemModel newBlogItem)
        {
            bool result = false;
            _context.Add(newBlogItem);
            result = _context.SaveChanges() != 0;
            return result;
        }

        public bool DeleteBlogItem(BlogitemModel BlogDelete)
        {
            _context.Update<BlogitemModel>(BlogDelete);
            return _context.SaveChanges() != 0;

          
        }

        public IEnumerable<BlogitemModel> GetAllBlogItems()
        {
            return _context.BlogInfo;
        }

      

        public IEnumerable<BlogitemModel> GetItemsByCategory(string Category)
        {
            return _context.BlogInfo.Where(item => item.Category == Category);
        }

        public IEnumerable<BlogitemModel> GetItemsByDate(string Date)
        {
            return _context.BlogInfo.Where(item => item.Date == Date);
        }

        public List<BlogitemModel> GetItemsByTag(string Tag)
        {
           List<BlogitemModel>AllBlogsWithTag = new List<BlogitemModel>(); 
           var allItems = GetAllBlogItems().ToList(); //will return an object of tags {Tag: "tag1", "tag2", "tag3"}
           for(int i =0; i < allItems.Count; i++){
            BlogitemModel Item = allItems[i];
            var itemArr = Item.Tag.Split(','); //{"Tag1", "Tag2"}// .split turned to an array;
            for(int j = 0; j < itemArr.Length; j++){
                if(itemArr[j].Contains(Tag)){
                    AllBlogsWithTag.Add(Item);
                }
            }
           }
           return AllBlogsWithTag;
            
        }

        public bool UpdateBlogItems(BlogitemModel BlogUpdate)
        {
            _context.Update<BlogitemModel>(BlogUpdate);
            return _context.SaveChanges() != 0;
            
        }

        public IEnumerable<BlogitemModel> GetPublishedItems()
        {
           return _context.BlogInfo.Where(item => item.IsPublished);
        }

        public IEnumerable<BlogitemModel> GetItemsByUserID(int userID)
        {
           return _context.BlogInfo.Where(item => item.UserId == userID);
        }
    }
}
