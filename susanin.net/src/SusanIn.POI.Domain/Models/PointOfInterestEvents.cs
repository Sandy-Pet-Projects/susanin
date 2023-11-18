using Common.Domain.Types;
using Common.Domain.ValueObjects;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// События POI
/// </summary>
public static class PointOfInterestEvents
{
    /// <summary>
    /// POI создана
    /// </summary>
    public class PointOfInterestCreated : DomainEvent<PointOfInterest>
    {
        /// <summary>
        /// Наименование <see cref="PointOfInterest"/>
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// <see cref="Coordinates"/>
        /// </summary>
        public required Coordinates Coordinate { get; init; }
    }

    /// <summary>
    /// POI переименована
    /// </summary>
    public class PointOfInterestRenamed : DomainEvent<PointOfInterest>
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