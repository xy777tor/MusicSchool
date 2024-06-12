using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Tests;

public class TimesheetViewModelTests
{
    [Fact]
    public void GetMondayTest()
    {
        // arrange
        TimesheetViewModel viewModel = new TimesheetViewModel();
        DateTime monday = DateTime.Parse("10.06.2024");
        DateTime sunday = DateTime.Parse("16.06.2024");
        DateTime thuesday = DateTime.Parse("11.06.2024");
        DateTime saturday = DateTime.Parse("14.06.2024");

        // act
        int mondayResult = viewModel.GetMonday(monday);
        int sundayResult = viewModel.GetMonday(sunday);
        int thuesdayResult = viewModel.GetMonday(thuesday);
        int saturdayResult = viewModel.GetMonday(saturday);

        // assert
        Assert.Equal(10, mondayResult);
        Assert.Equal(10, sundayResult);
        Assert.Equal(10, thuesdayResult);
        Assert.Equal(10, saturdayResult);
    }
}