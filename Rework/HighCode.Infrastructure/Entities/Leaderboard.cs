namespace HighCode.Infrastructure.Entities;

public class Leaderboard
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public User User { get; set; }
    public double Score { get; set; }
}