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
using HighCode.Presentation.Data.CodeTemplates;

namespace HighCode.Presentation.Controllers
{
    public class CodeTaskSolutionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CodeTaskSolutionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CodeTaskSolutions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeTaskSolutions.ToListAsync());
        }

        // GET: CodeTaskSolutions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeTaskSolution = await _context.CodeTaskSolutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeTaskSolution == null)
            {
                return NotFound();
            }

            return View(codeTaskSolution);
        }

        // GET: CodeTaskSolutions/Create?id
        public async Task<IActionResult> Create(int CodeTaskId)
        {
            var codeTask = await _context.CodeTasks.FindAsync(CodeTaskId);
            var vm = new TaskSolutionViewModel();
            vm.CodeTask = codeTask;
            vm.CodeBoilerplate = CsharpTemplates.CreateTemplate(codeTask.TemplateFuncSignature);
            return View(vm);
        }

        // POST: CodeTaskSolutions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code")] CodeTaskSolution codeTaskSolution)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeTaskSolution);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeTaskSolution);
        }

        // GET: CodeTaskSolutions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeTaskSolution = await _context.CodeTaskSolutions.FindAsync(id);
            if (codeTaskSolution == null)
            {
                return NotFound();
            }
            return View(codeTaskSolution);
        }

        // POST: CodeTaskSolutions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Code,VotesUp,VotesDown")] CodeTaskSolution codeTaskSolution)
        {
            if (id != codeTaskSolution.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeTaskSolution);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeTaskSolutionExists(codeTaskSolution.Id))
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
            return View(codeTaskSolution);
        }

        // GET: CodeTaskSolutions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeTaskSolution = await _context.CodeTaskSolutions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeTaskSolution == null)
            {
                return NotFound();
            }

            return View(codeTaskSolution);
        }

        // POST: CodeTaskSolutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeTaskSolution = await _context.CodeTaskSolutions.FindAsync(id);
            if (codeTaskSolution != null)
            {
                _context.CodeTaskSolutions.Remove(codeTaskSolution);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeTaskSolutionExists(int id)
        {
            return _context.CodeTaskSolutions.Any(e => e.Id == id);
        }
    }
}
