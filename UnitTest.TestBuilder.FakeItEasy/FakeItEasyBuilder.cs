using UnitTest.TestBuilder.Core;
using UnitTest.TestBuilder.Core.Abstracts;

namespace UnitTest.TestBuilder.FakeItEasy
{
    public abstract class FakeItEasyBuilder<T> : BaseBuilder<T>
    {
        public FakeItEasyBuilder(IContainer container) : base(container, new ObjectBuilder())
        {

        }
    }
}
