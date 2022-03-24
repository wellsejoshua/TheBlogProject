using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheBlogProject.Models;

namespace TheBlogProject.Data
{
  //Mechanism to communicate with database
  public class ApplicationDbContext : IdentityDbContext<BlogUser>
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    //dbset relates to a table in the database
    public DbSet<Blog> Blogs { get; set;}
    public DbSet<Post> Posts { get; set;}
    public DbSet<Comment> Comments { get; set;}
    public DbSet<Tag> Tags { get; set;}
  }
}
