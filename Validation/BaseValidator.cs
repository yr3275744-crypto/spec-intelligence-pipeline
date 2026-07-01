using IntelligencePipeline.Models.Reports;

namespace IntelligencePipeline.Validation;

abstract class BaseValidator : IValidator
{
    public ValidationResult Validate(Report report)
    {

    }

    protected ValidationResult ValidateCommonFields(Report report)
    {
        DateTime minTime = new DateTime(2020, 01, 01);
        if (report.Timestamp > DateTime.Now || report.Timestamp < minTime)
        {
            return ValidationResult.Failure("Invalid DateTime. You must enter between 2020-01-01 to now.");
        }

        return ValidationResult.Success();
    }

    protected abstract ValidationResult ValidateSpecificFields(Report report);
}