using Domain.Interface;
using MediatR;

namespace Domain.Events;

/// <summary>
/// Доменное событие обновления единицы лекарства.
/// </summary>
public sealed class DrugItemUpdatedEvent : IDomainEvent
{
    public Guid Id { get; private set; }

    public int Count { get; private set; }
    
    internal DrugItemUpdatedEvent(Guid id, int count)
    {
        Id = id;
        Count = count;
    }
}