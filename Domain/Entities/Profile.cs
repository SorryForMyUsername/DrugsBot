using Domain.ValueObjects;
using Domain.Validators;

namespace Domain.Entities;

public sealed class Profile : BaseEntity<Profile>
{
    public Profile(string externalId, Email? email)
    {
        ExternalId = externalId;
        Email = email;
        
        ValidateEntity(new ProfileValidator());
    }
    
    /// <summary>
    /// Внешний идентификатор.
    /// </summary>
    public string ExternalId { get; private init; }
    
    /// <summary>
    /// Электронная почта.
    /// </summary>
    public Email? Email { get; private set; }
    
    // Навигационное свойство для связи с FavouriteDrug.
    public List<FavouriteDrug> FavouriteDrugs { get; private set; }
}