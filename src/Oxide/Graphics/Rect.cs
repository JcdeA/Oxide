// Copyright (c) The Vignette Authors
// Licensed under BSD 3-Clause License. See LICENSE for details.

using System.Runtime.InteropServices;

namespace Oxide.Graphics
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public float Left;
        public float Top;
        public float Right;
        public float Bottom;
    }

    public static class RectExtensions
    {
        public static bool IsEmpty(this Rect rect)
            => Ultralight.ulRectIsEmpty(rect);
    }
}
