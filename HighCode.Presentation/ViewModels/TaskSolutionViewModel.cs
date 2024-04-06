using HighCode.Presentation.Data.Models;

namespace HighCode.Presentation.ViewModels
{
    public class TaskSolutionViewModel
    {
        public CodeTask CodeTask { get; set; }
        public string Code {  get; set; }
        public string CodeBoilerplate { get; set; }
        public string UnitTestBoilerplate { get; set; }
        public int? CodeTaskSolutionId { get; set; }
        public bool IsPublished { get; set; }
    }
}
