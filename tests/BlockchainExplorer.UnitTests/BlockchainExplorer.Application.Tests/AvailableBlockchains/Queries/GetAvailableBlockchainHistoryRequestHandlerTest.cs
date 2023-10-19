using BlockchainExplorer.Application.Exceptions;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Handlers.Queries;
using BlockchainExplorer.Application.Features.AvailableBlockchains.Requests.Queries;
using BlockchainExplorer.UnitTests.Common;

namespace BlockchainExplorer.UnitTests.BlockchainExplorer.Application.Tests.AvailableBlockchains.Queries
{
    public class GetAvailableBlockchainHistoryRequestHandlerTest: UnitTestInitializer
    {

        private readonly GetAvailableBlockchainHistoryRequestHandler _handler;

        public GetAvailableBlockchainHistoryRequestHandlerTest()
        {
            _handler = new GetAvailableBlockchainHistoryRequestHandler(mockUnitOfWork.Object.BlockChain,
                mapper);
        }

        [Fact]
        public async Task GetAvailableBlockchainHistoryTest_Success()
        {
            string inputHashId = "00000000000000000002678b7dec5a3c7bea6d6c1c94b7d51dbb4b3585d03rty";
            var result = await _handler.Handle(new GetAvailableBlockchainHistoryRequest() {
                HashId = inputHashId
            },CancellationToken.None);

            Assert.NotNull(result);
            Assert.Equal((await mockUnitOfWork.Object.BlockChain.GetAllAsync((p=>p.HashId== inputHashId))).Count(), result.Data?.Count());
        }

        [Fact]
        public async Task GetAvailableBlockchainHistoryTest_HasId_NotExists_Error()
        {
            Assert.ThrowsAsync<NotFoundException>(
                async() => await _handler.Handle(new GetAvailableBlockchainHistoryRequest()
            {
                HashId = "0000000000000000000aaaabbbbb"
            }, CancellationToken.None)
            );
        }
    }
}
