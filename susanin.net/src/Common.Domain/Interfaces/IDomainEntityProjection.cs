using Common.Domain.Types;

namespace Common.Domain.Interfaces;

/// <summary>
/// Состояние сущности
/// </summary>
/// <typeparam name="T">Тип сущности, см. <see cref="IDomainEntity{T}"/></typeparam>
public interface IDomainEntityProjection<T>
where T : IDomainEntity<T>
{
    /// <summary>
    /// <see cref="Id{T}"/>
    /// </summary>
    public Id<T> Id { get; }

    /// <summary>
    /// Применение события <see cref="IDomainEvent{T}"/>
    /// </summary>
    /// <param name="event"><see cref="IDomainEvent{T}"/></param>
    public void Apply(IDomainEvent<T> @event);
}