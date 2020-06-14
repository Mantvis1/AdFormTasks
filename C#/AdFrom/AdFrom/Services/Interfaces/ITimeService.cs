namespace AdFrom.Services.Interfaces
{
    public interface ITimeService 
    {
        string GetCurrentTime();
        string AddDaysToTime(int days);
    }
}
