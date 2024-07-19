namespace Account.Common.Entity;

public class Food : BaseEntity
{
    public DateOnly CookingDate { get; set; }
    public string Title { get; set; }
    public int Count { get; set; }
    public List<IngredientInfo> IngredientInfoList { get; set; } = [];
}