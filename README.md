# VRC Simple Install

Simple application that allows controllers to quickly get the latest VRC facility files for a facility. 

## How it works

The facility configures it (using the source), then sends it out to their controllers. Then when it comes time for a controller to download the files, it will remove all files and folders in the destination folder (where your facility files are, usually VRC/Files/ZZZ), then it will automatically download new files, and extract the .zip file (only .zip files are supported currently, feel free to add support for other extensions if you wish).

## Compiling

I didn't include the entire project (ie the .sln file and debug) so unless you copy and paste you won't be able to build it, if you want me to make a build for you shoot me an [email](mailto:admin@jordie.ml).

## Bugs/Problems

If any issues arise feel free to open an issue on the "Issues" page (near the project title). 

