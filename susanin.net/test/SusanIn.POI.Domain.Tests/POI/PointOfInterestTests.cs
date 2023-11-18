using Common.Domain.Types;
using Common.Domain.ValueObjects;
using FluentAssertions;
using SusanIn.POI.Domain.Models;
using Xunit;

namespace SusanIn.POI.Domain.Tests.POI;

/// <summary>
/// Тесты <see cref="PointOfInterest"/>
/// </summary>
public class PointOfInterestTests
{
    /// <summary>
    /// Тестирование создания <see cref="PointOfInterest"/>
    /// </summary>
    [Fact]
    public void PointOfInterestCreateTest()
    {
        // arrange
        var id = new EntityId<PointOfInterest>();
        var name = "initial name";
        var coordinates = new Coordinates(0, 0);
        var pointOfInterest = PointOfInterest.Create(id, name, coordinates);

        // act
        pointOfInterest.RenameTo("new name");

        // assert
        // todo перенести в тесты стейта
        pointOfInterest.State.Name
            .Should().Be("new name");
    }
}