using Common.Domain.Interfaces;
using Common.Domain.Types;
using Common.Domain.ValueObjects;
using System;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// Состояний <see cref="PointOfInterest"/>
/// </summary>
public sealed class PointOfInterestState : IEntityState<PointOfInterest>
{
    /// <summary>
    /// Конструктор <see cref="PointOfInterestState"/>
    /// </summary>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    public PointOfInterestState(EntityId<PointOfInterest> id)
    {
        Id = id;
    }

    /// <inheritdoc />
    public EntityId<PointOfInterest> Id { get; private set; }

    /// <summary>
    /// Наименование <see cref="PointOfInterest"/>
    /// </summary>
    public string Name { get; private set; } = null!;

    /// <summary>
    /// <see cref="Coordinates"/>
    /// </summary>
    public Coordinates Coordinate { get; private set; } = null!;

    /// <inheritdoc />
    public void Apply(DomainEvent<PointOfInterest> @event)
    {
        // todo Сделать как у Владика с динамическими методами
        switch (@event)
        {
            case Events.Created created:
                Id = created.EntityId;
                Name = created.Name;
                Coordinate = created.Coordinate;
                break;
            case Events.Renamed renamed:
                Name = renamed.NewName;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(@event));
        }
    }

    /// <inheritdoc cref="IEntityState{T}.Validate"/>
    public void Validate()
    {
        if (Id == null
            || Name == null
            || Coordinate == null)
        {
            throw new Exception();
        }
    }
}