using Common.Domain.Interfaces;
using Common.Domain.Types;
using Common.Domain.ValueObjects;
using FluentAssertions;
using NSubstitute;
using SusanIn.POI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
        var id = new Id<PointOfInterest>();
        var name = "initial name";
        var coordinates = new Coordinates(0, 0);

        // act
        var pointOfInterest = PointOfInterest.Create(id, name, coordinates);

        // assert
        pointOfInterest.Id
            .Should().Be(id);
    }

    /// <summary>
    /// Тестирование состояния после создания <see cref="PointOfInterest"/>
    /// </summary>
    [Fact]
    public void PointOfInterestCreateStateTest()
    {
        // arrange
        var id = new Id<PointOfInterest>();
        var name = "initial name";
        var coordinates = new Coordinates(0, 0);
        var pointOfInterest = PointOfInterest.Create(id, name, coordinates);

        // act
        pointOfInterest.RenameTo("new name");

        // assert
        pointOfInterest.State.Id
            .Should().Be(id);
        pointOfInterest.State.Name
            .Should().Be("new name");
        pointOfInterest.State.Coordinate
            .Should().Be(coordinates);
    }

    /// <summary>
    /// Тестирование загрузки <see cref="PointOfInterest"/> с помощью <see cref="IDomainEventRepository{T}"/>
    /// </summary>
    /// <returns><see cref="Task{TResult}"/></returns>
    [Fact]
    public async Task PointOfInterestLoadTestAsync()
    {
        // arrange
        var id = new Id<PointOfInterest>();
        var repository = Substitute.For<IDomainEventRepository<PointOfInterest>>();
        repository
            .LoadAsync(Arg.Any<Id<PointOfInterest>>())
            .ReturnsForAnyArgs(info =>
            {
                var domainEvents = new List<DomainEvent<PointOfInterest>>()
                {
                    new PointOfInterestEvents.PointOfInterestCreated()
                    {
                        EntityId = info.Arg<Id<PointOfInterest>>(),
                        Name = "initial name",
                        Coordinate = new Coordinates(0, 0),
                    },
                    new PointOfInterestEvents.PointOfInterestRenamed()
                    {
                        EntityId = info.Arg<Id<PointOfInterest>>(),
                        OldName = "initial name",
                        NewName = "qwe",
                    },
                    JsonSerializer.Deserialize<PointOfInterestEvents.PointOfInterestRenamed>("""{"Id": "6ac195ef-30ea-4c0c-8179-592cdb61a75f", "EntityId": "0307bc5b-0729-4545-a40f-789862040b8c", "OldName": "initial name", "NewName": "qwe", "CreatedAt": "2023-10-11"}""")!,
                };
                return domainEvents;
            });

        // act
        var pointOfInterest = await PointOfInterest.LoadAsync(repository, id);

        // assert
        await repository.Received().LoadAsync(id);
        pointOfInterest.Id
            .Should().Be(id);
        pointOfInterest.State.Id
            .Should().Be(id);
        pointOfInterest.State.Name
            .Should().Be("qwe");
    }

    /// <summary>
    /// Тестирование сохранения <see cref="PointOfInterest"/> с помощью <see cref="IDomainEventRepository{T}"/>
    /// </summary>
    /// <returns><see cref="Task"/></returns>
    [Fact]
    public async Task PointOfInterestSaveTestAsync()
    {
        // arrange
        var id = new Id<PointOfInterest>();
        var name = "initial name";
        var coordinates = new Coordinates(0, 0);
        var pointOfInterest = PointOfInterest.Create(id, name, coordinates);
        var repository = Substitute.For<IDomainEventRepository<PointOfInterest>>();

        // act
        await pointOfInterest.SaveAsync(repository);

        // assert
        await repository.Received()
            .SaveAsync(
                id: Arg.Is<Id<PointOfInterest>>(i => i == id),
                version: Arg.Is<int>(i => i == 0),
                events: Arg.Is<IEnumerable<DomainEvent<PointOfInterest>>>(i => i.Any(@event => @event is PointOfInterestEvents.PointOfInterestCreated)));
    }

    /// <summary>
    /// Тестирование конфликта сохранения <see cref="PointOfInterest"/> с помощью &lt;see cref="IDomainEventRepository{T}"/&gt;
    /// </summary>
    /// <returns><see cref="Task"/></returns>
    [Fact]
    public async Task PointOfInterestSaveConflictTestAsync()
    {
        // arrange
        var id = new Id<PointOfInterest>();
        var repository = Substitute.For<IDomainEventRepository<PointOfInterest>>();
        repository
            .LoadAsync(Arg.Any<Id<PointOfInterest>>())
            .Returns(info =>
            {
                var domainEvents = new List<DomainEvent<PointOfInterest>>()
                {
                    new PointOfInterestEvents.PointOfInterestCreated()
                    {
                        EntityId = info.Arg<Id<PointOfInterest>>(),
                        Name = "initial name",
                        Coordinate = new Coordinates(0, 0),
                    }
                };
                return domainEvents;
            });
        var version = 1;
        repository
            .When(eventRepository => eventRepository.SaveAsync(Arg.Any<Id<PointOfInterest>>(), Arg.Any<int>(), Arg.Any<IEnumerable<DomainEvent<PointOfInterest>>>()))
            .Do(info =>
            {
                if (version == info.ArgAt<int>(1))
                {
                    version += info.ArgAt<IEnumerable<DomainEvent<PointOfInterest>>>(2).Count();
                }
                else
                {
                    throw new Exception();
                }
            });

        // act
        var pointOfInterest1 = await PointOfInterest.LoadAsync(repository, id);
        var pointOfInterest2 = await PointOfInterest.LoadAsync(repository, id);
        pointOfInterest1.RenameTo("name1");
        pointOfInterest2.RenameTo("name2");

        // assert
        await pointOfInterest1
            .Awaiting(poi => poi.SaveAsync(repository))
            .Should()
            .NotThrowAsync<Exception>();
        await pointOfInterest2
            .Awaiting(poi => poi.SaveAsync(repository))
            .Should()
            .ThrowAsync<Exception>();
    }
}