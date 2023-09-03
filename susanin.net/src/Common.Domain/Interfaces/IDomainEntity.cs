using Common.Domain.Types;
using System.Collections.Generic;

namespace Common.Domain.Interfaces;

/// <summary>
/// Сущность
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IDomainEntity<T>
    where T : IDomainEntity<T>
{
    /// <summary>
    /// <see cref="EntityId{T}"/>
    /// </summary>
    public EntityId<T> Id { get; }

    /// <summary>
    /// Коллекция событий <see cref="IDomainEvent{T}"/>
    /// </summary>
    public IReadOnlyCollection<IDomainEvent<T>> Events { get; }
}