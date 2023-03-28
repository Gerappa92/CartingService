using FluentValidation;

namespace CartingService.Web.Extensions;

public static class ValidationExtensions
{
    public static IDictionary<string, string[]> ToDictionary(this ValidationException validationException)
    {
        return validationException.Errors
            .GroupBy(x => x.PropertyName)
            .ToDictionary(
                g => g.Key,
                g => g.Select(x => x.ErrorMessage).ToArray()
            );
    }
}