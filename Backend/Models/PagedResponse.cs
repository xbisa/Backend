namespace Backend.Models;

public class Meta
{
    public int TotalCount { get; set; }
}

public class PagedResponse<T>
{
    public required List<T> Data { get; set; }
    public required Meta Meta { get; set; }
}
