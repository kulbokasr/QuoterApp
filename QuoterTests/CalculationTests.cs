using FluentAssertions;
using QuoterApp;
using Xunit;

namespace QuoterTests
{
    public class CalculationTests
    {
        [Fact]
        public void BestPriceAndVWAPTest()
        {
            IQuoter gq = new YourQuoter();
            var qty = 120;
            var instrumentId = "DK50782120";

            var quote = gq.GetQuote(instrumentId, qty);
            var vwap = gq.GetVolumeWeightedAveragePrice(instrumentId);

            quote.Should().Be(11977.2);
            vwap.Should().Be(99.94012869038608);
        }
    }
}

