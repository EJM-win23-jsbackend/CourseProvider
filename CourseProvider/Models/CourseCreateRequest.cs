
namespace CourseProvider.Models;

public class CourseCreateRequest
{
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
    public virtual List<AuthorCreateRequest>? Authors { get; set; }
    public virtual PricesCreateRequest? Prices { get; set; }
    public virtual ContentCreateRequest? Content { get; set; }
}

public class AuthorCreateRequest
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? AuthorImage { get; set; }
}

public class PricesCreateRequest
{
    public string? Currency { get; set; }
    public string? Price { get; set; }
    public string? Discount { get; set; }
}

public class ContentCreateRequest
{
    public string? Description { get; set; }
    public string[]? Includes { get; set; }
    public virtual List<ProgramDetailsCreateRequest>? ProgramDetails { get; set; }
}

public class ProgramDetailsCreateRequest
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
}