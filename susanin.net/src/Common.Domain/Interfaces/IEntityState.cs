using Common.Domain.Types;

namespace Common.Domain.Interfaces;

/// <summary>
/// Состояние <see cref="IEntity{T}"/>
/// </summary>
/// <typeparam name="T">Тип сущности, см. <see cref="IEntity{T}"/></typeparam>
public interface IEntityState<T>
    where T : IEntity<T>
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public EntityId<T> Id { get; }

    /// <summary>
    /// Применение события <see cref="DomainEvent{T}"/>
    /// </summary>
    /// <param name="event"><see cref="DomainEvent{T}"/></param>
    public void Apply(DomainEvent<T> @event);

    /// <summary>
    /// Проверка валидность состояния
    /// </summary>
    public void Validate();
}