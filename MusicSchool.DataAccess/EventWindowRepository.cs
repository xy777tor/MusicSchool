using Microsoft.EntityFrameworkCore;
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

    public void Update(EventWindow eventWindow)
    {
        Entities.EventWindow? eventWindowToUpdate = _dbContext.eventWindows.Find(eventWindow.Id);

        if (eventWindowToUpdate is null)
        {
            return;
        }

        eventWindowToUpdate.Title = eventWindow.Title;
        eventWindowToUpdate.StartDateTime = eventWindow.StartDateTime;
        eventWindowToUpdate.EndDateTime = eventWindow.EndDateTime;

        _dbContext.eventWindows.Update(eventWindowToUpdate);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        Entities.EventWindow? eventWindowToRemove = _dbContext.eventWindows.Find(id);

        if (eventWindowToRemove is null)
        {
            return;
        }

        _dbContext.eventWindows.Remove(eventWindowToRemove);
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
                    Id = weekEvent.Id,
                    Title = weekEvent.Title,
                    StartDateTime = weekEvent.StartDateTime,
                    EndDateTime = weekEvent.EndDateTime
                });
        }

        return domainWeekEvents;
    }
}
