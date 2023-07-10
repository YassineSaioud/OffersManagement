namespace OffersManagement.Infrastructure.UnitTests
{
    public abstract class Given_When_Then_Test_Async
    {
        protected Given_When_Then_Test_Async()
        {
            Setup();
        }

        private void Setup()
        {
            Given();
            When();
        }

        protected abstract void Given();

        protected abstract Task When();

    }
}
