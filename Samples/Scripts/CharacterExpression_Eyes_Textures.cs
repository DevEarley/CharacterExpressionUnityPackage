using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharacterExpressions
{
    public class CharacterExpression_Eyes_Textures : MonoBehaviour
    {
        public string BaseTexture_NameInShader = "_BaseMap"; // Default for URP lit shader
        public string EmissionTexture_NameInShader = "_EmissionMap";
        public string DetailMaskTexture_NameInShader = "_DetailMask";
        public Texture2D Angry_Emission;
        public Texture2D Angry_Mask;
        public Texture2D Angry;
        public Texture2D Confused_Emission;
        public Texture2D Confused_Mask;
        public Texture2D Confused;
        public Texture2D Happy_Emission;
        public Texture2D Happy_Mask;
        public Texture2D Happy;
        public Texture2D Neutral_Emission;
        public Texture2D Neutral_Mask;
        public Texture2D Neutral;
        public Texture2D Sad_Emission;
        public Texture2D Sad_Mask;
        public Texture2D Sad;
        public Texture2D Sleeping_Emission;
        public Texture2D Sleeping_Mask;
        public Texture2D Sleeping;

    }
}
