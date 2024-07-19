# Character Expressions for Unity3D
This package includes two systems for animating character expressions.One for animiating the jaw and one for the eyes. You can use behaviours and animators to control them or you can use the timeline.

## Setup - Jaw
You may use the CharacterExpression IK Rig builder to quickly setup the rig needed for the jaw. 

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