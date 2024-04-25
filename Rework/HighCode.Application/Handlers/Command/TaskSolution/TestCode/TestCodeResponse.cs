#region

using HighCode.Application.Responses;
using HighCode.Application.Runners.Models;

#endregion

namespace HighCode.Application.Handlers.Command.TaskSolution.TestCode;

public class TestCodeResponse : ResponseBase
{
    public TestCodeResult? TestResult { get; set; } = null;
}