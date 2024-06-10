using MusicSchool.Core;

namespace MusicSchool.Domain;
public interface IEventWindowRepository
{
    void Add(EventWindow eventWindow);

    List<EventWindow> GetWeekEvents(DateTime monday);
}
