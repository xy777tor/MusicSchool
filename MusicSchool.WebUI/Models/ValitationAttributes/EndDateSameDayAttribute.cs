using System.ComponentModel.DataAnnotations;
using MusicSchool.WebUI.Models;

namespace MusicSchool.WebUI.Models.ValitationAttributes;

public class EndDateSameDayAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        return false;
    }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (validationContext.ObjectInstance is EventWindowViewModel model && value is DateTime endDateTime)
        {
            if (model.StartDateTime.Date == endDateTime.Date) return ValidationResult.Success;
        }

        return base.IsValid(value, validationContext);
    }
}
