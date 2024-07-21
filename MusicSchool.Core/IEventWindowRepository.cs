namespace MusicSchool.Domain;

public interface IEventWindowRepository
{
    void Create(EventWindow eventWindow);
    List<EventWindow>? GetWeekEvents(DateTime monday);
    void Delete(int id);

    void Update(EventWindow eventWindow);
}
