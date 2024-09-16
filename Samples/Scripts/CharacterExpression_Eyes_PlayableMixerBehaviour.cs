using UnityEngine;
using UnityEngine.Playables;

namespace CharacterExpressions
{
    public class CharacterExpression_Eyes_PlayableMixerBehaviour : PlayableBehaviour
    {
        public CharacterEyeExpressions current;

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
                ScriptPlayable<CharacterExpression_Eyes_PlayableBehaviour> inputPlayable = (ScriptPlayable<CharacterExpression_Eyes_PlayableBehaviour>)playable.GetInput(i);
                CharacterExpression_Eyes_PlayableBehaviour behaviour = inputPlayable.GetBehaviour();
                if (inputWeight > 0.0f)
                {
                    behaviour.Blink(trackBinding);
                    if (current != behaviour.CharacterExpression)
                    {
                        current = behaviour.CharacterExpression;
                        CharacterExpressionService.UpdateCharacterExpression(behaviour.CharacterExpression, behaviour.EyelidMat, behaviour.EyelidTextures);
                    }
                }
            }
        }
    }
}
