using MusicSchool.Domain;

namespace MusicSchool.Application;

public class EventWindowService : IEventWindowService
{
    private readonly IEventWindowRepository _eventWindowRepository;

    public EventWindowService(IEventWindowRepository eventWindowRepository)
    {
        _eventWindowRepository = eventWindowRepository;
    }

    public bool Create(EventWindow model)
    {
        try
        {
            _eventWindowRepository.Create(model);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete(EventWindow model)
    {
        try
        {
            _eventWindowRepository.Delete(model);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Update(EventWindow model)
    {
        try
        {
            _eventWindowRepository.Update(model);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public List<EventWindow> GetWeekEvents(DateTime monday)
    {
        List<EventWindow>? eventWindows = _eventWindowRepository.GetWeekEvents(monday);
        if (eventWindows == null)
        {
            return new List<EventWindow>();
        }

        return eventWindows;
    }
}