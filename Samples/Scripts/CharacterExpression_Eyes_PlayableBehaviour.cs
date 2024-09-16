using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterExpressions
{
    // This is attached to a GO?
    [Serializable]
    public class CharacterExpression_Eyes_PlayableBehaviour : PlayableBehaviour
    {
        public CharacterExpression_Eyes_Textures EyelidTextures;
        public CharacterEyeExpressions CharacterExpression = CharacterEyeExpressions.Neutral;

        //From Clip
        public Vector2 Range = Vector2.zero;
        public int MaterialIndex = 0;
        public Material EyelidMat;

        //State
        private float Blink_TimeToWaitLifetime = 0.0f;
        private float Blink_Lifetime = 0.0f;
        private float[] Blink_TimesToWait = { 0.2f, 2.0f, 4.0f, 6.0f, 0.2f, 4.0f };
        private int Blink_TimeToWaitIndex = 0;
        private float Blink_speed = 4.0f;

        public void Blink(SkinnedMeshRenderer mesh)
        {
            //Debug.Log("BLINK | START");

            if (EyelidMat == null)
            {
                EyelidMat = mesh.sharedMaterials[MaterialIndex];
                //Debug.Log("BLINK | ASSIGN EYELID MAT");
            }
            if (EyelidMat == null)
            {
                EyelidMat = mesh.materials[MaterialIndex];
                //Debug.Log("BLINK | ASSIGN EYELID MAT");
            }

            var shouldAnimateBlink = CharacterExpression_Services.Blink(Blink_Lifetime,
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
                CharacterExpression_Services.UpdateEyeTextureOffset(Blink_Lifetime, Blink_speed, EyelidMat, EyelidTextures);
            }
        }
    }
}
