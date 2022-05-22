using System.Threading.Tasks;

namespace QuoterApp
{
    /// <summary>
    /// Interface to access market quotes
    /// </summary>
    public interface IQuoteSource
    {
        /// <summary>
        /// Blocking method that will return next available quote.
        /// </summary>
        /// <returns>Market quote containing InstrumentId</returns>
        public Quote GetNextQuote();
    }
}
