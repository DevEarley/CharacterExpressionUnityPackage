using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterExpressions
{
    [TrackColor(0.855f, 0.8623f, 0.87f)]
    [TrackClipType(typeof(CharacterExpression_Eyes_PlayableClip))]
    [TrackBindingType(typeof(SkinnedMeshRenderer))]
    public class CharacterExpression_Eyes_PlayableTrack : TrackAsset
    {
        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<CharacterExpression_Eyes_PlayableMixerBehaviour>.Create(graph, inputCount);
        }
    }
}
