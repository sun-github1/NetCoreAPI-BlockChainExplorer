using BlockchainExplorer.Application.Exceptions;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Queries;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries;
using BlockchainExplorer.UnitTests.Common;

namespace BlockchainExplorer.UnitTests.BlockchainExplorer.Application.Tests.AvailableBlockchains.Queries
{
    public class GetAvailableBlockchainRequestHandlerTest : UnitTestInitializer
    {
        private readonly GetAvailableBlockchainRequestHandler _handler;

        public GetAvailableBlockchainRequestHandlerTest()
        {
            _handler = new GetAvailableBlockchainRequestHandler(mockUnitOfWork.Object.BlockChain,
                mapper);
        }

        [Fact]
        public async Task GetAvailableBlockchainRequestHandlerTest_Success()
        {
            int inputId = 1004;
            var result = await _handler.Handle(new GetAvailableBlockchainRequest()
            {
                Id= inputId
            }, CancellationToken.None);

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAvailableBlockchainRequestHandlerTest_DoesNotExists()
        {
            int inputId = 5555;
            Assert.ThrowsAsync<NotFoundException>(
              async () => await _handler.Handle(new GetAvailableBlockchainRequest()
              {
                  Id = inputId
              }, CancellationToken.None)
          );
        }
    }
}
