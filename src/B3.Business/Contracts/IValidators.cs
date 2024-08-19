using B3.Business.UseCases.Validators;

namespace B3.Business.Contracts
{
    public interface IValidators
    {
        ResultValidation Validate(object entity);
    }
}
