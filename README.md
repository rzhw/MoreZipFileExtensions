# MoreZipFileExtensions

.NET 4.5 introduced the ZipArchive class, a much easier way of working with zip files than, well, System.IO.Packaging.
Want to create an entry from a file? CreateEntryFromFile.
Want to create an entry from a folder? CreateEntryFromFolder... doesn't exist.
That's where this library comes in!

## What's it do right now?

A quick usage example shows it best:

	using MoreZipFileExtensions; // Just include this

    using (var fileStream = new FileStream(pathToZip, FileMode.Create))
    using (var zip = new ZipArchive(fileStream, ZipArchiveMode.Create))
    {
        zip.CreateEntryFromFile(pathToFile, fileName); // Built-in
        zip.CreateEntryFromFolder(pathToFolder, folderName); // Now you get this
    }

## Supported platforms

- .NET 4.5 (Desktop / Server)

(Although the ZipArchive class was introduced in .NET 4.5 and is also implemented in WinRT,
as with ZipFileExtensions, only desktop/server applications are supported.
Mono has been untested; if you try it out before I do, let me know how it goes.)

## Installation

You can find this on NuGet.

> Install-Package MoreZipFileExtensions