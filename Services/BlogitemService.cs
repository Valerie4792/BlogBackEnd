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

        internal bool DeleteBlogItem(BlogitemModel blogDelete)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<BlogitemModel> GetAllBlogItems()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<BlogitemModel> GetItemsByCategory()
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<BlogitemModel> GetItemsByCategory(string category)
        {
            throw new NotImplementedException();
        }

        internal IEnumerable<BlogitemModel> GetItemsByDate(string date)
        {
            throw new NotImplementedException();
        }

        internal List<BlogitemModel> GetItemsByTag(string tag)
        {
            throw new NotImplementedException();
        }

        internal bool UpdateBlogItems(BlogitemModel blogUpdate)
        {
            throw new NotImplementedException();
        }
    }
}