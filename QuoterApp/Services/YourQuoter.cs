using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoterApp
{
    public class YourQuoter : IQuoter
    {
        private List<Quote> thisInstrumentQuotes = new List<Quote> { };

        public void GetInstrumentQuotes(string instrumentId)
        {
            IQuoteSource qs = new HardcodedQuoteSource();
      
            while (true)
            {
                Quote tempQoute = qs.GetNextQuote();
                if (tempQoute == null)
                {
                    break;
                }
                if (tempQoute.InstrumentId == instrumentId)
                {
                    thisInstrumentQuotes.Add(tempQoute);
                }
            }

            if (thisInstrumentQuotes.Count() == 0) 
                throw new ArgumentException("This instrument ID does not exist or there is no such instrument to buy");

            thisInstrumentQuotes.Sort((x, y) => x.Price.CompareTo(y.Price));
        }
  
        public double GetQuote(string instrumentId, int quantity)
        {
            GetInstrumentQuotes(instrumentId);

            int totalPossibleQuantity = thisInstrumentQuotes.Sum(x => x.Quantity);
            if (totalPossibleQuantity < quantity)
            {
                Console.WriteLine($"Not enough quantity in the market. The maximum amount is {totalPossibleQuantity}");
                return 0;
            }

            double priceSum = 0;

            foreach (var quote in thisInstrumentQuotes)
            {
                if (quantity <= quote.Quantity)
                {
                    priceSum += quote.Price * quantity;
                    break;
                }
                else
                {
                    priceSum += quote.Price * quote.Quantity;
                    quantity -= quote.Quantity;
                }
            }
            return priceSum;
        }

        public double GetVolumeWeightedAveragePrice(string instrumentId)
        {
            double sumPrice = 0.0;
            double sumQuantity = 0.0;

            thisInstrumentQuotes.ForEach(quote =>
            {
                sumPrice += quote.Quantity * quote.Price;
                sumQuantity += quote.Quantity;
            });

            double vwap = sumPrice / sumQuantity;
            return vwap;
        }
    }
}
