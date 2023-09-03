using Common.Domain.Interfaces;
using Common.Domain.Types;
using System.Collections.Generic;

namespace SusanIn.Domain.POI;

/// <summary>
/// Point of interest
/// </summary>
public class PointOfInterest : IDomainEntity<PointOfInterest>
{
    private readonly List<IDomainEvent<PointOfInterest>> _events = new List<IDomainEvent<PointOfInterest>>();

    private PointOfInterest(EntityId<PointOfInterest> id)
    {
        Id = id;
        var created = new Events.Created()
        {
            EntityId = id,
        };
        State = new PointOfInterestState(new[] { created });
        _events.Add(created);
    }

    /// <inheritdoc cref="IDomainEntity{T}.Id"/>
    public EntityId<PointOfInterest> Id { get; }

    /// <inheritdoc cref="IDomainEntity{T}.Events"/>
    public IReadOnlyCollection<IDomainEvent<PointOfInterest>> Events => _events.AsReadOnly();

    /// <summary>
    /// Текущее состояние <see cref="PointOfInterest"/>
    /// </summary>
    public PointOfInterestState State { get; }

    /// <summary>
    /// Создание <see cref="PointOfInterest"/>
    /// </summary>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    /// <returns><see cref="PointOfInterest"/></returns>
    public static PointOfInterest Create(EntityId<PointOfInterest>? id = default)
    {
        return new PointOfInterest(id ?? new EntityId<PointOfInterest>());
    }

    /// <summary>
    /// Переимновать <see cref="PointOfInterest"/>
    /// </summary>
    /// <param name="newName">Новое имя <see cref="PointOfInterest"/></param>
    // todo вместо string использовать пользовательский тип
    public void RenameTo(string newName)
    {
        if (newName != State.Name)
        {
            var renamed = new Events.Renamed()
            {
                OldName = State.Name,
                NewName = newName,
            };
            State.Apply(renamed);
            _events.Add(renamed);
        }
    }
}