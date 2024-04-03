using HighCode.Presentation.Data.Models;
using Microsoft.AspNetCore.Razor.Language.CodeGeneration;

namespace HighCode.Presentation.ViewModels;

public class TaskViewModel
{
    public CodeTask Task { get; set; }
    public IEnumerable<Comment> Comments { get; set; }
}