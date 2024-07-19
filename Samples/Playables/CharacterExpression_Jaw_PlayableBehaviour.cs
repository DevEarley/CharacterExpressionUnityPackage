using System;
using UnityEngine;
using UnityEngine.Playables;

namespace CharacterExpressions
{
    [Serializable]
    public class CharacterExpression_Jaw_PlayableBehaviour : PlayableBehaviour
    {

        public CharacterExpression_Jaw_TalkingPresets talkingPreset;
        public Vector2 Range = new Vector2(15.0f, 30.0f); // can we make this const?
        private float Speed;
        private float Intensity;
        private float Variability;
        private float VariabilitySpeed;
        private float Intensity_Scale = 1.0f;
        private float PreviousIntensity = 1.0f;
        private float Orientation = 1.0f;
        private const float Variability_Scale = 1.0f;

        private const float Speed_Scale = 7.1f;
        private const float VariabilitySpeed_Scale = 10.2f;

        public override void OnGraphStart(Playable playable)
        {
            Intensity_Scale = Range.y - Range.x;
            PreviousIntensity = Intensity_Scale;

            CharacterExpressionService.UpdateTalkingVariablesBasedOnPreset(talkingPreset, out Intensity, out Variability, out VariabilitySpeed, out Speed);
            base.OnGraphStart(playable);
        }

        public void ProcessTalking(float inputWeight, GameObject JawBone) // TODO: multiply Intensity with input Weight?
        {
            CharacterExpressionService.UpdateJaw(JawBone,
                false,
                Variability_Scale,
                Intensity_Scale,
                PreviousIntensity,
                Orientation,
                Range,
                Variability,
                VariabilitySpeed,
                Speed,
                VariabilitySpeed_Scale,
                Speed_Scale,
                Intensity,
                out Intensity_Scale,
                out PreviousIntensity,
                out Orientation);
        }


        public void StopTalking(float inputWeight, GameObject JawBone) // TODO: multiply Intensity with input Weight
        {
            CharacterExpressionService.UpdateJaw(JawBone,
                true,
                Variability_Scale,
                Intensity_Scale,
                PreviousIntensity,
                Orientation,
                Range,
                Variability,
                VariabilitySpeed,
                Speed,
                VariabilitySpeed_Scale,
                Speed_Scale,
                Intensity,
                out Intensity_Scale,
                out PreviousIntensity,
                out Orientation);
        }
    }
}