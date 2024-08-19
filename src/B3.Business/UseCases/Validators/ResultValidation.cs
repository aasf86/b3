using System.ComponentModel.DataAnnotations;

namespace B3.Business.UseCases.Validators
{
    public class ResultValidation
    {
        public ResultValidation(List<ValidationResult> validation)
        {            
            Validation = validation;
        }
        public bool IsSuccess => !Validation.Any();
        public List<ValidationResult> Validation { get; set; } = new List<ValidationResult>();
    }
}
