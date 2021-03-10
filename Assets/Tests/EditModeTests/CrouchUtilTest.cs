using UnityEngine;
using NUnit.Framework;
using FPS.Player.MovementSystems;

public class CrouchUtilTest
{
    [Test]
    public void TestShrink()
    {
        Vector3 input = new Vector3(1, 2, 3);
        Vector3 output = CrouchUtil.shrink(input);

        Assert.AreEqual(output.y, 1);
        Assert.AreEqual(output.x, input.x);
        Assert.AreEqual(output.z, input.z);
    }

    [Test]
    public void TestUnshrink()
    {
        Vector3 input = new Vector3(1, 2, 3);
        Vector3 output = CrouchUtil.unshrink(input);

        Assert.AreEqual(output.y, 4);
        Assert.AreEqual(output.x, input.x);
        Assert.AreEqual(output.z, input.z);
    }

    [Test]
    public void TestStructsAreValueCopiesBecauseNickDoesntWorkWithCSharpEveryDay()
    {
        Vector3 input = new Vector3(1, 2, 3);
        Vector3 output = CrouchUtil.unshrink(input);

        Assert.AreNotEqual(output.y, input.y);
    }
}
