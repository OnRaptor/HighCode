using HighCode.Presentation.Data.Models;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace HighCode.Presentation.ViewModels;

public class TaskViewModel
{
    public CodeTask Task { get; set; } = new();
    public IEnumerable<CodeTaskSolution> Solutions { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
    public Comment NewComment { get; set; }
    public int TaskId { get; set; }
}