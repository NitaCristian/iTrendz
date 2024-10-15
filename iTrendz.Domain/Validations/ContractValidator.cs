using FluentValidation;
using iTrendz.Domain.Models;
using System.Diagnostics.Contracts;
using Contract = iTrendz.Domain.Models.Contract;

namespace iTrendz.Domain.Validations;

public class ContractValidator : AbstractValidator<Contract>
{
	public ContractValidator()
	{
		RuleFor(contract => contract.SignedOnDate)
			.LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
			.WithMessage("Signed date cannnot be in the future.");

		RuleFor(contract => contract.State)
			.IsInEnum().WithMessage("Contract state must ve a valid state.");

		RuleFor(contract => contract.Influencer)
			.NotNull().WithMessage("INfluenecer is requiered");

		RuleFor(contract => contract.Campaign)
			.NotNull().WithMessage("Campaign is requiered");

		//RuleFor(contract => contract.Posts)
		//	.NotNull().WithMessage("Post collection is required.")
		//	.Must(post => post.Count > 0)
		//	.WithMessage("At least one post is required for contract.")
		//	.When(contract => contract.Posts != null);

		//RuleFor(contract => contract.AgreedContent)
		//	.NotNull().WithMessage("Agreed content collection is requiered.")
		//	.Must(agreedContent => agreedContent.Count > 0)
		//	.WithMessage("At least one content agreement is requiered.")
		//	.When(contract => contract.AgreedContent != null); 

	}
}
