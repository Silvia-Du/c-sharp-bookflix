using System.ComponentModel.DataAnnotations;

namespace c_sharp_bookflix.Models.ValidationCustom
{
    public class IsUniqueFeature : ValidationAttribute
    {
        readonly BoolflixContext _ctx = new();
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //List<Feature> features = _ctx.Features.ToList();
            //Feature? existingFeature = _ctx.Features.First(x => x.Name == value);

            if (_ctx.Features.First(x => x.Name == value) is null)
            {
                return ValidationResult.Success;
            }

            return new ValidationResult("Il valore inserito esite gia, non è possibile duplicarlo");

        }
    }
}
