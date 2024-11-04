using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterExpressions
{
    [TrackColor(0.855f, 0.7623f, 0.47f)]
    [TrackClipType(typeof(CharacterExpression_Jaw_PlayableClip))]
    [TrackBindingType(typeof(GameObject))]
    public class CharacterExpression_Jaw_PlayableTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<CharacterExpression_Jaw_PlayableMixerBehaviour>.Create (graph, inputCount);
        }
    }
}
