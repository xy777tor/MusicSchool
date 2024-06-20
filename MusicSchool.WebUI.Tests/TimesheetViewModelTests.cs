using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Tests;

public class TimesheetViewModelTests
{
    [Fact]
    public void GetMondayTest()
    {
        // arrange
        TimesheetViewModel viewModel = new TimesheetViewModel() { RequiredDay = new DateTime(2024, 6, 10) };
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
}