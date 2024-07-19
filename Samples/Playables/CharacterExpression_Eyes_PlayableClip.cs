using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

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

    [Serializable]
    public class CharacterExpression_Eyes_PlayableClip : PlayableAsset, ITimelineClipAsset
    {
        public CharacterEyeExpressions expression;
        public int MaterialIndex = 1;
        public CharacterExpression_Eyes_Textures EyelidTextures;

        public ClipCaps clipCaps
        {
            get { return ClipCaps.None; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CharacterExpression_Eyes_PlayableBehaviour>.Create(graph);
            CharacterExpression_Eyes_PlayableBehaviour playableBehaviour = playable.GetBehaviour();
            playableBehaviour.MaterialIndex = MaterialIndex;
            playableBehaviour.CharacterExpression = expression;
            playableBehaviour.EyelidTextures = EyelidTextures;
            return playable;
        }
    }
}