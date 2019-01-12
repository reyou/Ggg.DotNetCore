// https://docs.microsoft.com/en-us/dotnet/core/tutorials/library-with-visual-studio

using System;

namespace GggNetStandard.Basics
{
    public static class StringLibrary
    {
        public static bool StartsWithUpper(this String str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return false;
            }
            Char ch = str[0];
            return Char.IsUpper(ch);
        }
    }
}
