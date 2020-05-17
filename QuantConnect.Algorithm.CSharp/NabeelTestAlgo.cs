using QuantConnect.Brokerages;
using QuantConnect.Data.Market;

namespace QuantConnect.Algorithm
{
    public class NabeelTestAlgo : QCAlgorithm
    {
        public override void Initialize()
        {
            SetStartDate(2013, 10, 07);  //Set Start Date
            SetEndDate(2013, 10, 11);    //Set End Date
            SetCash(100000);             //Set Strategy Cash

            SetBrokerageModel(BrokerageName.Alpaca);

            AddSecurity(SecurityType.Equity, "SPY", Resolution.Second);
        }
        public void OnData(TradeBars data)
        {
            if (Portfolio.Invested) return;

            SetHoldings("SPY", 1);
            Debug("Purchased Stock");
        }
    }
}
