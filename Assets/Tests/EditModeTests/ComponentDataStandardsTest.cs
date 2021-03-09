using System.Collections.Generic;
using NUnit.Framework;
using System.Reflection;
using System;
using System.Linq;
using FPS.Infrastructure;

public class ComponentDataStandardsTest
{
    [Test, TestCaseSource("getComponentDataClasses")]
    public void TestComponentDataStandards(Type classToTest)
    {
        MethodInfo[] methods = classToTest.GetMethods();

        Assert.That(
            methods.Select(method => method.Name),
            Does.Not.Contain("Update")
        );
    }

    private static IEnumerable<Type[]> getComponentDataClasses()
    {
        Assembly assembly = typeof(ComponentData).Assembly;
        foreach (Type dataClass in assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(ComponentData))))
        {
            yield return new[] { dataClass };
        }
    }
}
