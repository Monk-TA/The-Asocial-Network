namespace TheAsocialNetwork.Common.Extensions
{
    using System;

    public static class StringExtensions
    {
        public static string ReplaceFileNameWithGuid(this string str)
        {
            var extension =  str.Substring(str.LastIndexOf('.'));

            var result = Guid.NewGuid().ToString() + extension;

            return result;
        }
    }
}
