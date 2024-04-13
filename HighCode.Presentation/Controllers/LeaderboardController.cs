using HighCode.Presentation.Services;
using Microsoft.AspNetCore.Mvc;

namespace HighCode.Presentation.Controllers;

public class LeaderboardController : Controller
{
    private readonly StatisticService _statisticsService;
    public LeaderboardController(StatisticService statisticsService)
    {
        _statisticsService = statisticsService;
    }
    // GET
    public async Task<IActionResult> Index()
    {
        var rating = await _statisticsService.GetRatings();
        return View(rating);
    }
}