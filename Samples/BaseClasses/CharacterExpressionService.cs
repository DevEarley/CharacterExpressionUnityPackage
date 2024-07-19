using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterExpressions
{
    public static class CharacterExpressionService
    {
        // private const string TextureNameInShader_Base = "_BaseMap"; // is different from shader to shader. URP/Lit uses "_BaseMap"
         private const string TextureNameInShader_Base = "_MainTex"; 
        private const string TextureNameInShader_Emission = "_EmissionMap";

        public static void UpdateTalkingVariablesBasedOnPreset(
            CharacterExpression_Jaw_TalkingPresets TalkingPreset,
            out float Intensity,
            out float Variability,
            out float VariabilitySpeed,
            out float Speed)
        {
            switch (TalkingPreset)
            {
                default:
               
                case CharacterExpression_Jaw_TalkingPresets.Chatty1:
                    Intensity = 0.16f;
                    Variability = 3.2f;
                    VariabilitySpeed = 0.64f;
                    Speed = 2.97f;
                    break;
                case CharacterExpression_Jaw_TalkingPresets.Chatty2:
                    Intensity = 0.16f;
                    Variability = 2.2f;
                    VariabilitySpeed = 0.64f;
                    Speed = 2.97f;
                    break;
                case CharacterExpression_Jaw_TalkingPresets.LessFrequentChat:
                    Intensity = 0.37f;
                    Variability = 2.15f;
                    VariabilitySpeed = 1.49f;
                    Speed = 0.5f;
                    break;
            }
        }

        public static void UpdateJaw(GameObject _JawBone,
            bool _stopTalking,
            float _Intensity_Scale_IN,
            float _Previous_Scale_IN,
            float _Orientation_IN,
            float _Variability_Scale,
            Vector2 _Range,
            float _Variability,
            float _VariabilitySpeed,
            float _Speed,
            float _VariabilitySpeed_Scale,
            float _Speed_Scale,
            float _Intensity,
            out float _Intensity_Scale,
            out float _Previous_Scale,
            out float _Orientation)
        {
            if (_stopTalking == true && _Intensity_Scale_IN > 0.0f)
            {
                _Previous_Scale = _Intensity_Scale_IN;
                _Intensity_Scale = 0.0f;
                _Orientation = CloseJaw(_Orientation_IN, _Range.x, _Speed);
            }
            else if (_stopTalking == false)
            {
                _Intensity_Scale = _Previous_Scale_IN;
                _Previous_Scale = _Previous_Scale_IN;
                _Orientation = 
                    CharacterExpressionService.MoveJawUpAndDown(_VariabilitySpeed,
                        _VariabilitySpeed_Scale,
                        _Variability,
                        _Variability_Scale,
                        _Speed,
                        _Speed_Scale,
                        _Intensity,
                        _Previous_Scale,
                        _Range);
            }
            else 
            { 
                _Intensity_Scale = _Intensity_Scale_IN;
                _Previous_Scale = _Previous_Scale_IN;
                _Orientation = _Orientation_IN;
            }
            RotateJawBone(_JawBone, _Orientation);
        }

        public static void ResetBlink(out float Blink_lifetime, out float Blink_TimeToWaitLifetime)
        {
            Blink_lifetime = 0.0f;
            Blink_TimeToWaitLifetime = 0.0f;
        }

        public static bool Blink(
            float Blink_Lifetime_IN,
            out float Blink_Lifetime,
            float Blink_TimeToWaitLifetime_IN,
            out float Blink_TimeToWaitLifetime,
            int Blink_TimeToWaitIndex_IN,
            out int Blink_TimeToWaitIndex,
            float[] Blink_TimesToWait,
            float speed)

        {
            if (Blink_Lifetime_IN == 0.0f) // waiting to blink
            {
                Blink_TimeToWaitLifetime_IN = Blink_TimeToWaitLifetime_IN + Time.deltaTime; 
                if (Blink_TimeToWaitLifetime_IN > Blink_TimesToWait[Blink_TimeToWaitIndex_IN]) // ready to blink
                {
                    //iterate index
                    Blink_TimeToWaitIndex = Blink_TimeToWaitIndex_IN;
                    Blink_TimeToWaitIndex++;
                    if (Blink_TimeToWaitIndex > Blink_TimesToWait.Length - 1) Blink_TimeToWaitIndex = 0;

                    Blink_TimeToWaitLifetime = 0.0f;
                    //start blink
                    Blink_Lifetime = 0.0f;
                    Blink_Lifetime += Time.deltaTime;
                }
                else // still waiting to blink
                {
                    Blink_Lifetime = Blink_Lifetime_IN;
                    Blink_TimeToWaitIndex = Blink_TimeToWaitIndex_IN;
                    Blink_TimeToWaitLifetime = Blink_TimeToWaitLifetime_IN;
                    return false;
                }
            }
            else // in the process of blinking
            {
                Blink_TimeToWaitLifetime = Blink_TimeToWaitLifetime_IN;
                Blink_TimeToWaitIndex = Blink_TimeToWaitIndex_IN;
                Blink_Lifetime = Blink_Lifetime_IN;
                Blink_Lifetime += Time.deltaTime;
            }

            if (Blink_Lifetime > 1.0 / speed) // blink is over
            {
                //start waiting for next blink & show starting frame
                Blink_Lifetime = 0.0f;
            }

            return true;
        }

        public static void UpdateCharacterExpression(CharacterEyeExpressions CharacterExpression, Material EyelidMat, CharacterExpression_Eyes_Textures EyelidTextures)
        {
            switch (CharacterExpression)
            {
                case CharacterEyeExpressions.Angry:
                    EyelidMat.SetTexture(TextureNameInShader_Base, EyelidTextures.Angry);
                    EyelidMat.SetTexture(TextureNameInShader_Emission, EyelidTextures.Angry_Emission);
                    break;
                case CharacterEyeExpressions.Sleeping:
                    EyelidMat.SetTexture(TextureNameInShader_Base, EyelidTextures.Sleeping);
                    EyelidMat.SetTexture(TextureNameInShader_Emission, EyelidTextures.Sleeping_Emission);
                    break;
                case CharacterEyeExpressions.Sad:
                    EyelidMat.SetTexture(TextureNameInShader_Base, EyelidTextures.Sad);
                    EyelidMat.SetTexture(TextureNameInShader_Emission, EyelidTextures.Sad_Emission);
                    break;
                case CharacterEyeExpressions.Happy:
                    EyelidMat.SetTexture(TextureNameInShader_Base, EyelidTextures.Happy);
                    EyelidMat.SetTexture(TextureNameInShader_Emission, EyelidTextures.Happy_Emission);
                    break;
                case CharacterEyeExpressions.Confused:
                    EyelidMat.SetTexture(TextureNameInShader_Base, EyelidTextures.Confused);
                    EyelidMat.SetTexture(TextureNameInShader_Emission, EyelidTextures.Confused_Emission);
                    break;
                default:
                case CharacterEyeExpressions.Neutral:
                    EyelidMat.SetTexture(TextureNameInShader_Base, EyelidTextures.Neutral);
                    EyelidMat.SetTexture(TextureNameInShader_Emission, EyelidTextures.Neutral_Emission);
                    break;
            }
        }

        private static void RotateJawBone(GameObject _JawBone, float _Orientation)
        {
            _JawBone.transform.localEulerAngles = new Vector3(_Orientation, 0, 0);
        }

        private static float CloseJaw(float _CurrentOrientation, float _IdleOffset, float _Speed)
        {
            //Debug.Log("CloseJaw");
            var _Orientation = Mathf.Lerp(_CurrentOrientation, _IdleOffset, Time.deltaTime * _Speed);
            return _Orientation;
        }

        private static float MoveJawUpAndDown(
            float _VariabilitySpeed,
            float _VariabilitySpeed_Scale,
            float _Variability,
            float _Variability_Scale,
            float _Speed,
            float _Speed_Scale,
            float _Intensity,
            float _Intensity_Scale,
            Vector2 _Range)
        {
            var _VariabilityOffset = Mathf.Cos(Time.time * _VariabilitySpeed * _VariabilitySpeed_Scale) * _Variability * _Variability_Scale;
            var unclampedOffset = Mathf.Sin(Time.time * _Speed * _Speed_Scale) * ((_Intensity * _Intensity_Scale) + _VariabilityOffset);
            var _Orientation = Mathf.Clamp(unclampedOffset, _Range.x, _Range.y);
            return _Orientation;
        }

        public static void UpdateEyeTextureOffset(float Blink_Lifetime,float speed,Material EyelidMat)
        {
            var numberOfFrames = 4.0f;
            var offsetUnit = 1.0f / numberOfFrames;
            var adjustedTime = Blink_Lifetime * speed;
            var atInt = Mathf.Floor(adjustedTime);
            var dofAT = adjustedTime - atInt;
            var dofATx10 = dofAT * 10.0f;
            var modOfdofATx10 = dofATx10 % (offsetUnit * 10.0f);
            var cleanDofATx10 = dofATx10 - modOfdofATx10;
            var roundedDecimalOffset = cleanDofATx10 / 10.0f;
            var offset = new Vector2(roundedDecimalOffset, 0.0f);
            EyelidMat.SetTextureOffset(TextureNameInShader_Base, offset);
            EyelidMat.SetTextureOffset(TextureNameInShader_Emission, offset);
        }      
    }
}
