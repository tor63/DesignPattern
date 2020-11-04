﻿using DesignLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TK.DesignLibrary.UnitTest
{
    [TestClass]
    public class Oberserver2
    {
        [TestMethod]
        public void Oberserver2_Test01()
        {
            // Define a provider and two observers.
            LocationTracker provider = new LocationTracker();
            LocationReporter reporter1 = new LocationReporter("FixedGPS");
            reporter1.Subscribe(provider);
            LocationReporter reporter2 = new LocationReporter("MobileGPS");
            reporter2.Subscribe(provider);

            provider.TrackLocation(new Location(47.6456, -122.1312));
            reporter1.Unsubscribe();
            provider.TrackLocation(new Location(47.6677, -122.1199));
            provider.TrackLocation(null);
            provider.EndTransmission();
        }
    }
}
