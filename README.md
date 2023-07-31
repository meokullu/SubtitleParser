# SubtitleParser

SubtitleParser is a project to parse subtitle content data into subtitle blocks.

[Check out on NuGet gallery](https://www.nuget.org/packages/SubtitleParser/)

## Description

SubtitleParser has methods get content lines from specified file path and parse them into subtitle blocks.

## Listed Methods

#### Read Content
```
GetTextByLines(string filePath)
```

Returns lines of contents. (string[])

* filePath: Specified file path

#### Parsing
```
ParseSubtitleList(string[] subtitleLines)
```

Returns list of SubtitleBlocks (List<SubtitleBlock>)

* subtitleLines: Subtitle file's content by lines.

## Version History

* 1.1.0
  * Adding xml summaries to SubtitleBlock class and its elements.
  * Hotfix on GetInlineText() local function.
  * Support Unsafe versions of ParseSubtitleList() and GetTextByLines()

* 1.0.0 Initial Release

## Task List
- [ ] Safe versions of methods
- [ ] Offer TrimmedLineIndexList as public
- [ ] Support different culture options

## Licence
No license is required.

## Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

## Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
