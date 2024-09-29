using NArchitecture.Core.Application.Responses;

namespace Application.Features.Announcements.Queries.GetById;

public class GetByIdAnnouncementResponse : IResponse
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
}