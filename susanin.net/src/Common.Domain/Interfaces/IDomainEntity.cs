using Common.Domain.Types;

namespace Common.Domain.Interfaces;

/// <summary>
/// Сущность
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IDomainEntity<T>
    where T : IDomainEntity<T>
{
    /// <summary>
    /// <see cref="EntityId{T}"/>
    /// </summary>
    public EntityId<T> Id { get; }

    /// <summary>
    /// <see cref="IDomainEntityProjection{T}"/>
    /// </summary>
    public IDomainEntityProjection<T> State { get; }
}