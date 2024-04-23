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
using HighCode.Presentation.Models;
using HighCode.Presentation.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace HighCode.Presentation.Controllers
{
    public class CodeTaskSolutionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly StatisticService _statisticService;
        private readonly UserManager<User> _userManager;

        public CodeTaskSolutionsController(ApplicationDbContext context, UserManager<User> userManager, StatisticService statisticService)
        {
            _context = context;
            _userManager = userManager;
            _statisticService = statisticService;
        }
        
        // Не используется
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
        
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveCode(int codeTaskId, string code)
        {
            await CreateOrSaveCodeTaskSolution(codeTaskId, code);
            return Ok("Сохранено");
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Publish(int codeTaskId, string code)
        {
            var user = await _userManager.GetUserAsync(User);
            var cTs = await _context.CodeTaskSolutions
                .FirstOrDefaultAsync(m => m.Id == codeTaskId && m.AuthorId == user.Id);
            if (cTs is { IsPublished: true }) return 
                Ok(new TestExecutionReport{
                    Output = "Уже опубликовано!",
                    UseRawOutput = true
                });
            
            if (cTs is { IsTested: true } && cTs.Code == code)
            {
                cTs.IsPublished = true;
                await _context.SaveChangesAsync();
                return Ok(new TestExecutionReport
                {
                    Output = "Опубликовано",
                    UseRawOutput = true
                });
            }
            cTs = await CreateOrSaveCodeTaskSolution(codeTaskId, code);
            var codeTask = await _context.CodeTasks.FindAsync(codeTaskId);
            var res = await testCode(code, codeTask.UnitTestCode);
            if (res.TestsTotalCount == 0 || res.TestsPassed != res.TestsTotalCount) return Ok(res);
            cTs.IsTested = true;
            cTs.IsPublished = true;
            await _context.SaveChangesAsync();
            res.UseRawOutput = true;
            res.Output = "Опубликовано\n" + res.Output;
            await _statisticService.CalculateScoreForCompletedTask(
                await _userManager.GetUserAsync(User),
                res,
                await _context.CodeTasks.FindAsync(codeTaskId));
            
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> TestCode(int codeTaskId,string code)
        {
            var codeTask = await _context.CodeTasks.FindAsync(codeTaskId);
            if (codeTask == null) return BadRequest();
            var result = await testCode(code, codeTask.UnitTestCode);
            if (User.Identity.IsAuthenticated)
            {
                var cTs = await CreateOrSaveCodeTaskSolution(codeTaskId, code);
                if (result.TestsTotalCount != 0)
                    cTs.IsTested = result.TestsPassed == result.TestsTotalCount;
                else
                    cTs.IsTested = false;
                await _context.SaveChangesAsync();
            }

            return Ok(result);
        }

        // GET: CodeTaskSolutions/Create?id
        public async Task<IActionResult> Create(int codeTaskId)
        {
            var codeTask = await _context.CodeTasks.FindAsync(codeTaskId);
            var vm = new TaskSolutionViewModel();
            if (codeTask != null)
            {
                vm.CodeTask = codeTask;
                vm.Code = CsharpTemplates.CreateTemplate(codeTask.TemplateFuncSignature);
            }

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var cTs = await _context.CodeTaskSolutions
                    .FirstOrDefaultAsync(x => 
                        x.RelatedTaskId == codeTaskId
                        && x.AuthorId == user.Id);
                if (cTs != null)
                {
                    vm.Code = cTs.Code;
                    vm.CodeTaskSolutionId = cTs.Id;
                    vm.IsPublished = cTs.IsPublished;
                }
            }

            return View(vm);
        }
        

        // Не используется, для этого есть функция Create
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeTaskSolution = await _context.CodeTaskSolutions.FindAsync(id);
            if (codeTaskSolution == null)
            {
                return RedirectToAction("Index", controllerName: "CodeTasks");
            }
            return View(codeTaskSolution);
        }

        /*// POST: CodeTaskSolutions/Edit/5
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

                return RedirectToAction("Index", controllerName: "CodeTasks");
            }
            return View(codeTaskSolution);
        }*/

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
            var codeTaskSolution = await _context.CodeTaskSolutions
                .Include(x => x.Comments)
                .Include(x => x.RelatedTask)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeTaskSolution != null)
            {
                codeTaskSolution.Comments.Clear();
                codeTaskSolution.IsPublished = false;   
                codeTaskSolution.IsTested = false;   
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Create", new { CodeTaskId = codeTaskSolution.RelatedTaskId });
        }

        private bool CodeTaskSolutionExists(int id)
        {
            return _context.CodeTaskSolutions.Any(e => e.Id == id);
        }
        
        private async Task<TestExecutionReport> testCode(string code, string unitTestCode)
        {
            var resultedCode = $"using NUnit.Framework;using NUnit.Framework.Constraints;\n{code}\n{unitTestCode}";
            return await UnitTestExecutor.Execute(resultedCode);
        }

        private async Task<CodeTaskSolution> CreateOrSaveCodeTaskSolution(int codeTaskId, string code)
        {
            var user = await _userManager.GetUserAsync(User);
            var cTs = await _context.CodeTaskSolutions
                .Where(x => 
                    x.RelatedTaskId == codeTaskId 
                    && x.AuthorId == user.Id)
                .FirstOrDefaultAsync();
            if (cTs != null)
                cTs.Code = code;
            else
                cTs = (await _context.CodeTaskSolutions.AddAsync(new CodeTaskSolution()
                {
                    Code = code,
                    RelatedTaskId = codeTaskId,
                    AuthorId = user.Id
                })).Entity;
                
            await _context.SaveChangesAsync();
            
            return cTs;
        }
    }
}
