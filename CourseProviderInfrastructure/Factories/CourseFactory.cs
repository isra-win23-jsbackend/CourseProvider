
using Azure.Core;
using CourseProviderInfrastructure.Data.Entities;
using CourseProviderInfrastructure.Models;

namespace CourseProviderInfrastructure.Factories;

public static class CourseFactory
{

    public static CourseEntity Create(CourseCreateRequest request)
    {
        return new CourseEntity
        {
            ImageUri = request.ImageUri,
            ImageHeadderUri = request.ImageHeadderUri,
            IsBestSeller = request.IsBestSeller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInProcent = request.LikesInProcent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name,
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Currency = request.Prices.Currency,
                Price = request.Prices.Price,
                Discount = request.Prices.Discount,
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                ProgamDetails = request.Content.ProgamDetails?.Select(pd => new ProgamDetailsItemEntity
                {
                    Id = pd.Id,
                    Title = pd.Title,
                    Description = pd.Description
                }).ToList()
            }
        };
    }


    public static CourseEntity Create(CourseUpdateRequest request)
    {
        return new CourseEntity
        {
            Id = request.Id,
            ImageUri = request.ImageUri,
            ImageHeadderUri = request.ImageHeadderUri,
            IsBestSeller = request.IsBestSeller,
            IsDigital = request.IsDigital,
            Categories = request.Categories,
            Title = request.Title,
            Ingress = request.Ingress,
            StarRating = request.StarRating,
            Reviews = request.Reviews,
            LikesInProcent = request.LikesInProcent,
            Likes = request.Likes,
            Hours = request.Hours,
            Authors = request.Authors?.Select(a => new AuthorEntity
            {
                Name = a.Name,
            }).ToList(),
            Prices = request.Prices == null ? null : new PricesEntity
            {
                Currency = request.Prices.Currency,
                Price = request.Prices.Price,
                Discount = request.Prices.Discount,
            },
            Content = request.Content == null ? null : new ContentEntity
            {
                Description = request.Content.Description,
                Includes = request.Content.Includes,
                ProgamDetails = request.Content.ProgamDetails?.Select(pd => new ProgamDetailsItemEntity
                {
                    Id = pd.Id,
                    Title = pd.Title,
                    Description = pd.Description
                }).ToList()
            }
        };
    }

    public  static Course Create(CourseEntity entity)
    {
        return new Course
        {
            Id = entity.Id,
            ImageUri = entity.ImageUri,
            ImageHeadderUri = entity.ImageHeadderUri,
            IsBestSeller = entity.IsBestSeller,
            IsDigital = entity.IsDigital,
            Categories = entity.Categories,
            Title = entity.Title,
            Ingress = entity.Ingress,
            StarRating = entity.StarRating,
            Reviews = entity.Reviews,
            LikesInProcent = entity.LikesInProcent,
            Likes = entity.Likes,
            Hours = entity.Hours,
            Authors = entity.Authors?.Select(a => new Author
            {
                Name = a.Name,
            }).ToList(),
            Prices = entity.Prices == null ? null : new Prices
            {
                Currency = entity.Prices.Currency,
                Price = entity.Prices.Price,
                Discount = entity.Prices.Discount,
            },
            Content = entity.Content == null ? null : new Content
            {
                Description = entity.Content.Description,
                Includes = entity.Content.Includes,
                ProgamDetails = entity.Content.ProgamDetails?.Select(pd => new ProgamDetailsItem
                {
                    Id = pd.Id,
                    Title = pd.Title,
                    Description = pd.Description
                }).ToList()
            }
        };
    }

}
