#region

using HighCode.Domain.Models;
using HighCode.Domain.Responses;

#endregion

namespace HighCode.Domain.ApiResponses.Solutions;

public class TestCodeResponse : ResponseBase
{
    public TestCodeResult? TestResult { get; set; } = null;
}