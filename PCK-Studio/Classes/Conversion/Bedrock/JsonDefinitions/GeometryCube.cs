﻿/* Copyright (c) 2023-present miku-666
 * This software is provided 'as-is', without any express or implied
 * warranty. In no event will the authors be held liable for any damages
 * arising from the use of this software.
 * 
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 * 
 * 1.The origin of this software must not be misrepresented; you must not
 *    claim that you wrote the original software. If you use this software
 *    in a product, an acknowledgment in the product documentation would be
 *    appreciated but is not required.
 * 2. Altered source versions must be plainly marked as such, and must not be
 *    misrepresented as being the original software.
 * 3. This notice may not be removed or altered from any source distribution.
**/
using System.Numerics;
using Newtonsoft.Json;

namespace PckStudio.Conversion.Bedrock.JsonDefinitions
{
    internal class GeometryCube
    {
        public GeometryCube(Vector3 origin, Vector3 size, Vector2 uv, bool mirror = false, float inflate = 0.0f)
        {
            origin.CopyTo(Origin);
            size.CopyTo(Size);
            uv.CopyTo(UV);
            Mirror = mirror;
            Inflate = inflate;
        }

        [JsonProperty("origin")]
        public float[] Origin = { 0, 0, 0 };

        [JsonProperty("size")]
        public float[] Size = { 0, 0, 0 };

        // for whatever reason, uv is a float on LCE,
        // so I've kept it a float for the sake of consistency
        [JsonProperty("uv")]
        public float[] UV = { 0, 0 };

        [JsonProperty("mirror")]
        public bool Mirror = false;

        [JsonProperty("inflate")]
        public float Inflate = 0.0f;
    }
}
