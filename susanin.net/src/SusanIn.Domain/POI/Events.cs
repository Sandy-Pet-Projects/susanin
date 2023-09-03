using Common.Domain.Interfaces;
using Common.Domain.Types;

namespace SusanIn.Domain.POI;

/// <summary>
/// События POI
/// </summary>
public static class Events
{
    /// <summary>
    /// POI создана
    /// </summary>
    public record Created(Id<PointOfInterest> Id) : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// POI скопирована
    /// </summary>
    /// <param name="FromId">Идентификатор исходной POI</param>
    public record Copied(Id<PointOfInterest> FromId) : IDomainEvent<PointOfInterest>;

    /// <summary>
    /// POI отредактирована
    /// </summary>
    public class Edited : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// POI активирована
    /// </summary>
    public class Activated : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// POI деактивирована
    /// </summary>
    public class Deactivated : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// Отправлена на модерацию
    /// </summary>
    public class SentToModerator : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// Изменения приняты модератором
    /// </summary>
    public class ApprovedByModerator : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// Изменения отклонены модератором
    /// </summary>
    public class RejectedByModerator : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// Опубликованв
    /// </summary>
    public class Published : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// Скрыта из опубликованных
    /// </summary>
    public class Unpublished : IDomainEvent<PointOfInterest>
    {
    }

    /// <summary>
    /// Удалена
    /// </summary>
    public class Deleted : IDomainEvent<PointOfInterest>
    {
    }
}