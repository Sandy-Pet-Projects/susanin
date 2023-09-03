using Common.Domain.Interfaces;
using Common.Domain.Types;
using System;

namespace SusanIn.Domain.POI;

/// <summary>
/// События POI
/// </summary>
public static class Events
{
    /// <summary>
    /// POI создана
    /// </summary>
    public record Created : IDomainEvent<PointOfInterest>
    {
        /// <summary>
        /// Конструктор <see cref="Created"/>
        /// </summary>
        /// <param name="entityId"><see cref="EntityId"/></param>
        public Created(EntityId<PointOfInterest> entityId)
        {
            Id = Guid.NewGuid();
            EntityId = entityId;
        }

        /// <inheritdoc cref="IDomainEvent{T}.Id"/>
        public Guid Id { get; }

        /// <summary>
        /// <see cref="EntityId"/>
        /// </summary>
        public EntityId<PointOfInterest> EntityId { get; }
    }
}