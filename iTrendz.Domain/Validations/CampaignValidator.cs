using FluentValidation;
using iTrendz.Domain.Models;

namespace iTrendz.Domain.Validations;

public class CampaignValidator : AbstractValidator<Campaign>
{
	public CampaignValidator()
	{
		RuleFor(campaign => campaign.Title)
			.NotEmpty().WithMessage("Title is required.")
			.Length(3, 200).WithMessage("Title must be betweend 3 and 200 characters.");

		RuleFor(campaign => campaign.Description)
			.Length(1, 2000).WithMessage("Description must be at most 2000 characters.");

		RuleFor(campaign => campaign.ImageUrl)
			.Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
			.When(camapign => !string.IsNullOrEmpty(camapign.ImageUrl))
			.WithMessage("ImageUrl must be a valid URL.");

		RuleFor(campaign => campaign.Brand)
			.NotNull().WithMessage("Brand is required");

		RuleFor(campaign => campaign.Budget)
			.GreaterThan(0).WithMessage("Budget must be greater than 0");

		RuleFor(campaign => campaign.ApplicationDeadline)
			.GreaterThan(DateTime.Now).WithMessage("Application deadline must be in the future");
		RuleFor(campaign => campaign.Period)
			.NotNull().WithMessage("Period is required.");

		RuleFor(campaign => campaign.CreatorLimit)
			.GreaterThan(0).When(campaign => campaign.CreatorLimit.HasValue)
			.WithMessage("Creator limit must be greater than 0");

		RuleFor(campaign => campaign.Criteria)
			.NotNull().WithMessage("Qualification criteria is required");
		RuleFor(campaign => campaign.Requirements)
			.NotNull().WithMessage("Requirments are required");

		// State, Type, Niches
	}
}
