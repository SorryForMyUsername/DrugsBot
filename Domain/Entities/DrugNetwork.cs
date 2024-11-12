namespace Domain.Entities;

public class DrugNetwork
{
    // Навигационное свойство для связи с DrugStore
    public ICollection<DrugStore> DrugStores { get; private set; } = new List<DrugStore>();
}