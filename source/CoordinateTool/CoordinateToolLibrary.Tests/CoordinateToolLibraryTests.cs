﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoordinateToolLibrary.Models;
using CoordinateToolLibrary.ViewModels;

namespace CoordinateToolLibrary.Tests
{
    [TestClass]
    public class CoordinateToolLibraryTests
    {
        [TestMethod]
        public void ParseDD()
        {
            CoordinateDD coord;
            Assert.IsTrue(CoordinateDD.TryParse("40.273048 -78.847427", out coord));
            Assert.AreEqual(40.273048, coord.Lat);
            Assert.AreEqual(-78.847427, coord.Lon);

            Assert.IsFalse(CoordinateDD.TryParse("", out coord));

            Assert.IsTrue(CoordinateDD.TryParse("40.273048N 78.847427W", out coord));
            Assert.IsTrue(CoordinateDD.TryParse("40.273048N,78.847427W", out coord));
            Assert.IsTrue(CoordinateDD.TryParse("40.273048N78.847427W", out coord));
            Assert.IsTrue(CoordinateDD.TryParse("40.273048N;78.847427W", out coord));
            Assert.IsTrue(CoordinateDD.TryParse("40.273048N:78.847427W", out coord));

            Assert.IsFalse(CoordinateDD.TryParse("This is not a coordinate", out coord));
        }

        [TestMethod]
        public void ParseDDM()
        {
            CoordinateDDM coord;
            Assert.IsTrue(CoordinateDDM.TryParse("40°16.38288', -78°50.84562'", out coord));
            Assert.IsTrue(CoordinateDDM.TryParse("40°16.38288', -078°50.84562'", out coord));

            Assert.IsFalse(CoordinateDDM.TryParse("This is not a coordinate", out coord));
        }

        [TestMethod]
        public void ParseDMS()
        {
            CoordinateDMS coord;
            Assert.IsTrue(CoordinateDMS.TryParse("40°16'22.9728\", -78°50'50.7372\"", out coord));
            Assert.IsTrue(CoordinateDMS.TryParse("40°16'22.9728\", -078°50'50.7372\"", out coord));
            Assert.IsTrue(CoordinateDMS.TryParse("40° 16' 22.9728\", -78° 50' 50.7372\"", out coord));

            Assert.IsFalse(CoordinateDMS.TryParse("This is not a coordinate", out coord));
        }

        [TestMethod]
        public void ParseGARS()
        {
            CoordinateGARS coord;
            Assert.IsTrue(CoordinateGARS.TryParse("203LW18", out coord));
            Assert.IsTrue(CoordinateGARS.TryParse("203 LW 1 8", out coord));
            Assert.IsTrue(CoordinateGARS.TryParse("203,LW,1,8", out coord));
            Assert.IsTrue(CoordinateGARS.TryParse("203-LW-1-8", out coord));

            Assert.IsFalse(CoordinateGARS.TryParse("This is not a coordinate", out coord));
        }

        [TestMethod]
        public void ParseUTM()
        {
            CoordinateUTM coord;
            Assert.IsTrue(CoordinateUTM.TryParse("17N683016m4460286m", out coord));
            Assert.IsTrue(CoordinateUTM.TryParse("17N 683016m 4460286m", out coord));
            Assert.IsTrue(CoordinateUTM.TryParse("17N,683016m,4460286m", out coord));
            Assert.IsTrue(CoordinateUTM.TryParse("17N-683016m-4460286m", out coord));
            Assert.IsTrue(CoordinateUTM.TryParse("17N;683016m;4460286m", out coord));
            Assert.IsTrue(CoordinateUTM.TryParse("17N:683016m:4460286m", out coord));

            Assert.IsFalse(CoordinateUTM.TryParse("This is not a coordinate", out coord));
        }

        [TestMethod]
        public void ParseMGRS()
        {
            CoordinateMGRS coord;
            Assert.IsTrue(CoordinateMGRS.TryParse("17TPE8301660286", out coord));
            Assert.IsTrue(CoordinateMGRS.TryParse("17T PE 8301660286", out coord));
            Assert.IsTrue(CoordinateMGRS.TryParse("17T-PE-8301660286", out coord));
            Assert.IsTrue(CoordinateMGRS.TryParse("17T,PE,8301660286", out coord));
            Assert.IsTrue(CoordinateMGRS.TryParse("17T:PE:8301660286", out coord));
            Assert.IsTrue(CoordinateMGRS.TryParse("17T;PE;8301660286", out coord));

            Assert.IsFalse(CoordinateMGRS.TryParse("This is not a coordinate", out coord));
        }

        [TestMethod]
        public void ParseUSNG()
        {
            CoordinateUSNG coord;
            Assert.IsTrue(CoordinateUSNG.TryParse("17TPE8301660286", out coord));
            Assert.IsTrue(CoordinateUSNG.TryParse("17T PE 8301660286", out coord));
            Assert.IsTrue(CoordinateUSNG.TryParse("17T-PE-8301660286", out coord));
            Assert.IsTrue(CoordinateUSNG.TryParse("17T,PE,8301660286", out coord));
            Assert.IsTrue(CoordinateUSNG.TryParse("17T:PE:8301660286", out coord));
            Assert.IsTrue(CoordinateUSNG.TryParse("17T;PE;8301660286", out coord));

            Assert.IsFalse(CoordinateUSNG.TryParse("This is not a coordinate", out coord));
        }

        [TestMethod]
        public void FormatterDD()
        {
            var coord = new CoordinateDD(40.273048, -78.847427);
            var temp = coord.ToString("Y0.0#N X0.0#E", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "40.27N 78.85W");

            temp = coord.ToString("Y0.0#S X0.0#W", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "40.27N 78.85W");

            temp = coord.ToString("Y+-0.##N X+-0.##E", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "+40.27N -78.85W");

            temp = coord.ToString("Y+-0.0# X+-0.0#", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "+40.27 -78.85");

            temp = coord.ToString("Y0.0# N, X0.0# E", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "40.27 N, 78.85 W");

            temp = coord.ToString("Y0.0#° N, X0.0#° E", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "40.27° N, 78.85° W");

            temp = coord.ToString("N Y0.0#°, E X0.0#°", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "N 40.27°, W 78.85°");

            // test the default
            temp = coord.ToString("", new CoordinateDDFormatter());
            Assert.AreEqual(temp, "40.2730 -78.8474");
        }

        [TestMethod]
        public void FormatterMGRS()
        {
            var coord = new CoordinateMGRS("17T", "PE", 83016, 60286);
            var temp = coord.ToString("ZSE#N#", new CoordinateMGRSFormatter());
            Assert.AreEqual(temp, "17TPE8301660286");

            temp = coord.ToString("Z S E# N#", new CoordinateMGRSFormatter());
            Assert.AreEqual(temp, "17T PE 83016 60286");

            temp = coord.ToString("Z,S,E#,N#", new CoordinateMGRSFormatter());
            Assert.AreEqual(temp, "17T,PE,83016,60286");
            
            temp = coord.ToString("Z-S-E#-N#", new CoordinateMGRSFormatter());
            Assert.AreEqual(temp, "17T-PE-83016-60286");
            
            temp = coord.ToString("ZS E#N#", new CoordinateMGRSFormatter());
            Assert.AreEqual(temp, "17TPE 8301660286");
            
            temp = coord.ToString("ZS E# N#", new CoordinateMGRSFormatter());
            Assert.AreEqual(temp, "17TPE 83016 60286");

            // test the default
            temp = coord.ToString("", new CoordinateMGRSFormatter());
            Assert.AreEqual(temp, "17TPE8301660286");
        }

        [TestMethod]
        public void FormatterDDM()
        {
            var coord = new CoordinateDDM(40, 16.38288, -78, 50.84562);
            var temp = coord.ToString("", new CoordinateDDMFormatter());
            Assert.AreEqual(temp, "40°16.38288' -78°50.84562'");

            temp = coord.ToString("A0°B0.0#####'N X0°Y0.0#####'E", new CoordinateDDMFormatter());
            Assert.AreEqual(temp, "40°16.38288'N 78°50.84562'W");

            temp = coord.ToString("A+-0°B0.0#####' X+-0°Y0.0#####'", new CoordinateDDMFormatter());
            Assert.AreEqual(temp, "+40°16.38288' -78°50.84562'");

            temp = coord.ToString("NA0°B0.0#####' EX0°Y0.0#####'", new CoordinateDDMFormatter());
            Assert.AreEqual(temp, "N40°16.38288' W78°50.84562'");
            
            temp = coord.ToString("A0°B0.0#####'N, X0°Y0.0#####'E", new CoordinateDDMFormatter());
            Assert.AreEqual(temp, "40°16.38288'N, 78°50.84562'W");
            
            temp = coord.ToString("A0° B0.0#####'N X0° Y0.0#####'E", new CoordinateDDMFormatter());
            Assert.AreEqual(temp, "40° 16.38288'N 78° 50.84562'W");
        }

        [TestMethod]
        public void FormatterDMS()
        {
            var coord = new CoordinateDMS(40, 16, 22.9728, -78, 50, 50.7372);
            var temp = coord.ToString("", new CoordinateDMSFormatter());
            Assert.AreEqual(temp, "40°16'23.0\"N 78°50'50.7\"W");

            temp = coord.ToString("A#°B0'C0.0##\"N X#°Y0'Z0.0##\"E", new CoordinateDMSFormatter());
            Assert.AreEqual(temp, "40°16'22.973\"N 78°50'50.737\"W");

            temp = coord.ToString("NA#°B0'C0.0##\" EX#°Y0'Z0.0##\"", new CoordinateDMSFormatter());
            Assert.AreEqual(temp, "N40°16'22.973\" W78°50'50.737\"");
            
            temp = coord.ToString("A#° B0' C0.0##\" N X#° Y0' Z0.0##\" E", new CoordinateDMSFormatter());
            Assert.AreEqual(temp, "40° 16' 22.973\" N 78° 50' 50.737\" W");
            
            temp = coord.ToString("A+-#°B0'C0.0##\" X+-#°Y0'Z0.0##\"", new CoordinateDMSFormatter());
            Assert.AreEqual(temp, "+40°16'22.973\" -78°50'50.737\"");
            
            temp = coord.ToString("A# B0 C0.0## N X# Y0 Z0.0## E", new CoordinateDMSFormatter());
            Assert.AreEqual(temp, "40 16 22.973 N 78 50 50.737 W");
            
            temp = coord.ToString("A#°B0'C0.0##\"N, X#°Y0'Z0.0##\"E", new CoordinateDMSFormatter());
            Assert.AreEqual(temp, "40°16'22.973\"N, 78°50'50.737\"W");
        }

        [TestMethod]
        public void FormatterGARS()
        {
            var coord = new CoordinateGARS(203, "LW", 1, 8);
            var temp = coord.ToString("", new CoordinateGARSFormatter());
            Assert.AreEqual(temp, "203LW18");

            temp = coord.ToString("X# Y QK", new CoordinateGARSFormatter());
            Assert.AreEqual(temp, "203 LW 18");
            
            temp = coord.ToString("X# Y Q K", new CoordinateGARSFormatter());
            Assert.AreEqual(temp, "203 LW 1 8");
            
            temp = coord.ToString("X#-Y-QK", new CoordinateGARSFormatter());
            Assert.AreEqual(temp, "203-LW-18");
            
            temp = coord.ToString("X#-Y-Q-K", new CoordinateGARSFormatter());
            Assert.AreEqual(temp, "203-LW-1-8");

            temp = coord.ToString("X#,Y,Q,K", new CoordinateGARSFormatter());
            Assert.AreEqual(temp, "203,LW,1,8");
        }

        [TestMethod]
        public void FormatterUTM()
        {
            var coord = new CoordinateUTM(17, "N", 683016, 4460286);
            var temp = coord.ToString("", new CoordinateUTMFormatter());
            Assert.AreEqual(temp, "17N 683016m 4460286m");

            temp = coord.ToString("Z+-# X#m Y#m", new CoordinateUTMFormatter());
            Assert.AreEqual(temp, "+17 683016m 4460286m");

            temp = coord.ToString("Z#H X#m E Y#m N", new CoordinateUTMFormatter());
            Assert.AreEqual(temp, "17N 683016m E 4460286m N");
            
            temp = coord.ToString("Z#H X# E Y# N", new CoordinateUTMFormatter());
            Assert.AreEqual(temp, "17N 683016 E 4460286 N");
        }

        [TestMethod]
        public void CTViewModel()
        {
            var ctvm = new CoordinateToolViewModel();

            Assert.IsNotNull(ctvm.OCView);
        }
    }
}