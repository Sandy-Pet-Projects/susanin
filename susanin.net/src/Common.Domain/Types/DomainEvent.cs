using Common.Domain.Interfaces;
using System;

namespace Common.Domain.Types;

/// <summary>
/// Доменное событие
/// </summary>
/// <typeparam name="T"><see cref="IEntity{T}"/></typeparam>
public abstract class DomainEvent<T>
    where T : IEntity<T>
{
    /// <summary>
    /// Конструктор <see cref="DomainEvent{T}"/>
    /// </summary>
    /// <param name="id">Идентификатор события</param>
    protected DomainEvent(Id<DomainEvent<T>>? id = default)
    {
        Id = id ?? new Id<DomainEvent<T>>(Guid.NewGuid());
    }

    /// <summary>
    /// Идентификатор события
    /// </summary>
    public Id<DomainEvent<T>> Id { get; }

    /// <summary>
    /// <see cref="Id{T}"/>
    /// </summary>
    public required Id<T> EntityId { get; init; }

    /// <summary>
    /// Время создания события
    /// </summary>
    public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
}