using MusicSchool.Core;
using MusicSchool.Domain;

namespace MusicSchool.DataAccess;

public class EventWindowRepository : IEventWindowRepository
{
    private List<EventWindow> _eventWindows = new List<EventWindow>();

    public void Add(EventWindow eventWindow)
    {
        _eventWindows.Add(eventWindow);
    }

    public List<EventWindow> GetWeekEvents(DateTime monday)
    {
        List<EventWindow> eventWindows = new List<EventWindow>();

        for (int i = 0; i < 8; i++)
        {
            eventWindows.AddRange(_eventWindows.FindAll(s => s.StartDateTime == monday.AddDays(i)));
        }

        return eventWindows;
    }
}
