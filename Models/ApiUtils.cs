namespace GoalFundApi.Models;

public class Empty {};
public class ApiResponse<TMeta, TData> where TMeta: new()
{
    public TMeta Meta { get; set; } = new();
    public TData Data { get; set; }
}

public class ApiResponse<TData> : ApiResponse<Empty, TData> {}

public class SearchMeta
{
    public int ReturnedResults { get; set; }
    public int TotalResults { get; set; }
}

public class SearchResults<TData>
{
    public int ReturnedResults { get; set; }
    public int TotalResults { get; set; }
    public IEnumerable<TData> Results { get; set; }
}