# FSRandomizer
FSRandomizer allows you to create your own career in Clone Hero with the entire Guitar Hero series scaled by difficulty (with some surprises!) so that revisitting the games is as fun and exciting as playing career for the first time!

# Description
This application picks up a list from [FSRandomizer-Web](https://github.com/rafaelgpires/FSRandomizer-Web) and a compatible "Full Series Charts" zipped file, hosted [here](https://fsrandomizer.psarchives.com/).

With it, it does the following:
1. Backs up the users' current custom content from Clone Hero's installation folder (*/songs/* into */songs_backup/*),
2. Unzips the full series file into it,
3. Orders the full series folder structure into chapters matching the given list,
4. Edits each individual song.ini to match the playlist_track, intended difficulty and adds encore names,
5. Changes Clone Hero's settings to automatically sort by Playlist.

# How to Compile
This project was compiled using VS2015, though it should work with the current version of VSCommunity.  
To use it, simply open the .sln file, remove any signing (Project -> Properties -> Signing, or equivalent) and compile.

# How to Help
If you'd like to sign the current project to host safe binaries, please contact through [here](https://fsrandomizer.psarchives.com/).

# Future Features
Planning these features in the following priority:
  1. **Improve unzipping**: Use embedded 7zip libraries
  2. **Improve progress tracking**: 7zip libraries can easily report progress
  3. **Clean up project files, code and optimise**
  4. **Downloader**: Download manage the full series zipped file
  5. **User's Charts**: Allow the user to use his own folder for the charts instead of ours, many users already have the full series downloaded and won't use this due to requiring redownloading 18GB worth of data. This is a major endeavor that should do the following to ensure everyone plays on the same charts:
      * **Hash Charts**: Hash our current charts and host it within [FSRandomizer-Web](https://github.com/rafaelgpires/FSRandomizer-Web).
      * **Compare Hashes**: We can't rely on song names, so hash every chart in the user folder and match it to ours.
      * **Standardize the Folder**: Standardize the folder so it looks exactly like our currently published zip.
      * **Transfer List**: Run the remaining commands using this folder instead of downloading one.
