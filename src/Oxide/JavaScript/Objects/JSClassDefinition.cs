// Copyright (c) The Vignette Authors
// Licensed under BSD 3-Clause License. See LICENSE for details.

using System;
using System.Runtime.InteropServices;
using Oxide.JavaScript.Interop;

namespace Oxide.JavaScript.Objects
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct JSClassDefinition
    {
        internal int Version;
        internal JSClassAttributes Attributes;

        [MarshalAs(UnmanagedType.LPUTF8Str)]
        internal string Name;

        internal IntPtr BaseClass;
        internal IntPtr StaticValues;
        internal IntPtr StaticFunctions;
        internal JSObjectInitializeCallbackEx Initialize;
        internal JSObjectFinalizeCallbackEx Finalize;
        internal JSObjectHasPropertyCallback HasProperty;
        internal JSObjectGetPropertyCallbackEx GetProperty;
        internal JSObjectSetPropertyCallback SetProperty;
        internal JSObjectDeletePropertyCallback DeleteProperty;
        internal JSObjectGetPropertyNamesCallbackEx GetPropertyNames;
        internal JSObjectCallAsFunctionCallbackEx CallAsFunction;
        internal JSObjectCallAsConstructorCallbackEx CallAsConstructor;
        internal JSObjectHasInstanceCallback HasInstance;
        internal JSObjectConvertToTypeCallbackEx ConvertToType;
        internal IntPtr PrivateData;

        internal static JSClassDefinition Empty
        {
            get
            {
                var lib = NativeLibrary.Load(JSCore.LIB_WEBCORE);
                var ptr = NativeLibrary.GetExport(lib, "kJSClassDefinitionEmpty");
                return Marshal.PtrToStructure<JSClassDefinition>(ptr);
            }
        }
    }

    internal delegate void JSObjectInitializeCallbackEx(IntPtr ctx, IntPtr jsClass, IntPtr obj);
    internal delegate void JSObjectFinalizeCallbackEx(IntPtr jsClass, IntPtr obj);
    internal delegate void JSObjectGetPropertyNamesCallbackEx(IntPtr ctx, IntPtr jsClass, IntPtr obj, IntPtr propertyNames);
    internal delegate IntPtr JSObjectCallAsFunctionCallbackEx(IntPtr ctx, IntPtr jsClass, string className, IntPtr func, IntPtr thisObj, uint argumentCount, IntPtr arguments, out IntPtr exception);
    internal delegate IntPtr JSObjectCallAsConstructorCallbackEx(IntPtr ctx, IntPtr jsClass, IntPtr constructor, uint argumentCount, IntPtr arguments, out IntPtr exception);
    internal delegate IntPtr JSObjectConvertToTypeCallbackEx(IntPtr ctx, IntPtr jsClass, IntPtr obj, JSType type, out IntPtr exception);
    internal delegate IntPtr JSObjectGetPropertyCallbackEx(IntPtr ctx, IntPtr jsClass, IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JSStringRefMarshal))] string propertyName, out IntPtr exception);

    internal delegate IntPtr JSObjectCallAsConstructorCallback(IntPtr ctx, IntPtr constructor, uint argumentCount, IntPtr arguments, out IntPtr exception);
    internal delegate IntPtr JSObjectCallAsFunctionCallback(IntPtr ctx, string className, IntPtr func, IntPtr thisObj, uint argumentCount, IntPtr arguments, out IntPtr exception);

    [return: MarshalAs(UnmanagedType.I1)]
    internal delegate bool JSObjectHasPropertyCallback(IntPtr ctx, IntPtr jsClass, IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JSStringRefMarshal))] string propertyName);

    [return: MarshalAs(UnmanagedType.I1)]
    internal delegate bool JSObjectSetPropertyCallback(IntPtr ctx, IntPtr jsClass, IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JSStringRefMarshal))] string propertyName, IntPtr value, out IntPtr exception);

    [return: MarshalAs(UnmanagedType.I1)]
    internal delegate bool JSObjectDeletePropertyCallback(IntPtr ctx, IntPtr jsClass, IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(JSStringRefMarshal))] string propertyName, out IntPtr exception);

    [return: MarshalAs(UnmanagedType.I1)]
    internal delegate bool JSObjectHasInstanceCallback(IntPtr ctx, IntPtr jsClass, IntPtr constructor, IntPtr possibleInstance, out IntPtr exception);
}
