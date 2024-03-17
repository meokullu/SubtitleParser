using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleParser
{
    public partial class SubtitleParser
    {
        /// <summary>
        /// Returns lines of contents of specified file via its path.
        /// </summary>
        /// <param name="filePath">File path that content will be read.</param>
        /// <returns>Lines of contents (string[])</returns>
        public static string[] GetTextByLines(string filePath)
        {
            // String array variable that will be filled with content.
            string[] movieSubtitleTextByLines;

            try
            {
                // Getting lines of file.
                movieSubtitleTextByLines = File.ReadAllLines(path: filePath);
            }
            catch (Exception ex)
            {
                // Returning exception.
                throw ex;
            }

            // Returning lines
            return movieSubtitleTextByLines;
        }

        /// <summary>
        /// [Unsafe] Returns lines of contents of specified file via its path.
        /// </summary>
        /// <param name="filePath">File path that content will be read.</param>
        /// <returns>Lines of contents (string[])</returns>
        public static string[] GetTextByLinesUnsafe(string filePath)
        {
            // Getting lines of file.
            string[] movieSubtitleTextByLines = File.ReadAllLines(path: filePath);

            // Returning lines
            return movieSubtitleTextByLines;
        }
    }
}
