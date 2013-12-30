using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace My.Framework.Extension
{
    /// <summary>
    /// Contains the extension methods of the .NET <see cref="string"/> type
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Gets a new string where the first character is upper cased
        /// </summary>
        /// <param name="instance">A string to format.</param>
        /// <returns>A copy of string in which the first character has been replaced by its 
        /// upper cased equivalent, or an empty string if the parameter is a null or empty string</returns>
        [DebuggerStepThrough]
        public static string UppercaseFirst(this string instance)
        {
            // For performance see : http://dotnetperls.com/uppercase-first-letter
            if (string.IsNullOrEmpty(instance))
            {
                return string.Empty;
            }
            char[] a = instance.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

        /// <summary>
        /// Replaces the format item in a specified <see cref="System.String"/> with the text 
        /// equivalent of the value of a corresponding <see cref="System.Object"/> instance in a 
        /// specified array.
        /// </summary>
        /// <param name="instance">A string to format.</param>
        /// <param name="args">An System.Object array containing zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the <see cref="System.String"/>
        /// equivalent of the corresponding instances of System.Object in args.</returns>
        [DebuggerStepThrough]
        public static string FormatWith(this string instance, params object[] args)
        {
            if (string.IsNullOrEmpty(instance))
            {
                return string.Empty;
            }
            if (args == null)
            {
                return instance;
            }
            return string.Format(CultureInfo.CurrentCulture, instance, args);
        }

        /// <summary>
        /// Determines whether this instance and another specified <see cref="System.String"/> object 
        /// have the same value. The comparaison evaluates the numeric values of the corresponding 
        /// <see cref="System.Char"/> objects in each string
        /// </summary>
        /// <param name="instance">The string to check equality.</param>
        /// <param name="comparing">The comparing with string.</param>
        /// <returns>
        /// <c>true</c> if according to the comparaison rules, the value of the <c>comparing</c> 
        /// parameter is the same as this string; 
        /// otherwise, <c>false</c>.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsCaseSensitiveEqual(this string instance, string comparing)
        {
            return string.CompareOrdinal(instance, comparing) == 0;
        }

        /// <summary>
        /// Determines whether this instance and another specified <see cref="System.String"/> object 
        /// have the same value. The comparaison uses ordinal sort rules and ignoring the case of the strings
        /// being compared.
        /// </summary>
        /// <param name="instance">The string to check equality.</param>
        /// <param name="comparing">The comparing with string.</param>
        /// <returns>
        /// <c>true</c> if according to the comparaison rules, the value of the <c>comparing</c> 
        /// parameter is the same as this string; 
        /// otherwise, <c>false</c>.
        /// </returns>
        [DebuggerStepThrough]
        public static bool IsCaseInsensitiveEqual(this string instance, string comparing)
        {
            return string.Compare(instance, comparing, StringComparison.OrdinalIgnoreCase) == 0;
        }

        /// <summary>
        /// Compresses the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>
        /// The compressed instance
        /// </returns>
        [DebuggerStepThrough]
        public static string Compress(this string instance, Encoding encoding)
        {
            if (string.IsNullOrEmpty(instance))
            {
                return string.Empty;
            }

            byte[] buffer = encoding.GetBytes(instance);
            var memoryStream = new MemoryStream();
            using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Compress, true))
            {
                gZipStream.Write(buffer, 0, buffer.Length);
            }

            memoryStream.Position = 0;

            var compressedData = new byte[memoryStream.Length];
            memoryStream.Read(compressedData, 0, compressedData.Length);

            var gZipBuffer = new byte[compressedData.Length + 4];
            Buffer.BlockCopy(compressedData, 0, gZipBuffer, 4, compressedData.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(buffer.Length), 0, gZipBuffer, 0, 4);
            return Convert.ToBase64String(gZipBuffer);
        }

        /// <summary>
        /// Decompresses the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>
        /// The decompressed instance
        /// </returns>
        [DebuggerStepThrough]
        public static string Decompress(this string instance, Encoding encoding)
        {
            if (string.IsNullOrEmpty(instance))
            {
                return string.Empty;
            }

            byte[] gZipBuffer = Convert.FromBase64String(instance);
            using (var memoryStream = new MemoryStream())
            {
                int dataLength = BitConverter.ToInt32(gZipBuffer, 0);
                memoryStream.Write(gZipBuffer, 4, gZipBuffer.Length - 4);

                var buffer = new byte[dataLength];

                memoryStream.Position = 0;
                var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress);
                gZipStream.Read(buffer, 0, buffer.Length);

                return encoding.GetString(buffer);
            }
        }

        /// <summary>
        /// Convert the instnace to its corresponding enum value.
        /// </summary>
        /// <remarks>
        /// The conversion is case insensitive.
        /// </remarks>
        /// <typeparam name="T">the enum type</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns>The enum value or the <paramref name="defaultValue"/> if the conversion fails.</returns>
        /// <exception cref="ArgumentException"/> is thrown if the Type id not an enumerated type</exception>
        [DebuggerStepThrough]
        public static T ToEnum<T>(this string instance, T defaultValue) where T : IComparable, IFormattable
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            T returnedValue = defaultValue;

            if (!string.IsNullOrEmpty(instance))
            {
                var trimmedEnumValue = instance.Trim();
                foreach (T item in Enum.GetValues(typeof(T)))
                {
                    if (item.ToString().ToLower().Equals(trimmedEnumValue, StringComparison.OrdinalIgnoreCase))
                    {
                        returnedValue = item;
                        break;
                    }
                }
            }
            return returnedValue;
        }
    }
}
