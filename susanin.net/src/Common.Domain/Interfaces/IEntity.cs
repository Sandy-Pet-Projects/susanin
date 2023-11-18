using Common.Domain.Types;

namespace Common.Domain.Interfaces;

/// <summary>
/// Сущность
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public interface IEntity<T>
    where T : IEntity<T>
{
    /// <summary>
    /// Идентификатор сущности
    /// </summary>
    public Id<T> Id { get; }
}