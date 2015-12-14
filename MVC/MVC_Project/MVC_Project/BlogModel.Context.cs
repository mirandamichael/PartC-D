namespace MVC_Project
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BlogContext : DbContext
    {
       public BlogContext() : base("MVC_Project.BlogContext")
        {

        }
        public virtual DbSet<Blog> Blogs { get; set; }
    }
}
