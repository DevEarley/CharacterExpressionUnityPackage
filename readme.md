# Character Expressions for Unity3D
This package includes two systems for animating character expressions. One for animiating the jaw and one for the eyes. You can use behaviours and animators to control them or you can use the timeline.

## What's in this package
- Jaw IK rig builder. `CharacterExpression_Jaw_IKRigBuilder.cs`
	- Builds an IK rig with a transform override for you. This IK rig is required by the jaw animation scripts.
- Jaw Animation Behaviour. `CharacterExpression_Jaw_Behaviour.cs`
- Jaw Animation Timeline Playable Clip, Mixer & Track
- Eyes Animation Behaviour. `CharacterExpression_Eyes_Behaviour.cs`
- Blinking Animation Timeline Playable & Track
- Sample Character. `Samples\Scripts\Model_Anderson.fbx`
	- Includes a few expressions and pupil colors.

## Add this package to your unity project
Go to ```Window > Package Manager > The plus sign in the upper left > "Install Package from git URL"``` and paste:
```
https://github.com/DevEarley/CharacterExpressionUnityPackage.git
```
![https://i.imgur.com/eDtOOIa.gif](https://i.imgur.com/eDtOOIa.gif)

## Setup - Jaw
You may use the `Jaw IK Rig builder` to quickly setup the rig needed for the jaw. 
Attach the Jaw IK Rig Builder to the root of your character. Lock the inspector to this GO. 

## Setup - Eyes
You will need to create two spritesheets for each expression. One for the base map and one for the emission map. You may need to change the texture name depending on which shader you are using. 

## Timelines, Playables & Tracks
### Timelines & Jaw Setup
Add a CharacterExpression_Jaw_PlayableTrack to the timeline and assign the JawIKRig_Target to it. Right click on the track and add a new clip. You will need to play with the target to get a feel for the correct range. Select the talking pattern you wish for this clip. 

## Credits
3D model from the MHS project from Adroit Studios.

## License
The all of the code in this repo is released under Creative Commons Zero. The 3D model belongs to Adroit Studios.

## Todo
⊕ Fix blending between playable clips.

⊕ Add more presets.

⊕ Add more detail to this readme.

⊕ Create change log.
