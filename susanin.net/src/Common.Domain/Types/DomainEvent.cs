using Common.Domain.Interfaces;
using System;
using System.Text.Json.Serialization;

namespace Common.Domain.Types;

/// <summary>
/// Доменное событие
/// </summary>
/// <typeparam name="T"><see cref="IEntity{T}"/></typeparam>
public abstract class DomainEvent<T>
    where T : IEntity<T>
{
    /// <summary>
    /// Идентификатор события
    /// </summary>
    [JsonInclude]
    public Id<DomainEvent<T>> Id { get; private init; } = new Id<DomainEvent<T>>(Guid.NewGuid());

    /// <summary>
    /// <see cref="Id{T}"/>
    /// </summary>
    public required Id<T> EntityId { get; init; }

    /// <summary>
    /// Время создания события
    /// </summary>
    [JsonInclude]
    public DateTimeOffset CreatedAt { get; private init; } = DateTimeOffset.UtcNow;
}