using iTrendz.Domain.Interfaces;
using iTrendz.Domain.Models;
using MudBlazor;
using Platform = iTrendz.Domain.Models.Platform;

namespace iTrendz.MauiUI.Services;

public class LocalCampaignService : ICampaignService
{
    private readonly List<Campaign> _campaigns;

    public LocalCampaignService()
    {
        var campaign = new Campaign
        {
            Title = "Fitness Wear Launch",
            Description =
                "Help us launch our new line of performance fitness wear! We are seeking active influencers to showcase our gear, including running shoes, moisture-wicking tops, and compression shorts. Selected influencers will receive a full set of products and must create content showcasing the clothing during workouts or fitness routines.",
            ImageURL = "https://picsum.photos/300/",
            Brand = new Brand
            {
                UserName = "FitWear",
                ImageUrl = "https://picsum.photos/50/"
            },
            TimelineEvents =
            [
                new TimelineEvent("Campaign Created", "The campaign was successfully set up and is now ready for further configuration.", timestamp: new DateTime(2024, 3, 5), type: EventType.Info),
                new TimelineEvent("Initial Creators Invited", "An invitation was sent to a select group of creators based on the brand's preferences.", timestamp: new DateTime(2024, 3, 7), type: EventType.Info),
                new TimelineEvent("5 Creators Accepted the Invitation", "Five creators agreed to participate in the campaign and began their onboarding process.", timestamp: new DateTime(2024, 3, 10), type: EventType.Positive),
                new TimelineEvent("Budget Adjustment Required", "The campaign budget exceeded the initial projection due to higher engagement expectations. A revision was needed.", timestamp: new DateTime(2024, 3, 14), type: EventType.Negative),
                new TimelineEvent("Content Submission Deadline Reminder", "A reminder was sent to all participating creators about the upcoming content submission deadline on March 18.", timestamp: new DateTime(2024, 3, 15), type: EventType.Info),
                new TimelineEvent("Final Content Submitted for Review", "All creators submitted their final content for review before approval.", timestamp: new DateTime(2024, 3, 18), type: EventType.Warning),
                new TimelineEvent("Content Approval Meeting Held", "The brand reviewed the content with internal stakeholders and provided feedback for revisions.", timestamp: new DateTime(2024, 3, 22), type: EventType.Warning),
                new TimelineEvent("Campaign Launch", "The campaign officially launched across multiple social media platforms, with all approved content posted by creators.", timestamp: new DateTime(2024, 3, 31), type: EventType.Positive),
                new TimelineEvent("Campaign Performance Report Generated", "An initial performance report was generated, indicating positive trends in engagement and reach.", timestamp: new DateTime(2024, 4, 5), type: EventType.Info),
                new TimelineEvent("Campaign Successfully Completed", "The campaign ended, meeting most of its goals in terms of reach and engagement. Final reports were sent to the brand.", timestamp: new DateTime(2024, 4, 11), type: EventType.Positive)
            ],
            CampaignDetails = new CampaignDetails
            {
                StartDate = new DateTime(2024, 2, 10),
                EndDate = new DateTime(2024, 2, 28),
                CampaignType = "Product Promotion",
                TotalPosts = 30,
                TotalCreators = 10,
                CurrentCreators = 5,
                DemographicData = [15, 30, 45, 10],
                DemographicLabels = ["America", "Romania", "United Kingdom", "Canada"],
                AgeGroupData = [15, 30, 45, 10],
                AgeGroupCategories = ["18-24", "25-34", "35-44", "45-54"],
            },
            CampaignMetrics = new()
            {
                Views = 13100,
                Likes = 9100,
                Comments = 6200,
                Shares = 20700,
                Reach = 12_600,
                Engagement = 3000,
            },
            BudgetStatistics = new()
            {
                InitialBudget = 10000,
                RemainingBudget = 4500,
                BudgetHistoryData = [10000, 8500, 6000, 4500],
                BudgetHistoryLabels = ["January", "February", "March", "April"],
                BudgetAllocationData = [50, 30, 20],
                BudgetAllocationLabels = ["Marketing", "Development", "Operations"]
            },
            InfluencerRequirements = new InfluencerRequirements
            {
                MinimumFollowers = 50_000,
                AverageViews = 10_000,
                Audience = "Fitness Enthusiasts"
            },
            Deliverables =
            [
                new PlatformDeliverable
                {
                    Platform = new Platform { Icon = Icons.Custom.Brands.Instagram, Name = "Instagram" },
                    ContentRequirements =
                    [
                        new ContentRequirement
                        {
                            ContentType = "Story",
                            Description = "Up to 15 seconds per story, vertical format (1080 x 1920 pixels), must highlight key features of the gadget, include engaging visuals and polls or questions for interaction."
                        },

                        new ContentRequirement
                        {
                            ContentType = "Posts",
                            Description = "Square (1080 x 1080 pixels) or landscape (1080 x 566 pixels), captions limited to 2,200 characters, must include relevant hashtags and a clear call-to-action (e.g., 'Check out the full review on my blog!')."
                        },

                        new ContentRequirement
                        {
                            ContentType = "Reels",
                            Description = "Up to 60 seconds, vertical format, showcase the gadget in use, include trending audio, and provide quick tips or highlights."
                        }
                    ]
                },
                new PlatformDeliverable
                {
                    Platform = new Platform { Icon = Icons.Custom.Brands.TikTok, Name = "TikTok" },
                    ContentRequirements =
                    [
                        new ContentRequirement
                        {
                            ContentType = "Short Videos",
                            Description = "15 to 60 seconds in length, vertical format (1080 x 1920 pixels), must include music or sound clips, focus on engaging demonstrations or unboxing experiences, and follow current TikTok trends."
                        }
                    ]
                },
                new PlatformDeliverable
                {
                    Platform = new Platform { Icon = Icons.Custom.Brands.YouTube, Name = "YouTube" },
                    ContentRequirements =
                    [
                        new ContentRequirement
                        {
                            ContentType = "Long-form Videos",
                            Description = "Minimum resolution of 720p, video length of 8+ minutes, must provide in-depth reviews, comparisons, and demonstrations, and include a compelling title and description for SEO optimization."
                        },
                        new ContentRequirement
                        {
                            ContentType = "Shorts",
                            Description = "Up to 60 seconds, vertical format, should highlight the gadget's standout features quickly, engaging hook in the first few seconds, and can include popular music."
                        },
                        new ContentRequirement
                        {
                            ContentType = "Mid-Roll Ads",
                            Description = "Should be placed strategically within videos longer than 8 minutes, clearly indicated and relevant to the gadget being reviewed, ensure smooth transitions into and out of the ad segment."
                        }
                    ]
                }
            ]
        };

        _campaigns = Enumerable.Repeat(campaign, 5).ToList();
    }

    public Task<Campaign> GetCampaignAsync(int campaignId)
    {
        return Task.FromResult(_campaigns.First());
    }

    public Task<IEnumerable<Campaign>?> GetCampaignsAsync()
    {
        return Task.FromResult<IEnumerable<Campaign>?>(_campaigns);
    }

    public Task<bool> DeleteCampaignAsync(int campaignId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> TogglePinCampaignAsync(int campaignId)
    {
        throw new NotImplementedException();
    }
}