using Common.Domain.Types;
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
        var pointOfInterest = PointOfInterest.Create(id);

        // act
        pointOfInterest.RenameTo("new name");

        // assert
        pointOfInterest.Id
            .Should().Be(id);

        // todo перенести в тесты стейта
        pointOfInterest.State.Name
            .Should().Be("new name");
    }
}