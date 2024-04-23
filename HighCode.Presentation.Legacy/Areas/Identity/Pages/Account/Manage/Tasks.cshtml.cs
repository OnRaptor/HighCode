using HighCode.Presentation.Data;
using HighCode.Presentation.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HighCode.Presentation.Areas.Identity.Pages.Account.Manage;

public class TasksModel : PageModel
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<User> _userManager;
    
    public List<CodeTaskSolution> Solutions { get; set; }

    public TasksModel(ApplicationDbContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var user = await _userManager.GetUserAsync(User);
        Solutions = await _context.CodeTaskSolutions
            .Include(x => x.Author)
            .Include(x => x.RelatedTask)
            .Where(x => x.AuthorId == user.Id)
            .ToListAsync();
        return Page();
    }
}