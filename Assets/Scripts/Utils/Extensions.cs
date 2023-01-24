#nullable enable
using System;


namespace Utils
{
    public static class Extensions
    {
        public static T EnsureNotNull<T>(this T? value)
        {
            if (value == null)
            {
                throw new NullReferenceException();
            }

            return value;
        }
    }
}