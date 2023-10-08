using System;

namespace Common.Domain.Types;

/// <summary>
/// Доменное событие
/// </summary>
/// <typeparam name="T"><see cref="Entity{T}"/></typeparam>
public abstract class DomainEvent<T>
    where T : Entity<T>
{
    /// <summary>
    /// Конструктор <see cref="DomainEvent{T}"/>
    /// </summary>
    /// <param name="id">Идентификатор события</param>
    protected DomainEvent(Guid? id = default)
    {
        Id = id ?? Guid.NewGuid();
    }

    /// <summary>
    /// Идентификатор события
    /// </summary>
    public Guid Id { get; }
}