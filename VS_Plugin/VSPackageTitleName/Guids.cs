// Guids.cs
// MUST match guids.h
using System;

namespace Company.VSPackageTitleName
{
    static class GuidList
    {
        public const string guidVSPackageTitleNamePkgString = "9d23ae3b-8acf-436e-b5c2-1bad3324c55d";
        public const string guidVSPackageTitleNameCmdSetString = "fab4877b-01fa-4258-85c5-69c526b85fc2";
        public const string guidToolWindowPersistanceString = "c86626d7-e709-430a-b6b8-919ac1b1945f";
        public const string guidVSPackageTitleNameEditorFactoryString = "7dad1765-4351-4a0a-a358-5bd34b9355ac";

        public static readonly Guid guidVSPackageTitleNameCmdSet = new Guid(guidVSPackageTitleNameCmdSetString);
        public static readonly Guid guidVSPackageTitleNameEditorFactory = new Guid(guidVSPackageTitleNameEditorFactoryString);
    };
}