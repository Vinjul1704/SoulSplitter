﻿// This file is part of the SoulSplitter distribution (https://github.com/FrankvdStam/SoulSplitter).
// Copyright (c) 2022 Frank van der Stam.
// https://github.com/FrankvdStam/SoulSplitter/blob/main/LICENSE
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, version 3.
//
// This program is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program. If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using SoulMemory.Native;

namespace SoulMemory.Memory
{
    public static class Extensions
    {
        public static string ToHexString(this byte[] bytes)
        {
            return BitConverter.ToString(bytes).Replace("-", " ");
        }

        public static string ToHexFileString(this byte[] bytes)
        {
            var sb = new StringBuilder();
            var newline = 0;
            foreach (var b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
                newline++;

                if (newline >= 10)
                {
                    sb.AppendLine();
                    newline = 0;
                }
            }
            return sb.ToString();
        }

        public static string GetDisplayName(this Enum enumValue)
        {
            var displayName = enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<AnnotationAttribute>()?
                .Name;

            if (string.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }

        public static string GetDisplayDescription(this Enum enumValue)
        {
            var displayName = enumValue
                .GetType()
                .GetMember(enumValue.ToString())
                .FirstOrDefault()
                .GetCustomAttribute<AnnotationAttribute>()?
                .Description;

            if (string.IsNullOrEmpty(displayName))
            {
                displayName = enumValue.ToString();
            }
            return displayName;
        }
    }
}
