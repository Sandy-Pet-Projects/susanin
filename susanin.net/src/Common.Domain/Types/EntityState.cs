using Common.Domain.Interfaces;

namespace Common.Domain.Types;

/// <summary>
/// Состояние <see cref="IDomainEntity{T}"/>
/// </summary>
/// <typeparam name="T">Тип сущности, см. <see cref="IDomainEntity{T}"/></typeparam>
public abstract class EntityState<T>
    where T : IDomainEntity<T>
{
    /// <summary>
    /// Конструктор <see cref="EntityState{T}"/>
    /// </summary>
    protected EntityState()
    {
    }

    /// <summary>
    /// <see cref="EntityId{T}"/>
    /// </summary>
    public EntityId<T> Id { get; protected set; } = null!;

    /// <summary>
    /// Применение события <see cref="IDomainEvent{T}"/>
    /// </summary>
    /// <param name="event"><see cref="IDomainEvent{T}"/></param>
    public abstract void Apply(IDomainEvent<T> @event);
}