namespace OffersManagement.Application.UnitTests
{
    public abstract class Given_When_Then_Test
    {
        protected Given_When_Then_Test()
        {
            Setup();
        }

        private void Setup()
        {
            Given();
            When();
        }

        protected abstract void Given();

        protected abstract void When();

    }
}
