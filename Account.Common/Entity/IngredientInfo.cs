namespace Account.Common.Entity;

public class IngredientInfo : BaseEntity
{
    public GeneralType Ingredient { get; set; }
    public long IngredientId { get; set; }
    public decimal Scale { get; set; }
    public decimal Amount { get; set; }
}