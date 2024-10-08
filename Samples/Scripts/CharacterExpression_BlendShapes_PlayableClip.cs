using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterExpressions
{

    [Serializable]
    public class CharacterExpression_BlendShapes_PlayableClip : PlayableAsset, ITimelineClipAsset
    {

        public CharacterExpression_BlendShapes_Configuration Config;
        public ClipCaps clipCaps
        {
            get { return ClipCaps.Blending; }
        }

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<CharacterExpression_BlendShapes_PlayableBehaviour>.Create(graph);
            CharacterExpression_BlendShapes_PlayableBehaviour playableBehaviour = playable.GetBehaviour();
            playableBehaviour.Config = Config;
            return playable;
        }
    }
}
