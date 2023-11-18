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
    /// <summary>
    /// Конструктор <see cref="PointOfInterest"/>
    /// </summary>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    private PointOfInterest(EntityId<PointOfInterest> id)
    {
        Id = id;
        State = new PointOfInterestState(Id);
        Events = new List<DomainEvent<PointOfInterest>>();
    }

    /// <inheritdoc />
    public EntityId<PointOfInterest> Id { get; }

    /// <summary>
    /// <see cref="PointOfInterestState"/>
    /// </summary>
    public PointOfInterestState State { get; private set; }

    /// <summary>
    /// Коллекция <see cref="DomainEvent{T}"/>
    /// </summary>
    private List<DomainEvent<PointOfInterest>> Events { get; }

    /// <summary>
    /// Создание <see cref="PointOfInterest"/>
    /// </summary>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    /// <param name="name">Наименование <see cref="PointOfInterest"/></param>
    /// <param name="coordinates"><see cref="Coordinates"/></param>
    /// <returns><see cref="PointOfInterest"/></returns>
    public static PointOfInterest Create(EntityId<PointOfInterest> id, string name, Coordinates coordinates)
    {
        // todo добавить дополнительные проверки параметров создания сущности
        var pointOfInterest = new PointOfInterest(id);

        var created = new Events.Created()
        {
            EntityId = pointOfInterest.Id,
            Name = name,
            Coordinate = coordinates,
        };
        pointOfInterest.Events.Add(created);

        pointOfInterest.State = new PointOfInterestState(pointOfInterest.Id);
        pointOfInterest.State.Apply(created);
        pointOfInterest.State.Validate();

        return pointOfInterest;
    }

    /// <summary>
    /// Загрузка <see cref="IEntity{T}"/> из хранилища
    /// </summary>
    /// <param name="repository"><see cref="IDomainEventRepository{T}"/></param>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    /// <returns><see cref="IEntity{T}"/></returns>
    public static PointOfInterest Load(IDomainEventRepository<PointOfInterest> repository, EntityId<PointOfInterest> id)
    {
        var entity = new PointOfInterest(id);
        var events = repository.Load(id);
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
        await repository.SaveAsync(Id, Events);
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
            var renamed = new Events.Renamed()
            {
                OldName = State.Name,
                NewName = newName,
            };
            State.Apply(renamed);
            Events.Add(renamed);
        }
    }

    /// <summary>
    /// Применение события <see cref="DomainEvent{T}"/>
    /// </summary>
    /// <param name="event"><see cref="DomainEvent{T}"/></param>
    private void Apply(DomainEvent<PointOfInterest> @event)
    {
        State.Apply(@event);
    }
}