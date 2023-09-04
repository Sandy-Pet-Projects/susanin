using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SusanIn.Architecture.Tests;

/// <summary>
/// Список модулей
/// </summary>
public class ModuleList : IEnumerable<object[]>
{
    private readonly IEnumerable<string[]> _modules = new[]
    {
        new[] { "Common" },
        new[] { "SusanIn.POI" },
    };

    /// <summary>
    /// Список модулей, за исключением указанного
    /// </summary>
    /// <param name="exceptionModule">Модуль-исключение</param>
    /// <returns>Списк модулей</returns>
    public IEnumerable<string> ExceptOf(string exceptionModule) => _modules.SelectMany(m => m).Except(new[] { exceptionModule }).ToArray();

    /// <inheritdoc />
    public IEnumerator<object[]> GetEnumerator() => _modules.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}