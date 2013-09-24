﻿/*
 
    Copyright (C) 2013, GTA-Network Team <contact at gta-network dot net>

    This software is provided 'as-is', without any express or implied
    warranty.  In no event will the authors be held liable for any damages
    arising from the use of this software.

    Permission is granted to anyone to use this software for any purpose,
    including commercial applications, and to alter it and redistribute it
    freely, subject to the following restrictions:

    1. The origin of this software must not be misrepresented; you must not
    claim that you wrote the original software. If you use this software
    in a product, an acknowledgment in the product documentation would be
    appreciated but is not required.
    2. Altered source versions must be plainly marked as such, and must not be
    misrepresented as being the original software.
    3. This notice may not be removed or altered from any source distribution.
 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Compression;
using GTANETWORKV.Utils;

namespace GTANETWORKV
{
    static class Platform
    {
        public enum PlatformType
        {
            NONE,
            XBOX360,
            PLAYSTATION3
        };

        public static Stream GetCompressStream(Stream stream)
        {
            if (GlobalOptions.Platform == PlatformType.PLAYSTATION3)
            {
                return new DeflateStream(stream, CompressionMode.Compress);
            }
            else
            {
                return new XMemCompressStream(stream);
            }
        }

        public static Stream GetDecompressStream(Stream stream)
        {
            if (GlobalOptions.Platform == PlatformType.PLAYSTATION3)
            {
                return new DeflateStream(stream, CompressionMode.Decompress);
            }
            else
            {
                return new XMemDecompressStream(stream);
            }
        }
    }
}