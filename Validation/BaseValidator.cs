using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation;

abstract class BaseValidator : IValidator
{
    public ValidationResult Validate(Report report)
    {
        ValidationResult result = ValidateCommonFields(report);
        if (result.IsValid)
        {
            result = ValidateSpecificFields(report);
        }
        return result;
    }

    protected ValidationResult ValidateCommonFields(Report report)
    {
        DateTime minTime = new DateTime(2020, 01, 01);
        if (report.Timestamp > DateTime.Now || report.Timestamp < minTime)
        {
            return ValidationResult.Failure("Invalid DateTime. You must enter between 2020-01-01 to now.");
        }
        if (report.Latitude < 29.5000 || report.Latitude > 33.5000)
        {
            return ValidationResult.Failure("Invalid latitud. You must enter letitud between 29.5000-33.5000");
        }
        if (report.Longitude < 34.0000 || report.Longitude > 36.0000)
        {
            return ValidationResult.Failure("Invalid longitud. You must enter longitud between 34.0000-36.0000");
        }
        if (string.IsNullOrEmpty(report.Description) || report.Description.Length < 10 || report.Description.Length > 500)
        {
            return ValidationResult.Failure("Invalid description. You must enter a description " +
                "between 10 to 500 characters");
        }
        return ValidationResult.Success();
    }

    protected abstract ValidationResult ValidateSpecificFields(Report report);
}