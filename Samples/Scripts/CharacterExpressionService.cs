using UnityEngine;
using static CharacterExpression_Jaw_Configuration;

namespace CharacterExpressions
{
    [System.Serializable]
    public enum CharacterEyeExpressions
    {
        Neutral,
        Happy,
        Sad,
        Angry,
        Confused,
        Sleeping
    }

    public static class CharacterExpressionService
    {

        public static void UpdateJaw_WithConfig(CharacterExpression_Jaw_Configuration Config,
        GameObject _JawIKRig_Target,
        bool _stopTalking,

        float Current_Orientation_IN,

        out float Current_Orientation_OUT,
        float time,
        float control
        )
        {
            UpdateJaw(_JawIKRig_Target,
            _stopTalking,
            Current_Orientation_IN,
            Config.JawRange,
            Config.Amplitude2,
            Config.Frequency2,
            Config.Frequency,
            Config.Amplitude,
            out Current_Orientation_OUT,
            Config.Axis,
            Config.ValueClamp,
            time, control);
        }

        public static void UpdateJaw(
        GameObject _JawIKRig_Target,
        bool _stopTalking,
        float Current_Orientation_IN,
        Vector2 JawRange,
        float Amplitude2,
        float Frequency2,
        float Amplitude,
        float Frequency,

        out float Current_Orientation_OUT,
        CharacterExpression_Jaw_Configuration_Axis axis,
        Vector2 ValueClamp,
        float time,
        float control

        )
        {
            if (_stopTalking == true)
            {
                //Previous_Control_OUT = Control_IN;
                //Control_OUT = 0.0f;
                Current_Orientation_OUT = CloseJaw(Current_Orientation_IN, JawRange.x, control);
            }
            else
            {
                //Control_OUT = Previous_Control_IN;
                //Previous_Control_OUT = Previous_Control_IN;
                Current_Orientation_OUT =
                CharacterExpressionService.MoveJawUpAndDown(Frequency2,
                Amplitude2,
                Amplitude,
                Frequency,
                ValueClamp,
                JawRange,
                time);
            }
            //else
            //{
            //    Control_OUT = Control_IN;
            //    Previous_Control_OUT = Previous_Control_IN;
            //    Current_Orientation_OUT = Current_Orientation_IN;
            //}
            Rotate_JawIKRig_Target(_JawIKRig_Target, Current_Orientation_OUT, axis);
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
                    EyelidMat.SetTexture(EyelidTextures.BaseTexture_NameInShader, EyelidTextures.Angry);
                    EyelidMat.SetTexture(EyelidTextures.EmissionTexture_NameInShader, EyelidTextures.Angry_Emission);
                    EyelidMat.SetTexture(EyelidTextures.DetailMaskTexture_NameInShader, EyelidTextures.Angry_Mask);
                    break;
                case CharacterEyeExpressions.Sleeping:
                    EyelidMat.SetTexture(EyelidTextures.BaseTexture_NameInShader, EyelidTextures.Sleeping);
                    EyelidMat.SetTexture(EyelidTextures.EmissionTexture_NameInShader, EyelidTextures.Sleeping_Emission);
                    EyelidMat.SetTexture(EyelidTextures.DetailMaskTexture_NameInShader, EyelidTextures.Sleeping_Mask);
                    break;
                case CharacterEyeExpressions.Sad:
                    EyelidMat.SetTexture(EyelidTextures.BaseTexture_NameInShader, EyelidTextures.Sad);
                    EyelidMat.SetTexture(EyelidTextures.EmissionTexture_NameInShader, EyelidTextures.Sad_Emission);
                    EyelidMat.SetTexture(EyelidTextures.DetailMaskTexture_NameInShader, EyelidTextures.Sad_Mask);
                    break;
                case CharacterEyeExpressions.Happy:
                    EyelidMat.SetTexture(EyelidTextures.BaseTexture_NameInShader, EyelidTextures.Happy);
                    EyelidMat.SetTexture(EyelidTextures.EmissionTexture_NameInShader, EyelidTextures.Happy_Emission);
                    EyelidMat.SetTexture(EyelidTextures.DetailMaskTexture_NameInShader, EyelidTextures.Happy_Mask);
                    break;
                case CharacterEyeExpressions.Confused:
                    EyelidMat.SetTexture(EyelidTextures.BaseTexture_NameInShader, EyelidTextures.Confused);
                    EyelidMat.SetTexture(EyelidTextures.EmissionTexture_NameInShader, EyelidTextures.Confused_Emission);
                    EyelidMat.SetTexture(EyelidTextures.DetailMaskTexture_NameInShader, EyelidTextures.Confused_Mask);
                    break;
                default:
                case CharacterEyeExpressions.Neutral:
                    EyelidMat.SetTexture(EyelidTextures.BaseTexture_NameInShader, EyelidTextures.Neutral);
                    EyelidMat.SetTexture(EyelidTextures.EmissionTexture_NameInShader, EyelidTextures.Neutral_Emission);
                    EyelidMat.SetTexture(EyelidTextures.DetailMaskTexture_NameInShader, EyelidTextures.Neutral_Mask);
                    break;
            }
        }

        public static void Rotate_JawIKRig_Target(GameObject _JawIKRig_Target, float _Orientation, CharacterExpression_Jaw_Configuration_Axis axis)
        {
            switch (axis)
            {
                case CharacterExpression_Jaw_Configuration_Axis.Unselected:
                    break;
                case CharacterExpression_Jaw_Configuration_Axis.X:
                    _JawIKRig_Target.transform.localEulerAngles = new Vector3(_Orientation, 0, 0);

                    break;
                case CharacterExpression_Jaw_Configuration_Axis.Y:
                    _JawIKRig_Target.transform.localEulerAngles = new Vector3(0, _Orientation, 0);
                    break;

                case CharacterExpression_Jaw_Configuration_Axis.Z:
                    _JawIKRig_Target.transform.localEulerAngles = new Vector3(0, 0, _Orientation);
                    break;
            }
        }

        public static float CloseJaw(float _CurrentOrientation, float _IdleOffset, float control)
        {
            var _Orientation = Mathf.Lerp(_CurrentOrientation, _IdleOffset, control);
            return _Orientation;
        }

        private static float MoveJawUpAndDown(
        float Frequency2,
        float Amplitude2,
        float Frequency,
        float Amplitude1,
        Vector2 ClampValues,
        Vector2 JawRange, float time)
        {

            //todo replace time with clip time
            var wave1 = Mathf.Sin(time * Frequency) * Amplitude1;
            var wave2 = Mathf.Cos(time * Frequency2) * Amplitude2;
            var unclamped = wave2 + wave1;
            var clamped = Mathf.Clamp(unclamped, ClampValues.x, ClampValues.y);
            var normalized = Normalize(ClampValues.x, ClampValues.y, clamped);
            var range = JawRange.y - JawRange.x;
            return JawRange.x + (normalized * range);
        }

        private static float Normalize(float r1, float r2, float v)
        {
            var range = r2 - r1;
            if (range == 0) return v;
            return v / range;
        }
        public static void UpdateEyeTextureOffset(float Blink_Lifetime, float speed, Material EyelidMat, CharacterExpression_Eyes_Textures EyelidTextures)
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
            EyelidMat.SetTextureOffset(EyelidTextures.BaseTexture_NameInShader, offset);
            EyelidMat.SetTextureOffset(EyelidTextures.EmissionTexture_NameInShader, offset);
        }
    }
}
