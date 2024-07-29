using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
namespace CharacterExpressions
{


    [Serializable]
    public class CharacterExpression_Jaw_PlayableClip : PlayableAsset, ITimelineClipAsset
    {
        public CharacterExpression_Jaw_TalkingPresets talkingPreset;
        public Vector2 Range = new Vector2(0.0f, 9.0f);

        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CharacterExpression_Jaw_PlayableBehaviour>.Create(graph);
            CharacterExpression_Jaw_PlayableBehaviour playableBehaviour = playable.GetBehaviour();
            playableBehaviour.Range = Range;
            playableBehaviour.talkingPreset = talkingPreset;
            return playable;
        }
    }
}