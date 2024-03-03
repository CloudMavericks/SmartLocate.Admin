namespace SmartLocate.Admin.Models;

public class ResultSet<T> where T : class
{
    public List<T> Items { get; set; } = [];

    public int TotalCount { get; set; }
}