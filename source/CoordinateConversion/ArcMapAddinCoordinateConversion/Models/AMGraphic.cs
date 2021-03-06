﻿// Copyright 2016 Esri 
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;

namespace ArcMapAddinCoordinateConversion.Models
{
    public class AMGraphic
    {
        public AMGraphic(string _uniqueid, IGeometry _geometry, bool _isTemp = false, Dictionary<string, Tuple<object, bool>> _dictionary = null)
        {
            UniqueId = _uniqueid;
            Geometry = _geometry;
            IsTemp = _isTemp;
            FieldsDictionary = _dictionary;
        }

        // properties   

        /// <summary>
        /// Property for the unique id of the graphic (guid)
        /// </summary>
        public string UniqueId { get; set; }

        /// <summary>
        /// Property for the geometry of the graphic
        /// </summary>
        public IGeometry Geometry { get; set; }

        /// <summary>
        /// Property to determine if graphic is temporary or not
        /// </summary>
        public bool IsTemp { get; set; }

        public Dictionary<string, Tuple<object, bool>> FieldsDictionary;

    }
}
