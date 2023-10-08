using Common.Domain.Types;
using System.Collections.Generic;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// Point of interest
/// </summary>
public class PointOfInterest : Entity<PointOfInterest>
{
    private readonly List<DomainEvent<PointOfInterest>> _events = new List<DomainEvent<PointOfInterest>>();

    private PointOfInterest(EntityId<PointOfInterest>? id = default)
        : base(id)
    {
        var created = new Events.Created()
        {
            EntityId = Id,
        };
        State = PointOfInterestState.Create(new[] { created });
        _events.Add(created);
    }

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
        // todo добавить дополнительные проверки параметров создания сущности
        return new PointOfInterest(id);
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