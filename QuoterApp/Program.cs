using System;

namespace QuoterApp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                IQuoter gq = new YourQuoter();
                var qty = 40;
                var instrumentId = "AB73567490";
                var quote = gq.GetQuote(instrumentId, qty);
                var vwap = gq.GetVolumeWeightedAveragePrice(instrumentId);
                if (quote != 0)
                    Console.WriteLine($"Best total price is {quote}, average unit price is {quote / (double)qty}");
                Console.WriteLine($"Volume Weighted Average Price: {vwap}");
                Console.WriteLine();
                Console.WriteLine($"Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }
}
