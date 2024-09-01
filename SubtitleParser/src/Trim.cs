using System.Collections.Generic;

namespace SubtitleParser
{
    public partial class SubtitleParser
    {
        // Variable list hold line number of trimmed lines.
        private static readonly List<int> s_trimmedLineIndexList = new List<int>();

        /// <summary>
        /// List variable that holds order numbers that are trimmed by ParseSubtitleList() or ParseSubitleListUnsafe()
        /// </summary>
        public static readonly List<int> TrimmedLineIndexList = s_trimmedLineIndexList;
    }
}
