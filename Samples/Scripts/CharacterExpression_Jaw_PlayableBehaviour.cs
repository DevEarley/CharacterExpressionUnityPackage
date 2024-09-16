using System;
using UnityEngine;
using UnityEngine.Playables;
using static CharacterExpression_Jaw_Configuration;

namespace CharacterExpressions
{
    [Serializable]
    public class CharacterExpression_Jaw_PlayableBehaviour : PlayableBehaviour
    {

        public CharacterExpression_Jaw_Configuration Config;
        private float CurrentOrientation = 1.0f;


        public override void OnGraphStart(Playable playable)
        {
            base.OnGraphStart(playable);
        }

        public void ProcessTalking( GameObject JawIKRig_Target, float time, float weight) 
        {
            if (Config == null || JawIKRig_Target == null) return;
            var stopTalking = weight!=1.0f;
            CharacterExpressionService.UpdateJaw_WithConfig(Config, JawIKRig_Target, stopTalking,  CurrentOrientation,  out CurrentOrientation, time, weight);
        }


   
    }
}