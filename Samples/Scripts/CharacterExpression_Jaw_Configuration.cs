using UnityEngine;

[CreateAssetMenu(fileName = "Jaw Configuration", menuName = "Adroit Expressions/Jaw Configuration", order = 2)]

public class CharacterExpression_Jaw_Configuration : ScriptableObject {
    public Vector2 ValueClamp = new Vector2(0.0f, 1.0f);
    public float Offset = 0.0f;
    public float Frequency = 1.0f;
    public float Amplitude = 1.0f;
    public float Offset2 = 0.0f;
    public float Amplitude2 = 2.0f;
    public float Frequency2 = 1.5f;
    public Vector2 JawRange = new Vector2(0.0f, 9.0f);

    public enum CharacterExpression_Jaw_Configuration_Axis
    {
        Unselected = 0,
        X,
        Y, 
        Z
    }

    public enum CharacterExpression_Jaw_Configuration_Mode
    {
        Unselected =  0,
        Translate,
        Rotate
    }

    public CharacterExpression_Jaw_Configuration_Axis Axis  = CharacterExpression_Jaw_Configuration_Axis.Z;
    public CharacterExpression_Jaw_Configuration_Mode Mode = CharacterExpression_Jaw_Configuration_Mode.Unselected;


}
