using Common.Domain.Interfaces;
using System;

namespace Common.Domain.Types;

/// <summary>Идентификатор сущности</summary>
/// <typeparam name="T">Тип Сущности</typeparam>
public record Id<T>
    where T : IDomainEntity<T>
{
    private readonly Guid _guid;

    /// <summary>
    /// Конструктор <see cref="Id{T}"/>
    /// </summary>
    public Id()
    {
        _guid = Guid.NewGuid();
    }

    /// <summary>
    /// Конструктор <see cref="Id{T}"/>
    /// </summary>
    /// <param name="guid"><see cref="Guid"/></param>
    public Id(Guid guid)
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