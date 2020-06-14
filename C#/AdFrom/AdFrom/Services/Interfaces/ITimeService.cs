namespace AdFrom.Services.Interfaces
{
    public interface ITimeService 
    {
        string GetTime();
        string AddDaysToTime(int days);
    }
}
