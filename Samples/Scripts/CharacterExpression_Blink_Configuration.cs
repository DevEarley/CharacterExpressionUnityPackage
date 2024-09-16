using UnityEngine;

[CreateAssetMenu(fileName = "Blink Configuration", menuName = "Adroit Expressions/Blink Configuration", order = 2)]

public class CharacterExpression_Blink_Configuration : ScriptableObject {
    public float Intensity = 100.0f;
    public Vector2 ValueClamp = new Vector2(0.0f, 1.0f);


    public float Frequency1 = 1.0f;
    public float Amplitude1 = 1.0f;
    public float Amplitude2 = 2.0f;
    public float Frequency2 = 1.5f;
    public float Amplitude3 = 1.0f;
    public float Frequency3 = 0.5f;
    public float Offset3 = 0.5f;
}
