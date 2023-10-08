using Common.Domain.Types;

namespace SusanIn.POI.Domain.Models;

/// <summary>
/// Point of interest
/// </summary>
public class PointOfInterest : Entity<PointOfInterest>
{
    /// <summary>
    /// s3wer
    /// </summary>
    public PointOfInterest()
        : base()
    {
        var created = new Events.Created()
        {
            EntityId = Id,
        };
        State = PointOfInterestState.Create(new[] { created });
        Events.Add(created);
    }

    /// <summary>
    /// Текущее состояние <see cref="PointOfInterest"/>
    /// </summary>
    public PointOfInterestState State { get; }

    /// <summary>
    /// Создание <see cref="PointOfInterest"/>
    /// </summary>
    /// <returns><see cref="PointOfInterest"/></returns>
    public static PointOfInterest Create()
    {
        // todo добавить дополнительные проверки параметров создания сущности
        var pointOfInterest = new PointOfInterest();
        return pointOfInterest;
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
            Events.Add(renamed);
        }
    }

    /// <inheritdoc />
    protected override void Apply(DomainEvent<PointOfInterest> @event)
    {
        State.Apply(@event);
    }
}