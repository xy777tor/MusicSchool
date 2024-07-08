namespace MusicSchool.Domain;

public class EventWindow
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
}
