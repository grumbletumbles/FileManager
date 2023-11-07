# FileManager

This is a console application to work with files. I did this as a part of my course in object oriented programming in C#. So there may be a bit too many patterns to my liking and it could be over complicated, but i think it's fine.

## What this can do

* preview files in directory
* preview file content (only works fine for .txt files, produces random utf8 noise otherwise)
* move files
* delete files
* copy files
* rename files

The app accepts certain commands and executes them one by one, meaning you can't give it multiple commands in a single line.
Here is the list of commands:
* connect [Address] {-m Mode}

  Mode can only be `local`
* disconnect
* tree goto [Path]
* tree list {-d Depth}

  Depth shows how many nested directories the tree can contain. By default it is set to 1.
* file show [Path] {-m Mode}

  Mode can only be `console`
* file move [SourcePath] [DestinationPath]
* file copy [SourcePath] [DestinationPath]
* file delete [Path]
* file rename [Path] [Name]

`-m Mode` in `connect` and `file show` commands doesn't seem to do anything, and that's the point. The app is meant to be "scalable", but this version does not support anything that is outside the local file system or non-console output.  

You can also customize the characters for directories, files and tabs in `tree list`!
