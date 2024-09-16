using UnityEngine;

namespace CharacterExpressions
{
    public class CharacterExpression_Eyes_Behaviour : MonoBehaviour
    {
        public GameObject EyeLids;
        private Material SharedMat;
        public CharacterExpression_Eyes_Textures Textures;
        private CharacterEyeExpressions CurrentCharacterExpression =
            CharacterEyeExpressions.Neutral;
        public CharacterEyeExpressions CharacterExpression = CharacterEyeExpressions.Neutral;

        public float Intensity = 1.0f;

        public int MaterialIndex = 1;
        private float Blink_TimeToWaitLifetime = 0.0f;
        private float Blink_Lifetime = 0.0f;
        private float[] Blink_TimesToWait = { 0.2f, 2.0f, 0.2f, 4.0f, 6.0f, 0.2f, 4.0f };
        private int Blink_TimeToWaitIndex = 0;
        private float Blink_speed = 4.0f;

        void Start()
        {
            CurrentCharacterExpression = CharacterExpression;
            if (SharedMat == null)
            {
                SharedMat = EyeLids.GetComponent<SkinnedMeshRenderer>().sharedMaterials[
                    MaterialIndex
                ];
            }
            if (SharedMat == null)
            {
                SharedMat = EyeLids.GetComponent<SkinnedMeshRenderer>().materials[MaterialIndex];
            }
            CharacterExpression_Services.UpdateCharacterExpression(
                CharacterExpression,
                SharedMat,
                Textures
            );
        }

        void Update()
        {
            if (SharedMat == null)
            {
                SharedMat = EyeLids.GetComponent<SkinnedMeshRenderer>().sharedMaterials[
                    MaterialIndex
                ];
            }
            if (SharedMat == null)
            {
                SharedMat = EyeLids.GetComponent<SkinnedMeshRenderer>().materials[MaterialIndex];
            }
            if (CurrentCharacterExpression != CharacterExpression)
            {
                CurrentCharacterExpression = CharacterExpression;
                CharacterExpression_Services.UpdateCharacterExpression(
                    CharacterExpression,
                    SharedMat,
                    Textures
                );
            }
            var shouldAnimateBlink = CharacterExpression_Services.Blink(
                Blink_Lifetime,
                out Blink_Lifetime,
                Blink_TimeToWaitLifetime,
                out Blink_TimeToWaitLifetime,
                Blink_TimeToWaitIndex,
                out Blink_TimeToWaitIndex,
                Blink_TimesToWait,
                Blink_speed
            );
            if (shouldAnimateBlink)
            {
                CharacterExpression_Services.UpdateEyeTextureOffset(
                    Blink_Lifetime,
                    Blink_speed,
                    SharedMat,
                    Textures
                );
            }
        }

        public void SetExpression(CharacterEyeExpressions expression)
        {
            CharacterExpression = expression;
        }
    }
}
