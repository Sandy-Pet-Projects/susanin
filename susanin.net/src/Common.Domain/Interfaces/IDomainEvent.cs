namespace Common.Domain.Interfaces;

/// <summary>
/// Доменное событие
/// </summary>
/// <typeparam name="T"><see cref="IDomainEntity{T}"/></typeparam>
public interface IDomainEvent<T>
    where T : IDomainEntity<T>
{
}