using FluentValidation;
using iTrendz.Domain.Models;

namespace iTrendz.Domain.Validations;

public class CampaignValidator : AbstractValidator<Campaign>
{
	public CampaignValidator()
	{
		RuleFor(campaign => campaign.Title)
			.NotEmpty().WithMessage("Title is required. ")
			.Length(3, 100).WithMessage("Title mus be betweend 3 and 100 characters.");

		RuleFor(campaign => campaign.Description)
			.NotEmpty().WithMessage("Description required. ")
			.MinimumLength(10).WithMessage("MUst be at least 10 characters long");

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
			.WithMessage("CReator limit must be greater than 0");

		RuleFor(campaign => campaign.Criteria)
			.NotNull().WithMessage("Qualification criteria is required");

		RuleFor(campaign => campaign.Metrics)
			.NotNull().WithMessage("Metrics are required");
		RuleFor(campaign => campaign.Requirements)
			.NotNull().WithMessage("Requirments are required");
		RuleFor(campaign => campaign.Criteria)
			.NotNull().WithMessage("Criteria are required");

	}
}
