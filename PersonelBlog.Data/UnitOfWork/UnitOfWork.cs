using PersonalBlog.Data.Context;
using PersonalBlog.Data.Models;
using PersonalBlog.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBlog.Data.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private readonly PersonalBlogContext db;

        public UnitOfWork(PersonalBlogContext db)
        {
                this.db = db;
        }

        private GenericRepository<User> _users;
        private GenericRepository<Role> _roles;
        private GenericRepository<Category> _categories;
        private GenericRepository<Post> _posts;
        private GenericRepository<PostCategory> _postcategories;
        private GenericRepository<PostComment> _postcomments;
        private GenericRepository<Tag> _tags;
        private GenericRepository<PostTag> _posttags;

        public GenericRepository<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new GenericRepository<User>(db);
                }
                return _users;
            }
        }
        
        public GenericRepository<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new GenericRepository<Category>(db);
                }
                return _categories;
            }
        }
        public GenericRepository<Post> Posts
        {
            get
            {
                if (_posts == null)
                {
                    _posts = new GenericRepository<Post>(db);
                }
                return _posts;
            }
        }
        public GenericRepository<PostCategory> PostCategories
        {
            get
            {
                if (_postcategories == null)
                {
                    _postcategories = new GenericRepository<PostCategory>(db);
                }
                return _postcategories;
            }
        }
        public GenericRepository<PostComment> PostComments
        {
            get
            {
                if (_postcomments == null)
                {
                    _postcomments = new GenericRepository<PostComment>(db);
                }
                return _postcomments;
            }
        }
        public GenericRepository<PostTag> PostTags
        {
            get
            {
                if (_posttags == null)
                {
                    _posttags = new GenericRepository<PostTag>(db);
                }
                return _posttags;
            }
        }
        public GenericRepository<Role> Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new GenericRepository<Role>(db);
                }
                return _roles;
            }
        }
        public GenericRepository<Tag> Tags
        {
            get
            {
                if (_tags == null)
                {
                    _tags = new GenericRepository<Tag>(db);
                }
                return _tags;
            }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
