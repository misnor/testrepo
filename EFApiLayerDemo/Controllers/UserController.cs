using EFApiLayerDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace EFApiLayerDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : Controller
{
    private readonly StoreDbContext context;
    
    public UserController(StoreDbContext context)
    {
        this.context = context;
    }
    
    // GET
    [HttpGet(Name = "GetUsers")]
    public IEnumerable<User> Index()
    {
        return this.context.Users;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([Bind("UserID,Username,Email,Password,RegistrationDate")] User user)
    {
        if (ModelState.IsValid)
        {
            context.Add(user);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Invalid data, return a plain text or HTML response
        var validationErrors = string.Join("\n", ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage));

        return Content(validationErrors, "text/plain"); // or "text/html"
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id != null && id.HasValue)
        {
            var user = this.context.Users.Where(x => x.UserID == id.Value).ToList().First();

            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();

            return Ok();
        }
        else
        {
            return BadRequest("give an id");
        }
    }
}