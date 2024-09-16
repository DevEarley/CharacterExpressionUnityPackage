using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
namespace CharacterExpressions
{
    
    [Serializable]
    public class CharacterExpression_Jaw_PlayableClip : PlayableAsset, ITimelineClipAsset
    {

        public CharacterExpression_Jaw_Configuration jawConfig;


       
        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CharacterExpression_Jaw_PlayableBehaviour>.Create(graph);
            CharacterExpression_Jaw_PlayableBehaviour playableBehaviour = playable.GetBehaviour();
            playableBehaviour.Config = jawConfig;
            return playable;
        }
    }
}