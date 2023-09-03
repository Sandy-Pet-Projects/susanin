using FluentAssertions;
using SusanIn.Domain.POI;
using Xunit;

namespace SusanIn.Domain.Tests.POI;

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
        pointOfInterest.Events
            .Should().ContainSingle(@event => @event.GetType() == typeof(Events.Created));

        // todo перенести в тесты стейта
        pointOfInterest.Id
            .Should().Be(pointOfInterest.State.Id);
    }
}