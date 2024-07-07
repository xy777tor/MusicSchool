namespace MusicSchool.Domain;

public interface IEventWindowRepository
{
    void Create(EventWindow eventWindow);

    List<EventWindow>? GetWeekEvents(DateTime monday);
}
