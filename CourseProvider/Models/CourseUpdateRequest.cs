
namespace CourseProvider.Models;

public class CourseUpdateRequest
{
    public string Id { get; set; } = null!;
    public string? ImageUri { get; set; }
    public string? ImageHeaderUri { get; set; }
    public bool IsBestSeller { get; set; }
    public bool IsDigital { get; set; }
    public string[]? Categories { get; set; }
    public string? Title { get; set; }
    public string? Ingress { get; set; }
    public string? StarRating { get; set; }
    public string? Reviews { get; set; }
    public string? LikesInProcent { get; set; }
    public string? Likes { get; set; }
    public string? Hours { get; set; }
    public virtual List<AuthorUpdateRequest>? Authors { get; set; }
    public virtual PricesUpdateRequest? Prices { get; set; }
    public virtual ContentUpdateRequest? Content { get; set; }
}

public class AuthorUpdateRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? AuthorImage { get; set; }
}

public class PricesUpdateRequest
{
    public string? Currency { get; set; }
    public string? Price { get; set; }
    public string? Discount { get; set; }
}

public class ContentUpdateRequest
{
    public string? Description { get; set; }
    public string[]? Learning { get; set; }
    public string[]? Includes { get; set; }
    public virtual List<ProgramDetailsUpdateRequest>? ProgramDetails { get; set; }
}

public class ProgramDetailsUpdateRequest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}

