namespace MusicSchool.Domain;

public interface IEventWindowService
{
    bool Create(EventWindow model);

    List<EventWindow> GetWeekEvents(DateTime monday);
}
