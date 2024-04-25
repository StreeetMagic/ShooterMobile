using NUnit.Framework;
using Zenject.OptionalExtras.TestFramework;
using Assert = Zenject.Source.Internal.Assert;

namespace Zenject.OptionalExtras.UnitTests.Editor.BindFeatures
{
    [TestFixture]
    public class TestRebind : ZenjectUnitTestFixture
    {
        interface ITest
        {
        }

        class Test2 : ITest
        {
        }

        class Test3 : ITest
        {
        }

        [Test]
        public void Run()
        {
            Container.Bind<ITest>().To<Test2>().AsSingle();

            Assert.That(Container.Resolve<ITest>() is Test2);

            Container.Rebind<ITest>().To<Test3>().AsSingle();

            Assert.That(Container.Resolve<ITest>() is Test3);
        }
    }
}
