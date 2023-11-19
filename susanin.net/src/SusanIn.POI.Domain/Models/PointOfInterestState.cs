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
    /// <inheritdoc />
    public Id<PointOfInterest> Id { get; private set; } = null!;

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
            case PointOfInterestEvents.PointOfInterestCreated created:
                Id = created.EntityId;
                Name = created.Name;
                Coordinate = created.Coordinate;
                break;
            case PointOfInterestEvents.PointOfInterestRenamed renamed:
                Name = renamed.NewName;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(@event));
        }

        Validate();
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