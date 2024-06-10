using MusicSchool.Core;

namespace MusicSchool.Application;

public interface IEventWindowService
{
    bool Create(EventWindow model);
    List<EventWindow> GetWeekEvents(DateTime monday);
}
