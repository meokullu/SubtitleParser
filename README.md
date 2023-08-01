# SubtitleParser

SubtitleParser is a project to parse subtitle content data into subtitle blocks.

![SubtitleParser](https://repository-images.githubusercontent.com/672432034/bf798f16-db6c-4461-b6ca-1b963ef2775e)

[Check out on NuGet gallery](https://www.nuget.org/packages/SubtitleParser/)

## Description

SubtitleParser has methods get content lines from specified file path and parse them into subtitle blocks.

## Listed Methods

#### Read Content
```
GetTextByLines(string filePath)
```
```
GetTextByLinesUnsafe(string filePath)
```

Returns lines of contents. (string[])

* filePath: Specified file path

#### Parsing
```
ParseSubtitleList(string[] subtitleLines)
```
```
ParseSubtitleListUnsafe(string[] subtitleLines)
```

Returns list of SubtitleBlocks (List<SubtitleBlock>)

* subtitleLines: Subtitle file's content by lines.

```
S_trimmedLineIndexList
```

Returns line list of content that are trimöed.

## Version History

* 2.0.0
  * Fixing naming vialations inside of SubtitleBlock. Public members names start with uppercase now.

* 1.2.0
  * Added TrimmedLineIndexList publicly available.
  * Added OutputDLL which contains .dll and .xml file.

* 1.1.0
  * Adding xml summaries to SubtitleBlock class and its elements.
  * Hotfix on GetInlineText() local function.
  * Support Unsafe versions of ParseSubtitleList() and GetTextByLines()

* 1.0.0 Initial Release

## Task List
- [x] Safe versions of methods
- [x] Offer TrimmedLineIndexList as public
- [x] Some order numbers are not integers. E.g 1.1 1.2
- [ ] Support multiple culture for notations on time marks.

## Licence
No license is required.

## Authors
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)

## Help
Twitter: Enes Okullu [@enesokullu](https://twitter.com/EnesOkullu)
