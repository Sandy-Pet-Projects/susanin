using Common.Domain.Interfaces;
using Common.Domain.Types;
using System;
using System.Collections.Generic;

namespace SusanIn.Domain.POI;

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

    /// <inheritdoc />
    public Id<PointOfInterest> Id { get; private set; } = null!;

    /// <inheritdoc />
    public void Apply(IDomainEvent<PointOfInterest> @event)
    {
        // todo Сделать как у Владика с динамическими методами
        switch (@event)
        {
            case Events.Created created:
                Id = created.Id;
                break;
            case Events.Activated activated:
                break;
            case Events.ApprovedByModerator approvedByModerator:
                break;
            case Events.Copied copied:
                break;
            case Events.Deactivated deactivated:
                break;
            case Events.Deleted deleted:
                break;
            case Events.Edited edited:
                break;
            case Events.Published published:
                break;
            case Events.RejectedByModerator rejectedByModerator:
                break;
            case Events.SentToModerator sentToModerator:
                break;
            case Events.Unpublished unpublished:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(@event));
        }
    }
}