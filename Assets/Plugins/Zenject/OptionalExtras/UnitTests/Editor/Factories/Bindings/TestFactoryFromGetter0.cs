using NUnit.Framework;
using Zenject.OptionalExtras.TestFramework;
using Zenject.Source.Factories;
using Assert = Zenject.Source.Internal.Assert;

namespace Zenject.OptionalExtras.UnitTests.Editor.Factories.Bindings
{
    [TestFixture]
    public class TestFactoryFromGetter0 : ZenjectUnitTestFixture
    {
        [Test]
        public void TestSelf()
        {
            Container.Bind<Foo>().AsSingle().NonLazy();
            Container.BindFactory<Bar, Bar.Factory>().FromResolveGetter<Foo>(x => x.Bar).NonLazy();

            Assert.IsNotNull(Container.Resolve<Bar.Factory>().Create());
            Assert.IsEqual(Container.Resolve<Bar.Factory>().Create(), Container.Resolve<Foo>().Bar);
        }

        class Bar
        {
            public class Factory : PlaceholderFactory<Bar>
            {
            }
        }

        class Foo
        {
            public Foo()
            {
                Bar = new Bar();
            }

            public Bar Bar
            {
                get;
                private set;
            }
        }
    }
}

