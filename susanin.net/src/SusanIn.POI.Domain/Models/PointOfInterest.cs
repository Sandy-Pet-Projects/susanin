using Common.Domain.Interfaces;
using Common.Domain.Types;
using Common.Domain.ValueObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// Point of interest
/// </summary>
public class PointOfInterest : IEntity<PointOfInterest>
{
    private readonly List<DomainEvent<PointOfInterest>> _events;
    private int _version;

    /// <summary>
    /// Конструктор <see cref="PointOfInterest"/>
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    private PointOfInterest(Id<PointOfInterest> id)
    {
        Id = id;
        State = new PointOfInterestState();
        _events = new List<DomainEvent<PointOfInterest>>();
        _version = 0;
    }

    /// <inheritdoc />
    public Id<PointOfInterest> Id { get; }

    /// <summary>
    /// <see cref="PointOfInterestState"/>
    /// </summary>
    public PointOfInterestState State { get; }

    /// <summary>
    /// Создание <see cref="PointOfInterest"/>
    /// </summary>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <param name="name">Наименование <see cref="PointOfInterest"/></param>
    /// <param name="coordinates"><see cref="Coordinates"/></param>
    /// <returns><see cref="PointOfInterest"/></returns>
    public static PointOfInterest Create(Id<PointOfInterest> id, string name, Coordinates coordinates)
    {
        // todo добавить дополнительные проверки параметров создания сущности
        var pointOfInterest = new PointOfInterest(id);

        var pointOfInterestCreated = new PointOfInterestEvents.PointOfInterestCreated()
        {
            EntityId = pointOfInterest.Id,
            Name = name,
            Coordinate = coordinates,
        };
        pointOfInterest._events.Add(pointOfInterestCreated);

        pointOfInterest.State.Apply(pointOfInterestCreated);

        return pointOfInterest;
    }

    /// <summary>
    /// Загрузка <see cref="IEntity{T}"/> из хранилища
    /// </summary>
    /// <param name="repository"><see cref="IDomainEventRepository{T}"/></param>
    /// <param name="id"><see cref="Id{T}"/></param>
    /// <returns><see cref="IEntity{T}"/></returns>
    public static async Task<PointOfInterest> LoadAsync(IDomainEventRepository<PointOfInterest> repository, Id<PointOfInterest> id)
    {
        var entity = new PointOfInterest(id);
        var events = await repository.LoadAsync(id);
        foreach (var @event in events)
        {
            entity.Apply(@event);
        }

        return entity;
    }

    /// <summary>
    /// Сохранение <see cref="IEntity{T}"/> в хранилище
    /// </summary>
    /// <param name="repository"><see cref="IDomainEventRepository{T}"/></param>
    /// <returns><see cref="Task"/></returns>
    public async Task SaveAsync(IDomainEventRepository<PointOfInterest> repository)
    {
        await repository.SaveAsync(Id, _version, _events);
    }

    /// <summary>
    /// Переимновать <see cref="PointOfInterest"/>
    /// </summary>
    /// <param name="newName">Новое имя <see cref="PointOfInterest"/></param>
    // todo вместо string использовать пользовательский тип
    public void RenameTo(string newName)
    {
        if (newName != State.Name)
        {
            var pointOfInterestRenamed = new PointOfInterestEvents.PointOfInterestRenamed()
            {
                EntityId = Id,
                OldName = State.Name,
                NewName = newName,
            };
            State.Apply(pointOfInterestRenamed);
            _events.Add(pointOfInterestRenamed);
        }
    }

    /// <summary>
    /// Применение события <see cref="DomainEvent{T}"/>
    /// </summary>
    /// <param name="event"><see cref="DomainEvent{T}"/></param>
    private void Apply(DomainEvent<PointOfInterest> @event)
    {
        State.Apply(@event);
        _version++;
    }
}