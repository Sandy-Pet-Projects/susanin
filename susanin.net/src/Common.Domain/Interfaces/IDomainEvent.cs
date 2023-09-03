using System;

namespace Common.Domain.Interfaces;

/// <summary>
/// Доменное событие
/// </summary>
/// <typeparam name="T"><see cref="IDomainEntity{T}"/></typeparam>
public interface IDomainEvent<T>
    where T : IDomainEntity<T>
{
    /// <summary>
    /// Идентификатор события
    /// </summary>
    public Guid Id { get; }
}