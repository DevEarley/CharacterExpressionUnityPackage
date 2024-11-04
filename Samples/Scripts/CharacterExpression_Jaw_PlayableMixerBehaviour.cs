using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Playables;
using static UnityEngine.InputSystem.OnScreen.OnScreenStick;

namespace CharacterExpressions
{
    public class CharacterExpression_Jaw_PlayableMixerBehaviour : PlayableBehaviour
    {
        // NOTE: This function is called at runtime and edit time.  Keep that in mind when setting the values of properties.
        public override void ProcessFrame(Playable playable, FrameData info, object playerData)
        {
            GameObject trackBinding = playerData as GameObject;

            if (!trackBinding)
                return;

            int inputCount = playable.GetInputCount();
            var allWeightsAreZero = true;
            
            for (int i = 0; i < inputCount; i++)
            {
                float inputWeight = playable.GetInputWeight(i);
                ScriptPlayable<CharacterExpression_Jaw_PlayableBehaviour> inputPlayable = (ScriptPlayable<CharacterExpression_Jaw_PlayableBehaviour>)playable.GetInput(i);
                CharacterExpression_Jaw_PlayableBehaviour behaviour = inputPlayable.GetBehaviour();
                if (inputWeight > 0.0f)
                {
                    allWeightsAreZero = false;
                    var time = (float)inputPlayable.GetTime();
                    behaviour.ProcessTalking(trackBinding, time, inputWeight);
                }
            }
            if(allWeightsAreZero == true)
            {
               trackBinding.transform.localEulerAngles = Vector3.zero;


            }
        }
    }
}