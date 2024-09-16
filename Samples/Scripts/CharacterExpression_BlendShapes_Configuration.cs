using UnityEngine;

[CreateAssetMenu(fileName = "BlendShapes Configuration", menuName = "Adroit Expressions/BlendShapes Configuration", order = 2)]

public class CharacterExpression_BlendShapes_Configuration : ScriptableObject {
    public float Intensity = 100.0f;
    public CharacterExpression_BlendShapes_Emotion emotion = CharacterExpression_BlendShapes_Emotion.Unselected;
    public enum CharacterExpression_BlendShapes_Emotion
    {
        Unselected = 0,
        Happy,
        Serious,
        Sad,
        Suprised,
        Angry,
        Neutral,
    }
}
