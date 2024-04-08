using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HighCode.Presentation.Data;
using HighCode.Presentation.Data.Models;
using HighCode.Presentation.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Controllers
{

    [Authorize(Roles = "Moderator")]
    public class CodeTasksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CodeTasksController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: CodeTasks
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeTasks.ToListAsync());
        }

        // GET: CodeTasks/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeTask = await _context.CodeTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeTask == null)
            {
                return NotFound();
            }
            var solutions = await _context.CodeTaskSolutions
                .Where(x => x.IsPublished && x.RelatedTaskId == id)
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .ToListAsync();
            var comments = await _context.Comments
                .Where(c => c.RelatedTaskId == id)
                .OrderByDescending(c => c.DateCreated)
                .Include(c => c.Author)
                .ToListAsync();
            var vm = new TaskViewModel
            {
                Task = codeTask,
                Solutions = solutions,
                Comments = comments
            };
            return View(vm);
        }

        // GET: CodeTasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CodeTasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,UnitTestCode,TemplateFuncSignature,Complexity,ProgrammingLanguage")] CodeTask codeTask)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeTask);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeTask);
        }

        // GET: CodeTasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeTask = await _context.CodeTasks.FindAsync(id);
            if (codeTask == null)
            {
                return NotFound();
            }
            return View(codeTask);
        }

        // POST: CodeTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,UnitTestCode,TemplateFuncSignature,Complexity,ProgrammingLanguage")] CodeTask codeTask)
        {
            if (id != codeTask.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeTask);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeTaskExists(codeTask.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(codeTask);
        }

        // GET: CodeTasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeTask = await _context.CodeTasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeTask == null)
            {
                return NotFound();
            }

            return View(codeTask);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostComment(TaskViewModel vm)
        {
            await _context.Comments.AddAsync(new Comment
            {
                RelatedTaskId = vm.Task.Id,
                Author = await _userManager.GetUserAsync(User),
                Content = vm.NewComment,
                DateCreated = DateTime.Now
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { id = vm.Task.Id});
        }
        // POST: CodeTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeTask = await _context.CodeTasks.FindAsync(id);
            if (codeTask != null)
            {
                _context.CodeTasks.Remove(codeTask);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        

        private bool CodeTaskExists(int id)
        {
            return _context.CodeTasks.Any(e => e.Id == id);
        }
    }
}
