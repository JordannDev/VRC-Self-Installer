# VRC Simple Install

Simple application that allows controllers to quickly get the latest VRC facility files for a facility. 

(I will add support for other clients (ie Euroscope, vSTARS, vERAM) soon).

![Program Image](https://i.imgur.com/FN7PDAW.png)

## How it works

The facility configures it (using the source), then sends it out to their controllers. Then when it comes time for a controller to download the files, it will remove all files and folders in the destination folder (where your facility files are, usually VRC/Files/ZZZ), then it will automatically download new files, and extract the .zip file (only .zip files are supported currently, feel free to add support for other extensions if you wish).

Keep in mind, for this to be 'effective' without changes, your file URL needs to stay the same. So if the link for your files is 'site.com/files/vrc-1908.zip' it won't be very effective as you will need to constantly change the name of the file in the source, and resend out the file.

To avoid this, just keep the name the same. For example: 'site.com/files/vrc.zip'.

## Compiling

I didn't include the entire project (ie the .sln file and debug) so unless you copy and paste you won't be able to build it, if you want me to make a build for you shoot me an [email](mailto:admin@jordie.ml).

## Bugs/Problems

If any issues arise feel free to open an issue on the "Issues" page (near the project title). 

## NOTE

**If you are using Dropbox for sharing files, make sure you don't delete the file, and reupload, just overwrite it (ie drag and drop), so the URL will stay the same. Also the program will not throw an error if the file does not exist if you are using Dropbox.**