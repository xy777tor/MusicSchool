using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Tests;

public class TimesheetViewModelTests
{
    [Fact]
    public void GetMondayTest()
    {
        // arrange
        TimesheetViewModel viewModel = new() { RequiredDay = new DateTime(2024, 6, 10) };
        DateTime monday = new DateTime(2024, 6, 10);
        DateTime sunday = new DateTime(2024, 6, 16);
        DateTime thuesday = new DateTime(2024, 6, 11);
        DateTime saturday = new DateTime(2024, 6, 14);

        // act
        DateTime mondayResult = viewModel.GetMonday(monday);
        DateTime sundayResult = viewModel.GetMonday(sunday);
        DateTime thuesdayResult = viewModel.GetMonday(thuesday);
        DateTime saturdayResult = viewModel.GetMonday(saturday);

        // assert
        Assert.Equal(monday, mondayResult);
        Assert.Equal(monday, sundayResult);
        Assert.Equal(monday, thuesdayResult);
        Assert.Equal(monday, saturdayResult);
    }

    [Fact]
    public void GetEventWindowViewModelsByDateTest()
    {
        // arrange
        DateTime requiredDay = new(2024, 6, 10);
        TimesheetViewModel viewModel = new() { RequiredDay = requiredDay };
        List<EventWindowViewModel> eventWindowViewModels = new();

        const int weekDays = 7;
        const int minEventWindowsCount = 3;
        const int maxEventWindowsCount = 9;

        for (int i = minEventWindowsCount; i < weekDays + minEventWindowsCount; i++)
        {
            for (int j = 0; j < i; j++)
            {
                eventWindowViewModels.Add(new()
                {
                    Title = "Title",
                    StartDateTime = new DateTime(DateOnly.FromDateTime(requiredDay.AddDays(i - minEventWindowsCount)),
                                                 new TimeOnly(0, j)),
                    EndDateTime = new DateTime(DateOnly.FromDateTime(requiredDay.AddDays(i - minEventWindowsCount)),
                                               new TimeOnly(0, 2 * j + 1))
                });
            }
        }

        viewModel.EventWindows.AddRange(eventWindowViewModels);

        // act
        List<EventWindowViewModel> minResult = viewModel.GetEventWindowViewModelsByDate(requiredDay);
        List<EventWindowViewModel> maxResult = viewModel.GetEventWindowViewModelsByDate(requiredDay.AddDays(weekDays - 1));

        // assert
        Assert.Equal(minEventWindowsCount, minResult.Count);
        Assert.Equal(maxEventWindowsCount, maxResult.Count);
    }
}