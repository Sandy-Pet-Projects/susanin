using System;

namespace Common.Domain.Types;

/// <summary>
/// Географические координаты
/// </summary>
public record GeoCoordinate
{
    /// <summary>
    /// Конструктор <see cref="GeoCoordinate"/>
    /// </summary>
    /// <param name="latitude"><see cref="Latitude"/></param>
    /// <param name="longitude"><see cref="Longitude"/></param>
    /// <exception cref="ArgumentException">Исключение при некорректных входных параметрах</exception>
    public GeoCoordinate(double latitude, double longitude)
    {
        if (latitude is < -90 or > 90)
        {
            throw new ArgumentException("Invalid latitude value");
        }

        if (longitude is < -180 or > 180)
        {
            throw new ArgumentException("Invalid longitude value");
        }

        Latitude = latitude;
        Longitude = longitude;
    }

    /// <summary>
    /// Широта
    /// </summary>
    public double Latitude { get; }

    /// <summary>
    /// Долгота
    /// </summary>
    public double Longitude { get; }
}