using NUnit.Framework;
using Zenject.OptionalExtras.TestFramework;
using Zenject.Source.Factories;
using Zenject.Source.Factories.Pooling;
using Assert = Zenject.Source.Internal.Assert;

namespace Zenject.OptionalExtras.UnitTests.Editor.Other
{
    [TestFixture]
    public class TestFactoryMemoryPoolCustomInterface : ZenjectUnitTestFixture
    {
        [Test]
        public void Test1()
        {
            var foo = new Foo();

            Container.BindFactoryCustomInterface<Foo, Foo.Factory, Foo.IFooFactory>().FromInstance(foo);

            Assert.IsEqual(Container.Resolve<Foo.IFooFactory>().Create(), foo);
        }

        [Test]
        public void Test2()
        {
            var foo = new Foo();

            Container.BindMemoryPoolCustomInterface<Foo, Foo.Pool, Foo.IFooPool>().FromInstance(foo);

            Assert.IsEqual(Container.Resolve<Foo.IFooPool>().Spawn(), foo);
        }

        public class Foo
        {
            public interface IFooFactory : IFactory<Foo>
            {
            }

            public interface IFooPool : IMemoryPool<Foo>
            {
            }

            public class Factory : PlaceholderFactory<Foo>, IFooFactory
            {
            }

            public class Pool : MemoryPool<Foo>, IFooPool
            {
            }
        }
    }
}
