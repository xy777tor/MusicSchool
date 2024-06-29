namespace MusicSchool.DataAccess;

public class EventWindowRepositoryMock : Domain.IEventWindowRepository
{
    private List<Domain.EventWindow> _eventWindows = new List<Domain.EventWindow>();

    public void Create(Domain.EventWindow eventWindow)
    {
        _eventWindows.Add(eventWindow);
    }

    public List<Domain.EventWindow> GetWeekEvents(DateTime monday)
    {
        List<Domain.EventWindow> weekEvents = new List<Domain.EventWindow>();

        for (int i = 0; i < 7; i++)
        {
            weekEvents.AddRange(_eventWindows.FindAll(s => s.StartDateTime.Date == monday.Date.AddDays(i)));
        }

        return weekEvents;
    }
}
