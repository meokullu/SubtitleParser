## SubtitleParser Changelog
[![SubtitleParser](https://img.shields.io/nuget/v/SubtitleParser.svg)](https://www.nuget.org/packages/SubtitleParser/)

<!--
### [Unreleased]

#### Added

#### Changed

#### Removed
-->

### [2.3.0]
#### Added
* `GetTextByLines(string filePath, Encoding encoding)` is added.
* `GetTextByLinesUnsafe(string filtePath, Encoding encoding)` is added.
* Override ToString() method of `SubtitleBlock` is added.

### [2.2.2]
#### Added
* `GetText.cs`, `Parse.cs`, `SubtitleBlock.cs`, `SubtitleTimeFormat.cs` and `Trim.cs` are created. `SubtitleParser.cs` is splitted into them based on purpose.

#### Changed
* Fixing summaries of some methods.
* Fixing violating of naming on variable.

### [2.2.1]
#### Changed
* New design README.
* New design CHANGELOG.

### [2.2.0]
#### Added
`SubtitleTimeFormat` is available. It is to declare how time string to be parsed on `ParseSubtitleList()` and `ParseSubtitleListUnsafe()`

#### Changed
* Icon was replaced with solid white background.

### [2.1.2]
#### Added
* Wiki link added under Example Usage on README.
* CHANGELOG link added under Version History on README.
* Multiple tags added for PackageTags.

#### Changed
* CHANGELOG has better view.
* LICENCE.txt renamed as LICENCE.

### [2.1.1]
#### Changed
* Icon was replaced with higher resolution.

### [2.1.0]
#### Added
*  Multi-target frameworks (net6.0; net7.0; net461; netcoreapp3.1; netstandard2.0) support is added.

### [2.0.2]
#### Changed
* Fixed naming violations.

### [2.0.1]
#### Changed
* Fixed naming violations.

### [2.0.0]
#### Changed
* Fixing naming vialations inside of `SubtitleBlock`. Public members names start with uppercase now.

### [1.2.0]
#### Added
* Added `TrimmedLineIndexList` publicly available.
* Added OutputDLL which contains .dll and .xml file.

### [1.1.0]
#### Added
 * Adding xml summaries to `SubtitleBlock` class and its elements. 
 * Support Unsafe versions of `ParseSubtitleList()` and `GetTextByLines()`.

#### Fixed
 * Hotfix on `GetInlineText()` local function.

### [1.0.0]
Initial version