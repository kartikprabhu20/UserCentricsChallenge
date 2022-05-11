# UserCentricsChallenge

The app screenshots and flow are shown below:
 
<div class="imageClass">	
<img src="https://github.com/kartikprabhu20/UserCentricsChallenge/blob/main/images/Flow.png?raw=true" width="800" height="960"> 
</div>

The Usercentric consent popup is shown when the app starts or it can be accessed using settings. The user can also reset the consents using the settings.

Build:
- Unity Version : 2020.3.25f1
- OS version : macOS 12.2.1 
- Tested on : Android 11


Troubleshooting:
In case of error in building apk with targetsdkversion: 31.0.0 follow the below solution
- Go to the build-tools path and into the folder 31.0.0 and rename  2 files 
- Rename d8.jar to dx.jar in /31.0.0 and /31.0.0/lib or use the below command.
- cd ~/Library/Android/sdk/build-tools/31.0.0 \ 
  && mv d8 dx \
  && cd lib  \
  && mv d8.jar dx.jar
 
