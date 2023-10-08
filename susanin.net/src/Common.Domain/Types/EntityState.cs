namespace Common.Domain.Types;

/// <summary>
/// Состояние <see cref="Entity{T}"/>
/// </summary>
/// <typeparam name="T">Тип сущности, см. <see cref="Entity{T}"/></typeparam>
public abstract class EntityState<T>
    where T : Entity<T>, new()
{
    /// <summary>
    /// Конструктор <see cref="EntityState{T}"/>
    /// </summary>
    protected EntityState()
    {
    }

    /// <summary>
    /// Применение события <see cref="DomainEvent{T}"/>
    /// </summary>
    /// <param name="event"><see cref="DomainEvent{T}"/></param>
    public abstract void Apply(DomainEvent<T> @event);
}