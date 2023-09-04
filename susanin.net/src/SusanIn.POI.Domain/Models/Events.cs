using Common.Domain.Interfaces;
using Common.Domain.Types;
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
    public record Created : IDomainEvent<PointOfInterest>
    {
        /// <summary>
        /// Конструктор <see cref="Created"/>
        /// </summary>
        public Created()
        {
            Id = Guid.NewGuid();
        }

        /// <inheritdoc cref="IDomainEvent{T}.Id"/>
        public Guid Id { get; }

        /// <summary>
        /// <see cref="EntityId"/>
        /// </summary>
        public required EntityId<PointOfInterest> EntityId { get; init; }
    }

    /// <summary>
    /// POI переименована
    /// </summary>
    public record Renamed : IDomainEvent<PointOfInterest>
    {
        /// <summary>
        /// Конструктор <see cref="Renamed"/>
        /// </summary>
        public Renamed()
        {
            Id = Guid.NewGuid();
        }

        /// <inheritdoc cref="IDomainEvent{T}.Id"/>
        public Guid Id { get; }

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