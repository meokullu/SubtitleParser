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
        /// Returns parsed contents. This method trims text contents of given subtitle lines.
        /// </summary>
        /// <param name="subtitleLines">Lines of contents to be parsed</param>
        /// <param name="subtitleTimeFormat"></param>
        /// <returns>List of SubtitleBlock (List[SubtitleBlock])</returns>
        public static List<SubtitleBlock> ParseSubtitleList(string[] subtitleLines, SubtitleTimeFormat subtitleTimeFormat = null)
        {
            //
            if (subtitleTimeFormat == null)
            {

                //
                subtitleTimeFormat = s_defaultSubtitleTimeFormat;
            }

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
                        OrderNumber = Convert.ToInt32(subtitleLines[i].Split('.')[0]),

                        // 00:00:00,000 --> 00:00:01,000

                        // Take first 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().  
                        StartTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(subtitleTimeFormat.StartTimeOffset, subtitleTimeFormat.StartTimeLenght), subtitleTimeFormat.TimeStringFormat, null),

                        // Take last 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().
                        EndTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(subtitleTimeFormat.EndTimeOffset, subtitleTimeFormat.EndTimeLenght), subtitleTimeFormat.TimeStringFormat, null),

                        // Calls GetInlineText() to fill inlineTextList. GetInlineText() returns lines of contents on specified SubtitleBlock
                        InlineTextList = GetInlineText(),
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
                    List<string> innerTextList = new List<string>();

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
                        innerTextList.Add(subtitleLines[i + 2]);

                        // Increasing variable to check if next line is null, empty or filled line.
                        i++;
                    }

                    // Returning list of text contents.
                    return innerTextList;
                }
            }
            catch (Exception ex)
            {
                // Returning exception.
                throw ex;
            }
        }

        /// <summary>
        /// [Unsafe] Returns parsed contents. This method trims text contents of given subtitle lines.
        /// </summary>
        /// <param name="subtitleLines">Lines of contents to be parsed</param>
        /// <param name="subtitleTimeFormat">Default provided.</param>
        /// <returns>List of SubtitleBlock (List[SubtitleBlock])</returns>
        public static List<SubtitleBlock> ParseSubtitleListUnsafe(string[] subtitleLines, SubtitleTimeFormat subtitleTimeFormat = null)
        {
            //
            if (subtitleTimeFormat == null)
            {
                //
                subtitleTimeFormat = s_defaultSubtitleTimeFormat;
            }

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
                    OrderNumber = Convert.ToInt32(subtitleLines[i].Split('.')[0]),

                    // 00:00:00,000 --> 00:00:01,000

                    // Take first 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().  
                    StartTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(subtitleTimeFormat.StartTimeOffset, subtitleTimeFormat.StartTimeLenght), subtitleTimeFormat.TimeStringFormat, null),

                    // Take last 12 characters of the line and create TimeSpan via TimeSpan.ParseExact().
                    EndTime = TimeSpan.ParseExact(subtitleLines[i + 1].Substring(subtitleTimeFormat.EndTimeOffset, subtitleTimeFormat.EndTimeLenght), subtitleTimeFormat.TimeStringFormat, null),

                    // Calls GetInlineText() to fill inlineTextList. GetInlineText() returns lines of contents on specified SubtitleBlock
                    InlineTextList = GetInlineText(),
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
                List<string> innerTextList = new List<string>();

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
                    innerTextList.Add(subtitleLines[i + 2]);

                    // Increasing variable to check if next line is null, empty or filled line.
                    i++;
                }

                // Returning list of text contents.
                return innerTextList;
            }
        }
    }
}
