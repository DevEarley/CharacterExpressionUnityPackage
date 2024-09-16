using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterExpressions
{
    [TrackColor(0.955f, 0.8623f, 0.57f)]
    
    [TrackClipType(typeof(CharacterExpression_Blink_PlayableClip))]
    [TrackBindingType(typeof(SkinnedMeshRenderer))]
    public class CharacterExpression_Blink_PlayableTrack : TrackAsset
    {
      

        public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
        {
            return ScriptPlayable<CharacterExpression_Blink_PlayableMixerBehaviour>.Create (graph, inputCount);
        }
    }
}
