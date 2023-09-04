using ArchUnitNET.xUnit;
using System.Linq;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace SusanIn.Architecture.Tests.Modules;

/// <summary>
/// Тесты модулей
/// </summary>
public class ModulesTests
{
    /// <summary>
    /// Домен не должен зависеть от других модулей кроме Common
    /// </summary>
    /// <param name="module">Модуль</param>
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Domain_ShouldNotHave_Dependency_ToOtherModules_Except_Common(string module)
    {
        var otherModules = ArchitectureProvider.Modules.ExceptOf(module).Except(new[] { "Common" });

        Types().That()
            .Are(ArchitectureProvider.DomainLayerOf(module))
            .Should()
            .NotDependOnAny(otherModules, true)
            .Check(ArchitectureProvider.SusanInArchitecture);
    }
}