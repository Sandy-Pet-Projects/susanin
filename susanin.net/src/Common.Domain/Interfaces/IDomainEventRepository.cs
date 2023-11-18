using Common.Domain.Types;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Common.Domain.Interfaces;

/// <summary>
/// Репозиторий <see cref="DomainEvent{T}"/>
/// </summary>
/// <typeparam name="T"><see cref="IEntity{T}"/></typeparam>
public interface IDomainEventRepository<T>
    where T : IEntity<T>
{
    /// <summary>
    /// Загрузка коллекции <see cref="DomainEvent{T}"/> из хранилища
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <returns>Коллекция <see cref="DomainEvent{T}"/></returns>
    public Task<IEnumerable<DomainEvent<T>>> LoadAsync(Id<T> id);

    /// <summary>
    /// Сохранение коллекции <see cref="DomainEvent{T}"/> в хранилище
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <param name="events">Коллекция <see cref="DomainEvent{T}"/></param>
    /// <returns><see cref="Task{TResult}"/></returns>
    // todo добавить версию сущности
    public Task SaveAsync(Id<T> id, IEnumerable<DomainEvent<T>> events);
}