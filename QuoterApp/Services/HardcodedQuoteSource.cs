using System.Threading;

namespace QuoterApp
{
    public class HardcodedQuoteSource : IQuoteSource
    {
        private readonly Quote[] _quotes = new Quote[] {
            new Quote {InstrumentId = "BA79603015", Price = 102.997, Quantity = 12 },
            new Quote {InstrumentId = "BA79603015", Price = 103.2, Quantity = 60 },
            new Quote {InstrumentId = "AB73567490", Price = 103.25, Quantity = 79 },
            new Quote {InstrumentId = "AB73567490", Price = 95.5, Quantity = 14 },
            new Quote {InstrumentId = "BA79603015", Price = 98.0, Quantity = 1 },
            new Quote {InstrumentId = "AB73567490", Price = 100.7, Quantity = 17 },
            new Quote {InstrumentId = "DK50782120", Price = 100.001, Quantity = 900 },
            new Quote {InstrumentId = "DK50782120", Price = 99.81, Quantity = 421 },
        };

        private int position = 0;
        public Quote GetNextQuote()
        {
            if (_quotes.Length <= position)
            {
                // No more quotes to give
                //Thread.Sleep(Timeout.Infinite); 
                //Changed 'Thread.Sleep(Timeout.Infinite)' to 'return null' as it was allowed to edit this code part. 
                return null;
            }

            Thread.Sleep(500); // Simulates delay in getting next quote
            return _quotes[position++];
        }
    }
}
