namespace Laboratorul5.Models;

public class Category
{
    public int Id { get; set; }
    public string CategoryName { get; set; }

    public ICollection<Article> Articles { get; set; }
}