# Character Expressions for Unity3D
> NOTE: This package is a WIP and may be broken. Use at your own risk.

Version 1.0.0 (alpha)

The purpose of this package is to assist animators from animating expressions and talking by hand. This package includes two systems for animating character expressions. One for animiating the jaw and one for the eyes. This package contains behaviours, playables and utilities for controlling eye and jaw expressions.

## Add this package to your unity project
Go to ```Window > Package Manager > The plus sign in the upper left > "Install Package from git URL"``` and paste:
```
https://github.com/DevEarley/CharacterExpressionUnityPackage.git
```
![Adding this package to your unity project](https://i.imgur.com/431oi6l.gif)

## What's in this package
- Jaw IK rig builder. `Samples/Scripts/CharacterExpression_Jaw_IKRigBuilder.cs`
	- Builds an IK rig with a transform override for you. This IK rig is required by the jaw animation scripts.
- Jaw Animation Behaviour. `Samples/Scripts/CharacterExpression_Jaw_Behaviour.cs`
- Jaw Animation Timeline Playable Clip, Mixer & Track
- Eyes Animation Behaviour. `Samples/Scripts/CharacterExpression_Eyes_Behaviour.cs`
- Blinking Animation Timeline Playable & Track
- Sample Character. `Samples/Character/Model_Anderson.fbx`
	- Includes a few expressions and pupil colors.

## Jaw Expressions
### Setup - Using the Jaw IK Rig Builder
You may use the `Jaw IK Rig builder` to quickly setup the rig needed for the jaw. 
Attach the Jaw IK Rig Builder to the root of your character. Lock the inspector to the root GO. Locate the jaw bone in the character's rig. Assign the jaw to the IK Jaw Bone property in the inspector. Click the button to build the rig. The rig builder has done it's job and will remove it self once the rig has been built. 

![Using the Jaw IK Rig Builder](https://i.imgur.com/Q7njccg.gif)

## Setup - Jaw Behaviour
Attach a `CharacterExpression_Jaw_Behaviour` to the root of your character. Assign the `Jaw_IK_Target` to the property in the behaviour. The target is a child of the IK rig. Use the IK Rig Bui	lder to set this up.

Choose a preset talking behaviour from the dropdown. This property can be animated from an animation clip or accessed by another behaviour.

![Using the Jaw Behaviour](https://i.imgur.com/RJmmCIJ.gif)

## Setup - Jaw Playable (with Timelines)
Create a new timeline. Add a new track. Select `Character Expressions > Jaw Playable Track`. Drag the `Jaw_IK_Target` into the property input on the new track. Right click on this new track and select `Create new Jaw Playable Clip`. Select the new clip and choose the preset for that clip.

![Using the Jaw Playable](https://i.imgur.com/hpyIXR4.gif)

## Eye Expressions
This package has 6 defined expressions: Neutral, Happy, Angry, Confused, Sad and Sleeping Your model will need to have UV mapped eyes for this system to work.
This expression system is setup to work with the each eye mapped to the same position on the UV. 
Each expression requires 3 textures. A base map, an emissive texture, and a detail mask. 

### Eye Shapes
Each eye shape will require textures for each expression. Consider 10 eye shapes, times 5 eye expressions, times 3 textures is: 150 textures in your game just for character eyes. Carefully consider which textures are really necessary. Maybe not all characters show anger or sadness in your game. Also consider some emotions may look similar to others. Confused looks very similar to angry. Sad can be the same as sleeping.

### Pupil colors
The pupil color can be controlled using the detail map. You will need one texture per color. These textures can be a solid color or a gradient. You do not need to create multiple pupil textures for each eyeshape or expression. 

## Setup - Eye expressions 
### Eye Material
This package supports any shader for the character's eyes. You will need to provide texture names to the `Eye Textures Prefab` (see below). Regardless of the shader you use, the shader will need an albedo map(aka base map or main texture), an emission texture and a detail mask. URP and Standard shaders have these textures.

![Assigning the textures to the material](https://i.imgur.com/lm8R11I.gif)

### Base Map Texture
This package's example character uses 4 frames of animation for blinking. The first frame is of the eye totally open. Second and third frames are partially open. The fouth frame is totally closed. Note: To create an expression like "sleeping" just make each frame totally closed. 

![Eye Base Map](https://i.imgur.com/7FzdBTa.png)

### Pupil colors & Detail Mask Texture
Duplicate the base map and open it in your photo editor. Select the pupils. Create a new layer and fill it white. Fill the background black. Do this for each expression.
![Making the mask in Paint Dot NET](https://i.imgur.com/h3L70K9.gif)
### Emissive Texture
Duplicate the base map and open it in your photo editor of choice. Remove the saturation from the base map and increase the contrast so that whites of the eyes are against a black background. Do this for each expression.
![Using the mask to make the emission map](https://i.imgur.com/OSAhaUJ.gif)

### Eye Textures Prefab 
The `CharacterExpression_Eyes_Textures` behaviour needs to be created for each eye shape.
Each shader uses different naming conventions for it's textures. To animate these, you need to provide the name to the `CharacterExpression_Eyes_Textures` Prefab. See table below.


|Shader | Type | Texture Map Name|
|--|--|--|
|Standard Unity Shader|Albedo| "_MainTex" |
|URP Lit | Albedo| "_BaseMap"|
|Standard Unity Shader|Emissive| "_EmissionMap" |
|URP Lit|Emissive| "_EmissionMap"|
|Standard Unity Shader|Detail| "_DetailMask" |
|URP Lit|Detail| "_DetailMask"|

![Setting up the Eye Textures Prefab](https://i.imgur.com/YWkq1eu.gif)


## Eye Expression Behaviour
![Setting up the eye behaviour](https://i.imgur.com/DWiKMyw.gif)

## Eye Expression Playable (with Timelines)
![Setting up the eye playable](https://i.imgur.com/hjMrpyP.gif)

## Credits
3D model from the MHS project from Adroit Studios. Scripts by Alex Earley. Special Thanks to Charles Sielert & Angela Jarecki.

## License
The all of the code in this repo is released under Creative Commons Zero. The 3D model belongs to Adroit Studios.

## Todo & Known Issues
⊕ Fix blending between playable clips.

⊕ Add more blinking presets.

⊕ Add more talking presets.

⊕ Create change log. 

⊕ Add support for individual eye animations. Like looking right or left.

⊕ Support a variable amount of frames per eye.

⊕ Support a variable speed per blink.

⊕ Support custom blinking patterns.

⊕ Support "one-off" blinking. Signal? Public Function? Clip with "blink immediatley" preset.