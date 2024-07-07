using MusicSchool.Domain;

namespace MusicSchool.DataAccess;

public class EventWindowRepository : IEventWindowRepository
{
    private readonly MusicSchoolContext _dbContext;

    public EventWindowRepository(MusicSchoolContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Create(EventWindow eventWindow)
    {
        Entities.EventWindow newEventWindow = new Entities.EventWindow
        {
            Title = eventWindow.Title,
            StartDateTime = eventWindow.StartDateTime,
            EndDateTime = eventWindow.EndDateTime
        };

        _dbContext.eventWindows.Add(newEventWindow);

        _dbContext.SaveChanges();
    }

    public List<EventWindow>? GetWeekEvents(DateTime monday)
    {
        List<Entities.EventWindow> weekEvents = new();

        for (int i = 0; i < 7; i++)
        {
            weekEvents.AddRange(_dbContext.eventWindows.Where(s => s.StartDateTime.Date == monday.Date.AddDays(i)));
        }

        if (weekEvents.Count == 0)
        {
            return null;
        }

        List<EventWindow> domainWeekEvents = new List<EventWindow>();

        foreach (var weekEvent in weekEvents)
        {
            domainWeekEvents.Add(
                new EventWindow
                {
                    Title = weekEvent.Title,
                    StartDateTime = weekEvent.StartDateTime,
                    EndDateTime = weekEvent.EndDateTime
                });
        }

        return domainWeekEvents;
    }
}
