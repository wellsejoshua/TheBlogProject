using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBlogProject.Data;
using TheBlogProject.Enums;
using TheBlogProject.Models;
//in order to talk to database you need application db context I need to reach out to database to create roles
//thing 1 : seed a few roles into the system
//thing 2 : seed a user into the system (create me)
namespace TheBlogProject.Services
{
  public class DataService
  {
    private readonly ApplicationDbContext _dbContext;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<BlogUser> _userManager;

    public DataService(ApplicationDbContext dbContext, 
      RoleManager<IdentityRole> roleManager, 
      UserManager<BlogUser> userManager)
    {
      _dbContext = dbContext;
      _roleManager = roleManager;
      _userManager = userManager;
    }

    public async Task ManageDataAsync()
    {
      //this public method is going to be used to call other methods that are private in the class ...it is a wrapper method
      //task 1 seed a few roles into the system
      await SeedRolesAsync();

      //task 2 : seed a few roles into the system
      await SeedUserAsync();
    }

    private async Task SeedRolesAsync()
    {
      //if there are roles in the system do nothing
      //asp roles table 
      if (_dbContext.Roles.Any())
      {
        return;
      }
      //otherwise we want to create a few roles 
      //use a roles manager method to manage roles 
      foreach (var role in Enum.GetNames(typeof(BlogRole)))
      {
        // Use the role manager to create roles
        await _roleManager.CreateAsync(new IdentityRole(role));
      }


    }

    private async Task SeedUserAsync()
    {
      //if there are user in the system do nothing
      if (_dbContext.Users.Any())
      {
        return;
      }
      //step 1 creates new instance of BlogUser
      var adminUser = new BlogUser()
      {
        Email = "codedbywells@gmail.com",
        UserName = "codedbywells@gmail.com",
        FirstName = "Josh",
        LastName = "Wells",
        PhoneNumber = "(281) 217-1876",
        EmailConfirmed = true,

      };

      //step 2 : use usermanager to create new user defined by adminUser 
      await _userManager.CreateAsync(adminUser, "Abc&123");

      //step 3: add this new user to the administrator role
      await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());


      // to assign a moderator you need to redo the process 
      //step 1 : Create the moderator user
      var modUser = new BlogUser()
      {
        Email = "wellsejoshua@gmail.com",
        UserName = "wellsejoshua@gmail.com",
        FirstName = "modJosh",
        LastName = "modWells",
        PhoneNumber = "(221) 217-1876",
        EmailConfirmed = true,
      };

      await _userManager.CreateAsync(modUser, "Abc&123");
      await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());


    }

  }
}
