using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubtitleParser
{
    public partial class SubtitleParser
    {
        /// <summary>
        /// String format of time on subtitle. E.g "hh\:mm\:ss\,fff"
        /// </summary>
        public class SubtitleTimeFormat
        {
            /// <summary>
            /// Index of start time on string.
            /// </summary>
            public int StartTimeOffset = 0;

            /// <summary>
            /// Length of start time on string.
            /// </summary>
            public int StartTimeLenght = 12;

            /// <summary>
            /// Index of end time on string.
            /// </summary>
            public int EndTimeOffset = 17;

            /// <summary>
            /// Length of end time on string.
            /// </summary>
            public int EndTimeLenght = 12;

            /// <summary>
            /// String format of time.
            /// </summary>
            public string TimeStringFormat = @"hh\:mm\:ss\,fff";
        }

        // Default
        private static readonly SubtitleTimeFormat s_defaultSubtitleTimeFormat = new SubtitleTimeFormat();
    }
}
