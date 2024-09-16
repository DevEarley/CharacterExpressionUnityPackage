using UnityEngine;

namespace CharacterExpressions
{
    public class CharacterExpression_Jaw_Behaviour : MonoBehaviour
    {
        public GameObject JawIKRig_Target;

        public bool Talking = true;

        private CharacterExpression_Jaw_Configuration CurrentConfig;
        public CharacterExpression_Jaw_Configuration Config;

        private float CurrentOrientation = 1.0f;
        public float Control = 1.0f;


        void Start()
        {
            CurrentConfig = Config;
   
        }

        void Update()
        {
            if (CurrentConfig != Config)
            {
                CurrentConfig = Config;
            }
            Talking = Control != 1.0f;
            CharacterExpressionService.UpdateJaw_WithConfig(Config, JawIKRig_Target, Talking, CurrentOrientation, out CurrentOrientation, Time.timeSinceLevelLoad, Control);

        }


    }
}
