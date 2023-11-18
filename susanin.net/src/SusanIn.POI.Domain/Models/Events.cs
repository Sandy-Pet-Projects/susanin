using Common.Domain.Types;
using Common.Domain.ValueObjects;
using System;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// События POI
/// </summary>
public static class Events
{
    /// <summary>
    /// POI создана
    /// </summary>
    public class Created : DomainEvent<PointOfInterest>
    {
        /// <summary>
        /// <see cref="EntityId"/>
        /// </summary>
        public required EntityId<PointOfInterest> EntityId { get; init; }

        /// <summary>
        /// Наименование <see cref="PointOfInterest"/>
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// <see cref="Coordinates"/>
        /// </summary>
        public required Coordinates Coordinate { get; init; }

        /// <summary>
        /// Время создания события
        /// </summary>
        public DateTimeOffset CreatedAt { get; } = DateTimeOffset.UtcNow;
    }

    /// <summary>
    /// POI переименована
    /// </summary>
    public class Renamed : DomainEvent<PointOfInterest>
    {
        /// <summary>
        /// Старое наименование
        /// </summary>
        public required string? OldName { get; init; }

        /// <summary>
        /// Новое наименование
        /// </summary>
        public required string NewName { get; init; }
    }
}