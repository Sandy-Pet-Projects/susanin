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
        var pointOfInterest = PointOfInterest.Create();

        // act
        pointOfInterest.RenameTo("new name");

        // assert
        // todo перенести в тесты стейта
        pointOfInterest.State.Name
            .Should().Be("new name");
    }
}