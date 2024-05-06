#region

using HighCode.Application.Responses;
using HighCode.Application.Runners.Models;

#endregion

namespace HighCode.Application.ApiHandlers.Command.TaskSolution.TestCode;

public class TestCodeResponse : ResponseBase
{
    public TestCodeResult? TestResult { get; set; } = null;
}