using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarInvoiceGeneration;

namespace InvoiceGeneratorTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            InvoiceGenerator invoice;
            RideRepository rideRepository;
            [TestInitialize]
             void setup()
            {
                rideRepository = new RideRepository();
                invoice = new InvoiceGenerator();
            }
            //method to find the total fare of single ride
            [TestMethod]
             void TotalFareForSingleRide()
            {
                double distance = 40;
                int time = 10;
                double actual = invoice.CalculateFare(distance, time);
                double expected = 410;
                Assert.AreEqual(expected, actual);
            }
            //find the total fare of single ride with distance as Zero
            [TestMethod]
             void TotalFareForSingleRideWithDistanceZeroTest()
            {
                try
                {
                    double distance = 0;
                    int time = 10;
                    var actual = invoice.CalculateFare(distance, time);
                }
                catch (InvoiceException IE)
                {
                    Assert.AreEqual("Distance Cannot be 0", IE.Message);
                }
            }
            //find the total fare of single ride with Time as Zero
            [TestMethod]
             void TotalFareForSingleRideWithTimeZeroTest()
            {
                try
                {
                    double distance = 40;
                    int time = 0;
                    var actual = invoice.CalculateFare(distance, time);
                }
                catch (InvoiceException IE)
                {
                    Assert.AreEqual("Time Cannot be 0", IE.Message);
                }
            }
            //find the total fare for multiple ride
            [TestMethod]
             void TotalFareForMultipleRides()
            {
                Rides[] rides = { new Rides(40, 10), new Rides(50, 25), new Rides(35, 5) };
                InvoiceSummary actual = invoice.CalcualateTotalFair(rides);
                double expected = 1290;
                Assert.AreEqual(expected, actual.totalFare);
            }

            //given the ride details return invoice summary
            [TestMethod]
            void InvoiceSummaryTest()
            {
                Rides[] rides = { new Rides(40, 10), new Rides(50, 25), new Rides(35, 5) };
                InvoiceSummary actual = invoice.CalcualateTotalFair(rides);
                InvoiceSummary expected = new InvoiceSummary(3, 1290);
                var res = actual.Equals(expected);
                Assert.IsNotNull(res);
            }

        }
    }
    
}
