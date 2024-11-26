using MediatR;

namespace Domain.Interface;

/// <summary>
/// Интерфейс доменных событий.
/// </summary>
public interface IDomainEvent : INotification;