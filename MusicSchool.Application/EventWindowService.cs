using MusicSchool.Core;
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

    public List<EventWindow> GetWeekEvents(DateTime monday)
    {
        return _eventWindowRepository.GetWeekEvents(monday);
    }
}