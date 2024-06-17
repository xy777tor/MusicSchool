using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Tests;

public class TimesheetViewModelTests
{
    [Fact]
    public void GetMondayTest()
    {
        // arrange
        TimesheetViewModel viewModel = new TimesheetViewModel(DateTime.Parse("10.06.2024"));
        DateTime monday = DateTime.Parse("10.06.2024");
        DateTime sunday = DateTime.Parse("16.06.2024");
        DateTime thuesday = DateTime.Parse("11.06.2024");
        DateTime saturday = DateTime.Parse("14.06.2024");

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