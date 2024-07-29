# Character Expressions for Unity3D
This package is a WIP and may be broken. Use at your own risk.

This package includes two systems for animating character expressions. One for animiating the jaw and one for the eyes. This package contains behaviours, playables and utilities for controlling eye and jaw expressions.


## What's in this package
- Jaw IK rig builder. `Assets/Scripts/CharacterExpression_Jaw_IKRigBuilder.cs`
	- Builds an IK rig with a transform override for you. This IK rig is required by the jaw animation scripts.
- Jaw Animation Behaviour. `Assets/Scripts/CharacterExpression_Jaw_Behaviour.cs`
- Jaw Animation Timeline Playable Clip, Mixer & Track
- Eyes Animation Behaviour. `Assets/Scripts/CharacterExpression_Eyes_Behaviour.cs`
- Blinking Animation Timeline Playable & Track
- Sample Character. `Samples\Scripts\Model_Anderson.fbx`
	- Includes a few expressions and pupil colors.

## Add this package to your unity project
Go to ```Window > Package Manager > The plus sign in the upper left > "Install Package from git URL"``` and paste:
```
https://github.com/DevEarley/CharacterExpressionUnityPackage.git
```
![https://i.imgur.com/eDtOOIa.gif](https://i.imgur.com/eDtOOIa.gif)

## Jaw Expressions
### Setup - Using the Jaw IK Rig Builder
You may use the `Jaw IK Rig builder` to quickly setup the rig needed for the jaw. 
Attach the Jaw IK Rig Builder to the root of your character. Lock the inspector to the root GO. Locate the jaw bone in the character's rig. Assign the jaw to the IK Jaw Bone property in the inspector. Click the button to build the rig. The rig builder has done it's job and will remove it self once the rig has been built. 

### Setup - Jaw Behaviour
Attach a `CharacterExpression_Jaw_Behaviour` to the root of your character. Assign the `Jaw_IK_Target` to the property in the behaviour. The target is a child of the IK rig. Use the IK Rig Builder to set this up.

Choose a preset talking behaviour from the dropdown. This property can be animated from an animation clip or accessed by another behaviour.

### Setup - Jaw Playable (with Timelines)
Create a new timeline. Add a new track. Select `Character Expressions > Jaw Playable Track`. Drag the `Jaw_IK_Target` into the property input on the new track. Right click on this new track and select `Create new Jaw Playable Clip`. Select the new clip and choose the preset for that clip.

## Eye Expressions
Your model will need to have UV mapped eyes for this system to work.
This expression system is setup to work with the each eye mapped to the same position on the UV. 
### Setup - Creating Eye expressions
Each expression requires 3 textures. A base map, an emissive texture, and a detail mask. 
#### Setup - Eye expressions - Eye Textures Prefab


#### Setup - Eye expressions - Base Map
A base map with skin details and 4 frames of an eye closing shut. The first frame is totally open. Sendcond and third frames are partially open. The fouth frame is totally closed. Note: To create an expression like "sleeping" just make each frame totally closed. 
#### Setup - Eye expressions - Emissive Texture
#### Setup - Eye expressions - Pupil colors & Detail Mask Texture

#### Setup - Eye expressions - Texture names
Each shader uses different naming conventions for it's textures. To animate these, you need to provide the name to the `CharacterExpression_Eyes_Textures` Prefab.
|Shader | Type | Texture Map Name|
|--|--|--|
|Standard Unity Shader|Albedo| "_MainTex" |
|URP Lit | Albedo| "_BaseMap"|
|Standard Unity Shader|Emissive| "_EmissionMap" |
|URP Lit|Emissive| "_EmissionMap"|
|Standard Unity Shader|Detail| "_DetailMask" |
|URP Lit|Detail| "_DetailMask"|


## Credits
3D model from the MHS project from Adroit Studios.

## License
The all of the code in this repo is released under Creative Commons Zero. The 3D model belongs to Adroit Studios.

## Todo
⊕ Fix blending between playable clips.

⊕ Add more presets.

⊕ Add more detail to this readme.

⊕ Create change log.

⊕ Add support for individual eye animations. Like looking right or left.