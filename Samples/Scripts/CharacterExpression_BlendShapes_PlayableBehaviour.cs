using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace CharacterExpressions
{
    [Serializable]
    public class CharacterExpression_BlendShapes_PlayableBehaviour : PlayableBehaviour
    {

        public CharacterExpression_BlendShapes_Configuration Config;
        private List<Tuple<string, int>> namedIndexes = null;

        public override void OnGraphStart(Playable playable)
        {
            base.OnGraphStart(playable);
        }

        public void ProcessBlendShapes(SkinnedMeshRenderer skinnedMesh, float time, float weight)
        {
            if (Config == null || skinnedMesh == null) return;
            if(namedIndexes == null)
            {
                namedIndexes= CharacterExpression_Services.GetNamedIndexesFromBlendShapes(skinnedMesh);
            }
            var stopTalking = weight != 1.0f;
            CharacterExpression_Services.UpdateBlendShapeForSkinnedMesh(skinnedMesh, Config.emotion,Config.Intensity, weight, namedIndexes);
        }

        


    }
}