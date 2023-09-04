using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace SusanIn.Architecture.Tests;

/// <summary>
/// Провайдер архитектуры
/// </summary>
public static class ArchitectureProvider
{
    /// <summary>
    /// Архитектура
    /// </summary>
    public static readonly ArchUnitNET.Domain.Architecture SusanInArchitecture = new ArchLoader().LoadAssemblies(
            System.Reflection.Assembly.Load("Common.Domain"),
            System.Reflection.Assembly.Load("SusanIn.POI.Domain"))
        .Build();

    /// <summary>
    /// Список модулей
    /// </summary>
    public static ModuleList Modules { get; } = new();

    /// <summary>
    /// Слои домена
    /// </summary>
    public static IObjectProvider<IType> DomainLayers =>
        Types()
            .That().ResideInNamespace("*.Domain", true);

    /// <summary>
    /// Слой домена указанного модуля
    /// </summary>
    /// <param name="module">Имя модуля</param>
    /// <returns><see cref="IObjectProvider{T}"/></returns>
    public static IObjectProvider<IType> DomainLayerOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Domain", true);
}