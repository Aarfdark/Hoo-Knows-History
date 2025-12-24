Hoo Knows History - Augmented Reality Tour App for UVA
  
  *Builds on iOS only

Aadarsh Natarajan, Lauren Hruza, Rythama Chevendra, Kathleen O'Donovan

NOTE: App can be fully simulated on Unity, but requires a Mac to run XCode for iPhone deployment

INSTRUCTIONS TO USE:

To use the app build and deploy to compatible iOS device with camera access. Click "Start Tour" and that will bring up the camera with the AR system ready. Click the megaphone button to start the narration and follow the given instructions. Each tour stop will have a physical image to scan with the camera and display the corresponding artifact. Travel to each tour spot and learn!

INSTRUCTIONS TO DEPLOY/BUILD:

- Under project directory, create a folder named Build

- Open project on Unity, ensure an updated editor version is used

- Go to the top of the screen: File > Build Profiles

- Left side of the screen, go to Platforms > iOS > click Add Build Profile

- Under Platform settings > enable Development Build

- Under Configuration > put a description (can be just a word or two) under:
  Camera Usage Description
  Microphone Usage Description
  Location Usage Description

- Stay under Configuration > set Target Minimum iOS Version = 15.0

- On the bottom of the tab, select Build And Run

- Select the Build folder previously created

- If you see a warning that says "Missing Project ID", click Continue

- XCode should automatically start

- Connect iPhone to Mac with a cord

- Go into iPhone Settings > Privacy & Security > Developer Mode. iPhone will restart when turned ON

- On top of the XCode page, make sure iPhone is connected. Should see:
  Unity-iPhone > [your phone name]

- If provisioning profile error is seen (Unity-iPhone requires a provisioning profile), do the following:
  Double click on error
  Click YES for Automatically manage signing
  Under Team, select your Apple ID (login if required)
  Under Bundle Identifier, replace DefaultCompany with unique string

- On iPhone, go to Settings > General > VPN & Device Management

- Select to trust Developer App labeled with your Apple ID

- Click Play button on top left of the screen

SOURCES USED:
ChatGPT

Claude

StackOverflow

https://www.youtube.com/watch?v=RMOMTyfECTk

https://www.youtube.com/watch?v=7N637e3NuIE

https://www.cvillepedia.org/Catherine_Foster

https://encyclopediavirginia.org/entries/foster-kitty-ca-1790-1863/

https://uvamagazine.org/articles/serpentine_timeline

https://www.youtube.com/watch?v=-Hr4-XNCf8Y

https://developer.vuforia.com/library/vuforia-engine/getting-started/development-environments/getting-started-vuforia-engine-unity/
