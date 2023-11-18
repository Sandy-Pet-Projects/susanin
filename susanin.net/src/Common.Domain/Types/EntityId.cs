using Common.Domain.Interfaces;
using System;

namespace Common.Domain.Types;

/// <summary>Идентификатор сущности</summary>
/// <typeparam name="T">Тип Сущности</typeparam>
public record EntityId<T>
    where T : IEntity<T>
{
    private readonly Guid _guid;

    /// <summary>
    /// Конструктор <see cref="EntityId{T}"/>
    /// </summary>
    public EntityId()
    {
        _guid = Guid.NewGuid();
    }

    /// <summary>
    /// Конструктор <see cref="EntityId{T}"/>
    /// </summary>
    /// <param name="guid"><see cref="Guid"/></param>
    public EntityId(Guid guid)
    {
        _guid = guid;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return _guid.ToString();
    }

    /// <summary>
    /// Преобразование в <see cref="Guid"/>
    /// </summary>
    /// <returns><see cref="Guid"/></returns>
    public Guid ToGuid()
    {
        return Guid.Parse(_guid.ToString());
    }
}