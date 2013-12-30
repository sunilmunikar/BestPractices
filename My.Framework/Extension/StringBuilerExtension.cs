using System;
using System.Diagnostics;
using System.Text;

namespace My.Framework.Extension
{
    public static class StringBuilerExtensions
    {
        /// <summary>
        /// Appends to this instance the string returned by processing a composite format string, which
        /// contains zero or more format items terminated by the default line terminator .
        /// </summary>
        /// <remarks>
        /// Each format item is replaced by the string representation of a corresponding argument in 
        /// a parameter array.
        /// </remarks>
        /// <param name="instance">The string builder instance.</param>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="args">An array of objects to format.</param>
        /// <returns>A reference to this instance after the append operation has completed. After
        /// the append operation, this instance contains any data that existed before
        /// the operation, suffixed by a copy of format where any format specification
        /// is replaced by the string representation of the corresponding object argument.
        ///</returns>
        [DebuggerStepThrough]
        public static StringBuilder AppendFormatLine(this StringBuilder instance, string format, params object[] args)
        {
            return instance.AppendFormat(format, args).AppendLine();
        }

        /// <summary>
        /// Appends to this instance the string returned by processing a composite format string, which
        /// contains zero or more format items, to this instance.
        /// </summary>
        /// <param name="instance">The string builder instance.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="format">A composite format string (see Remarks).</param>
        /// <param name="args">An array of objects to format.</param>
        /// <returns>
        ///  A reference to this instance after the append operation has completed. After
        ///  the append operation, this instance contains any data that existed before
        ///  the operation, suffixed by a copy of format where any format specification
        ///  is replaced by the string representation of the corresponding object argument.
        /// </returns>
        /// <remarks>
        /// Each format item is replaced by the string representation of a corresponding argument in
        /// a parameter array terminated by the default line terminator.
        /// </remarks>
        [DebuggerStepThrough]
        public static StringBuilder AppendFormatLine(this StringBuilder instance, IFormatProvider provider, string format, params object[] args)
        {
            return instance.AppendFormat(provider, format, args).AppendLine();
        }
    }
}
