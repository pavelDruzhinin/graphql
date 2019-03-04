using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GraphQL.Data
{
    public class BlogPost
    {
        public BlogPost()
        {

        }
        public BlogPost(int id, string title, string body)
        {
            Id = id;
            Title = title;
            Body = body;
            CreatedUtcDateTime = DateTime.UtcNow;
        }
        public int Id { get; set; }
        public DateTime CreatedUtcDateTime { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public List<BlogsCategories> Categories { get; set; }
    }

    public class BlogsCategories
    {
        public BlogsCategories()
        {

        }

        public BlogsCategories(int blogId, int categoryId)
        {
            BlogPostId = blogId;
            CategoryId = categoryId;
        }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public int CategoryId { get; set; }
        public BlogCategory Category { get; set; }
    }

    public class BlogCategory
    {
        public BlogCategory()
        {

        }

        public BlogCategory(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<BlogsCategories> BlogPosts { get; set; }
    }

    public class BlogPostMap : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.Categories);
            builder.HasData(new[]{
                new BlogPost(1, "Title 1", "Body 1"),
                new BlogPost(2, "Title 2", "Body 2"),
                new BlogPost(3, "Title 3", "Body 3"),
                new BlogPost(4, "Title 4", "Body 4"),
                new BlogPost(5, "Title 5", "Body 5"),
                new BlogPost(6, "Title 6", "Body 6"),
                new BlogPost(7, "Title 7", "Body 7"),
                new BlogPost(8, "Title 8", "Body 8"),
                new BlogPost(9, "Title 9", "Body 9"),
                new BlogPost(10, "Title 10", "Body 10"),

            });
        }
    }

    public class BlogCategoryMap : IEntityTypeConfiguration<BlogCategory>
    {
        public void Configure(EntityTypeBuilder<BlogCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasMany(x => x.BlogPosts);
            builder.HasData(new[] {
                new BlogCategory(1,"Category 1"),
                new BlogCategory(2,"Category 2"),
                new BlogCategory(3,"Category 3"),
                new BlogCategory(4,"Category 4"),
                new BlogCategory(5,"Category 5"),
                new BlogCategory(6,"Category 6"),
                new BlogCategory(7,"Category 7"),
            });
        }
    }

    public class BlogsCategoriesMap : IEntityTypeConfiguration<BlogsCategories>
    {
        public void Configure(EntityTypeBuilder<BlogsCategories> builder)
        {
            builder.HasKey(x => new { x.BlogPostId, x.CategoryId });
            builder.HasOne(x => x.Category);
            builder.HasOne(x => x.BlogPost);
            builder.HasData(new[] {
                new BlogsCategories(1,2),
                new BlogsCategories(1,3),
                new BlogsCategories(1,4),
                new BlogsCategories(1,5),
                new BlogsCategories(2,1),
                new BlogsCategories(2,2),
                new BlogsCategories(2,4),
                new BlogsCategories(2,6),
                new BlogsCategories(2,7),
                new BlogsCategories(3,2),
                new BlogsCategories(9,7)
            });
        }
    }

    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BlogCategoryMap());
            modelBuilder.ApplyConfiguration(new BlogsCategoriesMap());
            modelBuilder.ApplyConfiguration(new BlogPostMap());
        }
    }
}
