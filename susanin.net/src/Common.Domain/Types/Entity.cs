using Common.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Domain.Types;

/// <summary>
/// Сущность
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public abstract class Entity<T>
    where T : Entity<T>, new()
{
    /// <summary>
    /// Конструктор <see cref="Entity{T}"/>
    /// </summary>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    protected Entity(EntityId<T>? id = default)
    {
        Id = id ?? new EntityId<T>();
    }

    /// <summary>
    /// <see cref="EntityId{T}"/>
    /// </summary>
    public EntityId<T> Id { get; }

    /// <summary>
    /// Коллекция <see cref="DomainEvent{T}"/>
    /// </summary>
    protected List<DomainEvent<T>> Events => new();

    // todo добавить версию сущности

    /// <summary>
    /// Загрузка <see cref="Entity{T}"/> из хранилища
    /// </summary>
    /// <param name="repository"><see cref="IDomainEventRepository{T}"/></param>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    /// <returns><see cref="Entity{T}"/></returns>
    public static T Load(IDomainEventRepository<T> repository, EntityId<T> id)
    {
        var events = repository.Load(id);
        var entity = new T();
        foreach (var @event in events)
        {
            entity.Apply(@event);
        }

        return entity;
    }

    /// <summary>
    /// Сохранение <see cref="Entity{T}"/> в хранилище
    /// </summary>
    /// <param name="repository"><see cref="IDomainEventRepository{T}"/></param>
    /// <returns><see cref="Task"/></returns>
    public async Task SaveAsync(IDomainEventRepository<T> repository)
    {
        await repository.SaveAsync(Id, Events);
    }

    /// <summary>
    /// Применение <see cref="DomainEvent{T}"/>
    /// </summary>
    /// <param name="event"><see cref="DomainEvent{T}"/></param>
    protected abstract void Apply(DomainEvent<T> @event);
}