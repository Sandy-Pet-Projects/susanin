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
    /// <see cref="Id{T}"/>
    /// </summary>
    public Id<T> Id { get; }

    /// <summary>
    /// <see cref="IDomainEntityProjection{T}"/>
    /// </summary>
    public IDomainEntityProjection<T> State { get; }
}