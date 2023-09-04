using Common.Domain.Interfaces;
using Common.Domain.Types;
using System;
using System.Collections.Generic;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// Состояний <see cref="PointOfInterest"/>
/// </summary>
public class PointOfInterestState : IDomainEntityProjection<PointOfInterest>
{
    /// <summary>
    /// Конструктор <see cref="PointOfInterestState"/>
    /// </summary>
    /// <param name="events">Коллекция <see cref="IDomainEvent{T}"/></param>
    public PointOfInterestState(IEnumerable<IDomainEvent<PointOfInterest>> events)
    {
        foreach (var @event in events)
        {
            Apply(@event);
        }
    }

    /// <inheritdoc cref="IDomainEntityProjection{T}.Id"/>
    public EntityId<PointOfInterest> Id { get; private set; } = null!;

    /// <summary>
    /// Наименование <see cref="PointOfInterest"/>
    /// </summary>
    public string? Name { get; private set; }

    /// <inheritdoc />
    public void Apply(IDomainEvent<PointOfInterest> @event)
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