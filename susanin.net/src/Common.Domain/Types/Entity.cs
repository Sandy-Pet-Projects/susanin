namespace Common.Domain.Types;

/// <summary>
/// Сущность
/// </summary>
/// <typeparam name="T">Тип сущности</typeparam>
public abstract class Entity<T>
    where T : Entity<T>
{
    /// <summary>
    /// Конструктор <see cref="Entity{T}"/>
    /// </summary>
    /// <param name="id"><see cref="EntityId{T}"/></param>
    protected Entity(EntityId<T>? id = default)
    {
        Id = id ?? new EntityId<T>();
    }

    /// <summary>
    /// <see cref="EntityId{T}"/>
    /// </summary>
    public EntityId<T> Id { get; }
}