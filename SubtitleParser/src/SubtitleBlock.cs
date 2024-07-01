using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleParser
{
    /// <summary>
    /// SubtitleBlock is class to hold order number, start and end time and text data.
    /// </summary>
    public partial class SubtitleParser
    {
        // Subtitle block class.
        /// <summary>
        /// Subtitle block is a class holds order number, starting and ending time of subtitle and lines of contents.
        /// </summary>
        public class SubtitleBlock
        {
            // Ordered number of subtitles
            /// <summary>
            /// Order number of subtitle blocks.
            /// </summary>
            public int OrderNumber;

            /// <summary>
            /// Starting time of subtitle block.
            /// </summary>
            // Starting time of subtitle.
            public TimeSpan StartTime;

            // Ending time of subtitle.
            /// <summary>
            /// Ending time of subititle.
            /// </summary>
            public TimeSpan EndTime;

            // Multiple-line text content of subtitle.
            /// <summary>
            /// Lines of text contents.
            /// </summary>
            public List<string> InlineTextList;

            /// <summary>
            /// Override method of ToString(). Returns as "OrderNumber StartTime EndTime and string of InlineTextList".
            /// </summary>
            /// <returns>String formatted SubtitleBlock.</returns>
            public override string ToString()
            {
                return $"{OrderNumber} {StartTime} {EndTime} {string.Join(" ", InlineTextList)}";
            }
        }
    }
}
