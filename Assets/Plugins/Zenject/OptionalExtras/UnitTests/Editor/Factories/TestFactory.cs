using NUnit.Framework;
using Zenject.OptionalExtras.TestFramework;
using Zenject.Source.Factories;
using Assert = Zenject.Source.Internal.Assert;

namespace Zenject.OptionalExtras.UnitTests.Editor.Factories
{
    [TestFixture]
    public class TestFactory : ZenjectUnitTestFixture
    {
        [Test]
        public void TestToSelf()
        {
            Container.BindFactory<Foo, Foo.Factory>().NonLazy();

            Assert.IsNotNull(Container.Resolve<Foo.Factory>().Create());
        }

        public interface IFoo
        {
        }

        public class Foo : IFoo
        {
            public class Factory : PlaceholderFactory<Foo>
            {
            }
        }
    }
}


