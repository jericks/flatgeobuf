﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using NetTopologySuite.IO;
using NetTopologySuite.Features;
using FlatGeobuf.NTS;

namespace FlatGeobuf.Tests.NTS
{
    [TestClass]
    public class TestDataRoundtripTests
    {
        [TestMethod]
        public void StatesTest()
        {
            var geojson = File.ReadAllText("../../../../../../test/data/states.geojson");
            var reader = new GeoJsonReader();
            var fcExpected = reader.Read<FeatureCollection>(geojson);
            var bytes = FeatureCollectionConversions.ToFlatGeobuf(fcExpected, GeometryType.MultiPolygon);
            var fcActual = FeatureCollectionConversions.FromFlatGeobuf(bytes);
            Assert.AreEqual(fcExpected.Count, fcActual.Count);
        }

        [TestMethod]
        public void TigerRoadsTest()
        {
            var geojson = File.ReadAllText("../../../../../../test/data/tiger_roads.geojson");
            var reader = new GeoJsonReader();
            var fcExpected = reader.Read<FeatureCollection>(geojson);
            var bytes = FeatureCollectionConversions.ToFlatGeobuf(fcExpected);
            var fcActual = FeatureCollectionConversions.FromFlatGeobuf(bytes);
            Assert.AreEqual(fcExpected.Count, fcActual.Count);
        }
    }
}
