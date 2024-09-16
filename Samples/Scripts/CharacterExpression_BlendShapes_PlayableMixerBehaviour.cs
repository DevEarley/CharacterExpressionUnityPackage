using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

namespace CharacterExpressions
{
        public class CharacterExpression_BlendShapes_PlayableMixerBehaviour : PlayableBehaviour
    {
    

        // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            SkinnedMeshRenderer trackBinding = playerData as SkinnedMeshRenderer;

            if (!trackBinding)
                return;

            int inputCount = playable.GetInputCount();

            
            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<CharacterExpression_BlendShapes_PlayableBehaviour> inputPlayable = (ScriptPlayable<CharacterExpression_BlendShapes_PlayableBehaviour>)playable.GetInput(i);
                CharacterExpression_BlendShapes_PlayableBehaviour behaviour = inputPlayable.GetBehaviour();
            
       
                    var time = (float)inputPlayable.GetTime();
                    behaviour.ProcessBlendShapes(trackBinding, time, inputWeight);
                
            }
    
        }
    }
}