using UnityEngine;

namespace CharacterExpressions
{
    public class CharacterExpression_Jaw_Controller : MonoBehaviour
    {
        public GameObject JawIKRig_Target;

        public bool Talking = true;
        public Vector2 Range = Vector2.zero;
        private CharacterExpression_Jaw_TalkingPresets CurrentTalkingPreset = CharacterExpression_Jaw_TalkingPresets.Custom;
        public CharacterExpression_Jaw_TalkingPresets TalkingPreset = CharacterExpression_Jaw_TalkingPresets.Custom;
        private float Intensity_Scale = 1.0f;
        public float Intensity = 1.0f;
        public float Variability = 0.0f;
        public float VariabilitySpeed = 1.0f;
        public float Speed = 1.0f;
        private float Orientation = 0.0f;
        private float PreviousIntensity = 1.0f;     
        private const float Variability_Scale = 1.0f;
        private const float Speed_Scale = 7.1f;
        private const float VariabilitySpeed_Scale = 10.2f;

        void Start()
        {
            CurrentTalkingPreset = TalkingPreset; 
            Intensity_Scale = Range.y - Range.x;
            PreviousIntensity = Intensity_Scale;
            CharacterExpressionService.UpdateTalkingVariablesBasedOnPreset(TalkingPreset, out Intensity, out Variability, out VariabilitySpeed, out Speed);
        }

        void Update()
        {
            if (CurrentTalkingPreset != TalkingPreset)
            {
                CurrentTalkingPreset = TalkingPreset;
                CharacterExpressionService.UpdateTalkingVariablesBasedOnPreset(TalkingPreset, out Intensity, out Variability, out VariabilitySpeed, out Speed);
            }
          
            CharacterExpressionService.UpdateJaw(JawIKRig_Target,
             Talking == false,
             Intensity_Scale,
             PreviousIntensity,
             Orientation,
             Variability_Scale,
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
      
        public void SetIntensity(float intensity)
        {
            Talking = intensity > 0.0f;
            Intensity = intensity;
        }
    }
}
