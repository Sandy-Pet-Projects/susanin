using Common.Domain.Types;

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