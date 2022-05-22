Market Quoter Component

Your task is to implement market quoter component defined in IQuoter interface.

You have two methods to implement:
1. GetQuote
  - Takes instrument and quantity to quote, returns best possible price with current quotes
2. GetVolumeWeightedAveragePrice
  - Takes instrument id and calculates volume-weighted average price for the instrument
  - More about: https://en.wikipedia.org/wiki/Volume-weighted_average_price

You should depend on IQuoteSource interface as stand-in for market data feed. Keep in mind that IQuoteSource.GetNextQuote() blocks your call until next quote is available, source is potentially endless.
You can use provided implementation of IQuoteSource as example or you can write your own.

Each individual market quote is represented in Quote class and has Instrument ID, Price and Quantity for that price. There can be many quotes for the same instrumnet with different quantities and different prices.

