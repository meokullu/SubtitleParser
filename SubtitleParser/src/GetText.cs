using System;
using System.IO;
using System.Text;

namespace SubtitleParser
{
    public partial class SubtitleParser
    {
        private static readonly Encoding s_defaultEncoding = Encoding.UTF8;

        /// <summary>
        /// Returns lines of contents of specified file via its path.
        /// </summary>
        /// <param name="filePath">File path that content will be read.</param>
        /// <returns>Lines of contents (string[])</returns>
        public static string[] GetTextByLines(string filePath)
        {
            //
            try
            {
                // Returning string array variable that will be filled with content.
                return File.ReadAllLines(path: filePath);
            }
            catch (Exception ex)
            {
                // Returning exception.
                throw ex;
            }
        }

        /// <summary>
        /// Returns lines of contents of specified file via its path.
        /// </summary>
        /// <param name="filePath">File path that content will be read.</param>
        /// <param name="encoding">Encoding to read text.</param>
        /// <returns>Lines of contents (string[])</returns>
        public static string[] GetTextByLines(string filePath, Encoding encoding)
        {
            // Checking if encoding is provided, if not it sets default encoding.
            if (encoding == null)
            {
                encoding = s_defaultEncoding;
            }

            //
            try
            {
                // Returning string array variable that will be filled with content.
                return File.ReadAllLines(path: filePath, encoding: encoding);
            }
            catch (Exception ex)
            {
                // Returning exception.
                throw ex;
            }
        }

        /// <summary>
        /// [Unsafe] Returns lines of contents of specified file via its path.
        /// </summary>
        /// <param name="filePath">File path that content will be read.</param>
        /// <returns>Lines of contents (string[])</returns>
        public static string[] GetTextByLinesUnsafe(string filePath)
        {
            // Returning string array variable that will be filled with content.
            return File.ReadAllLines(path: filePath);
        }

        /// <summary>
        /// [Unsafe] Returns lines of contents of specified file via its path.
        /// </summary>
        /// <param name="filePath">File path that content will be read.</param>
        /// <param name="encoding">Encoding to read text.</param>
        /// <returns>Lines of contents (string[])</returns>
        public static string[] GetTextByLinesUnsafe(string filePath, Encoding encoding)
        {
            // Checking if encoding is provided, if not it sets default encoding.
            if (encoding == null)
            {
                encoding = s_defaultEncoding;
            }

            // Returning string array variable that will be filled with content.
            return File.ReadAllLines(path: filePath, encoding: encoding);
        }
    }
}