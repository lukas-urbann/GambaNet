using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace GambaNet.Domain.Validations;

public class Capitalize : ValidationAttribute, IClientModelValidator
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        switch (value)
        {
            case null:
            case string text when text == String.Empty:
                return ValidationResult.Success;
            case string text when text.First() >= 'A' && text.First() <= 'Z'
                                  || text.First() == 'Š' || text.First() == 'Č' || text.First() == 'Ř' || text.First() == 'Ž'
                                  || text.First() == 'Ý' || text.First() == 'Á' || text.First() == 'Í' || text.First() == 'É'
                                  || text.First() == 'Ú' || text.First() == 'Ď' || text.First() == 'Ň' || text.First() == 'Ó'
                                  || text.First() == 'Ť' || text.First() == 'Ě' || text.First() == 'Ů':
                return ValidationResult.Success;
            case string text:
                return new ValidationResult($"The {validationContext.MemberName} field does not contain the first capital letter.");
            default:
                throw new NotImplementedException($"The {nameof(Capitalize)} is not implemented for the type: {value.GetType()}");
        }
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        if (context.Attributes.ContainsKey("data-val") == false)
        {
            context.Attributes.Add("data-val", "true");
        }
            
        context.Attributes.Add("data-val-capitalize", $"The {context.ModelMetadata.Name} field does not contain the first capital letter.");
    }
}