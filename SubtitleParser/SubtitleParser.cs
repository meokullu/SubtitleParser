namespace SubtitleParser
{
    /// <summary>
    /// SubtitleParser, parses subtitle file content.
    /// </summary>
    public class SubtitleParser
    {
        // Variable list hold line number of trimmed lines.
        private static readonly List<int> s_trimmedLineIndexList = new List<int>();

        //TODO: Some orderNumber are not integers. E.g 1.1 34.2
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
            public int orderNumber;

            /// <summary>
            /// Starting time of subtitle block.
            /// </summary>
            // Starting time of subtitle.
            public TimeSpan startTime;

            // Ending time of subtitle.
            /// <summary>
            /// Ending time of subititle.
            /// </summary>
            public TimeSpan endTime;

            // Multiple-line text content of subtitle.
            /// <summary>
            /// Lines of text contents.
            /// </summary>
            public List<string>? inlineTextList;
        }

        /// <summary>
        /// [Unsafe] Returns lines of contents of specified file via its path.
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

        /// <summary>
        /// [Unsafe] Returns parsed contents. This method trims text contents of given subtitle lines.
        /// </summary>
        /// <param name="subtitleLines">Lines of contents to be parsed</param>
        /// <returns>List of SubtitleBlock (List[SubtitleBlock])</returns>
        public static List<SubtitleBlock> ParseSubtitleList(string[] subtitleLines)
        {
            try
            {
                // List of subtitle blocks to be filled.
                List<SubtitleBlock> subtitleBlockList = new List<SubtitleBlock>();

                // Integer variable for loop. The reason it is
                int i;

                // Loop for subtitle lines
                for (i = 0; i < subtitleLines.Count(); i++)
                {
                    // Creating instance of SubtitleBlock
                    SubtitleBlock sb = new SubtitleBlock
                    {
                        // Order number is an integer holds sequence of subtitle blocks. It splits line if it containts a dot and take first part. If it doesn't containts a dot it converts string to Int32.
                        orderNumber = Convert.ToInt32(subtitleLines[i].Split('.')[0]),

                        // 00:00:00,000 --> 00:00:01,000

                        // TODO: CultureInvariant? (dot or comma)

                        // Take first 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().  
                        startTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(0, 12), @"hh\:mm\:ss\,fff", null),

                        // Take last 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().
                        endTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(17, 12), @"hh\:mm\:ss\,fff", null),

                        // Calls GetInlineText() to fill inlineTextList. GetInlineText() returns lines of contents on specified SubtitleBlock
                        inlineTextList = GetInlineText(),
                    };

                    // Adding sb instance into list.
                    subtitleBlockList.Add(sb);

                    // Jump into next order number. Every subtitle blocks are seperated via new line. While loop is on text content, jumping two more lines reacher next subtitle block's order number.
                    // 744
                    // 00:04:00,000 --> 00:04:01,000
                    // and, she said she loved me. (from here)
                    //
                    // 745 (to here)
                    // 00:04:05,000 --> 00:04:07,000
                    // Really?
                    i += 2;
                }

                // Returning list of SubtitleBlocks.
                return subtitleBlockList;

                // GetInlineText uses index value to use subitle blocks and creates list for lines of contents, trims content line by line and return them. 
                List<string> GetInlineText()
                {
                    // Variable holds lines of contents.
                    List<string> _innerTextList = new List<string>();

                    // Loop while next line is not null and file content is not finished
                    while ((i + 2 < subtitleLines.Length) && string.IsNullOrEmpty(subtitleLines[i + 2]) == false)
                    {
                        #region Trimming

                        // Checks if line containts empty space on left side or right side of text.
                        if (subtitleLines[i + 2].Trim() != subtitleLines[i + 2])
                        {
                            // Adding line of content into s_trimmedLineIndexList to reach values later.
                            s_trimmedLineIndexList.Add(i + 2);

                            // Trimming item via string.Trim();
                            subtitleLines[i + 2] = subtitleLines[i + 2].Trim();
                        }

                        #endregion Trimming

                        // Adding line into internal variable.
                        _innerTextList.Add(subtitleLines[i + 2]);

                        // Increasing variable to check if next line is null, empty or filled line.
                        i++;
                    }

                    // Returning list of text contents.
                    return _innerTextList;
                }
            }
            catch (Exception ex)
            {
                //
                throw ex;
            }
        }

        /// <summary>
        /// [Unsafe] Returns parsed contents. This method trims text contents of given subtitle lines.
        /// </summary>
        /// <param name="subtitleLines">Lines of contents to be parsed</param>
        /// <returns>List of SubtitleBlock (List[SubtitleBlock])</returns>
        public static List<SubtitleBlock> ParseSubtitleListUnsafe(string[] subtitleLines)
        {
            // List of subtitle blocks to be filled.
            List<SubtitleBlock> subtitleBlockList = new List<SubtitleBlock>();

            // Integer variable for loop. The reason it is
            int i;

            // Loop for subtitle lines
            for (i = 0; i < subtitleLines.Count(); i++)
            {
                // Creating instance of SubtitleBlock
                SubtitleBlock sb = new SubtitleBlock
                {
                    // Order number is an integer holds sequence of subtitle blocks. It splits line if it containts a dot and take first part. If it doesn't containts a dot it converts string to Int32.
                    orderNumber = Convert.ToInt32(subtitleLines[i].Split('.')[0]),

                    // 00:00:00,000 --> 00:00:01,000

                    // TODO: CultureInvariant? (dot or comma)
                   
                    // Take first 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().  
                    startTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(0, 12), @"hh\:mm\:ss\,fff", null),

                    // Take last 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().
                    endTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(17, 12), @"hh\:mm\:ss\,fff", null),

                    // Calls GetInlineText() to fill inlineTextList. GetInlineText() returns lines of contents on specified SubtitleBlock
                    inlineTextList = GetInlineText(),
                };

                // Adding sb instance into list.
                subtitleBlockList.Add(sb);

                // Jump into next order number. Every subtitle blocks are seperated via new line. While loop is on text content, jumping two more lines reacher next subtitle block's order number.
                // 744
                // 00:04:00,000 --> 00:04:01,000
                // and, she said she loved me. (from here)
                //
                // 745 (to here)
                // 00:04:05,000 --> 00:04:07,000
                // Really?
                i += 2;
            }

            // Returning list of SubtitleBlocks.
            return subtitleBlockList;

            // GetInlineText uses index value to use subitle blocks and creates list for lines of contents, trims content line by line and return them. 
            List<string> GetInlineText()
            {
                // Variable holds lines of contents.
                List<string> _innerTextList = new List<string>();

                // Loop while next line is not null and file content is not finished
                while ((i + 2 < subtitleLines.Length) && string.IsNullOrEmpty(subtitleLines[i + 2]) == false)
                {
                    #region Trimming

                    // Checks if line containts empty space on left side or right side of text.
                    if (subtitleLines[i + 2].Trim() != subtitleLines[i + 2])
                    {
                        // Adding line of content into s_trimmedLineIndexList to reach values later.
                        s_trimmedLineIndexList.Add(i + 2);

                        // Trimming item via string.Trim();
                        subtitleLines[i + 2] = subtitleLines[i + 2].Trim();
                    }

                    #endregion Trimming

                    // Adding line into internal variable.
                    _innerTextList.Add(subtitleLines[i + 2]);

                    // Increasing variable to check if next line is null, empty or filled line.
                    i++;
                }

                // Returning list of text contents.
                return _innerTextList;
            }
        }
    }
}