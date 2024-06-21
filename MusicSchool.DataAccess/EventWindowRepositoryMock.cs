using MusicSchool.Core;
using MusicSchool.Domain;

namespace MusicSchool.DataAccess;

public class EventWindowRepositoryMock : IEventWindowRepository
{
    private List<EventWindow> _eventWindows = new List<EventWindow>();

    public void Create(EventWindow eventWindow)
    {
        _eventWindows.Add(eventWindow);
    }

    public List<EventWindow> GetWeekEvents(DateTime monday)
    {
        List<EventWindow> weekEvents = new List<EventWindow>();

        for (int i = 0; i < 7; i++)
        {
            weekEvents.AddRange(_eventWindows.FindAll(s => s.StartDateTime == monday.Date.AddDays(i)));
        }

        return weekEvents;
    }
}
