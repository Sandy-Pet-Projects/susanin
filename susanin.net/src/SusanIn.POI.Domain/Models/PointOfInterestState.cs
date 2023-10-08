using Common.Domain.Types;
using Common.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// Состояний <see cref="PointOfInterest"/>
/// </summary>
public sealed class PointOfInterestState : EntityState<PointOfInterest>
{
    /// <summary>
    /// <see cref="EntityId{T}"/>
    /// </summary>
    public EntityId<PointOfInterest> Id { get; private set; } = null!;

    /// <summary>
    /// Наименование <see cref="PointOfInterest"/>
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// <see cref="GeoCoordinate"/>
    /// </summary>
    public GeoCoordinate Coordinate { get; private set; } = null!;

    /// <summary>
    /// Создание <see cref="PointOfInterestState"/>
    /// </summary>
    /// <param name="events">Коллекция <see cref="DomainEvent{T}"/></param>
    /// <returns><see cref="PointOfInterestState"/></returns>
    public static PointOfInterestState Create(IEnumerable<DomainEvent<PointOfInterest>> events)
    {
        var state = new PointOfInterestState();
        foreach (var @event in events)
        {
            state.Apply(@event);
        }

        return state;
    }

    /// <inheritdoc />
    public override void Apply(DomainEvent<PointOfInterest> @event)
    {
        // todo Сделать как у Владика с динамическими методами
        switch (@event)
        {
            case Events.Created created:
                Id = created.EntityId;
                break;
            case Events.Renamed renamed:
                Name = renamed.NewName;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(@event));
        }
    }
}