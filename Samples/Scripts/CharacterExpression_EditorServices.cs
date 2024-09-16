using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static CharacterExpression_Jaw_Configuration;

public static class CharacterExpression_EditorServices
{
    public static void OnInspectorGUI_Blink_Config(CharacterExpression_Blink_Configuration config)
    {
        EditorGUILayout.Space();
        OnInspectorGUI_Blink_ValueClamps(config);
        config.Amplitude1 = EditorGUILayout.FloatField("Amplitude 1", config.Amplitude1);
        config.Frequency1 = EditorGUILayout.FloatField("Frequency 1", config.Frequency1);
        config.Amplitude2 = EditorGUILayout.FloatField("Amplitude 2", config.Amplitude2);
        config.Frequency2 = EditorGUILayout.FloatField("Frequency 2", config.Frequency2);
        config.Amplitude3 = EditorGUILayout.FloatField("Amplitude 3", config.Amplitude3);
        config.Frequency3 = EditorGUILayout.FloatField("Frequency 3", config.Frequency3);
        config.Offset3 = EditorGUILayout.FloatField("Offset 3", config.Offset3);
    
        var wave_1_color = new Color(0.20f, 0.20f, 0.20f);
        var wave_2_color = new Color(0.3f, 0.3f, 0.3f);
        var interference_color = new Color(0.20f, 0.20f, 0.20f);
        var clamped_color = new Color(0.86f, 0.46f, 0.26f);
        var box = new Rect((EditorGUIUtility.currentViewWidth / 2.0f) - 100, 400, 200, 200);
        Graph_DrawBackground(box);
        BlinkGraph_DrawCurves(config, wave_1_color, wave_2_color, interference_color, clamped_color, box);
    }


    public static void OnInspectorGUI_Jaw_Config(CharacterExpression_Jaw_Configuration config)
    {
        EditorGUILayout.Space();
        config.Mode = (CharacterExpression_Jaw_Configuration_Mode)EditorGUILayout.EnumPopup("Mode", config.Mode);
        OnInspectorGUI_Jaw_ValueClamps(config);
        config.Axis = (CharacterExpression_Jaw_Configuration_Axis)EditorGUILayout.EnumPopup("Axis", config.Axis);
        config.Amplitude = EditorGUILayout.FloatField("Amplitude 1", config.Amplitude);
        config.Frequency = EditorGUILayout.FloatField("Frequency 1", config.Frequency);
        config.Amplitude2 = EditorGUILayout.FloatField("Amplitude 2", config.Amplitude2);
        config.Frequency2 = EditorGUILayout.FloatField("Frequency 2", config.Frequency2);
        OnInspectorGUI_JawRange(config);
        var wave_1_color = new Color(0.20f, 0.20f, 0.20f);
        var wave_2_color = new Color(0.3f, 0.3f, 0.3f);
        var interference_color = new Color(0.20f, 0.20f, 0.20f);
        var clamped_color = new Color(0.86f, 0.46f, 0.26f);
        var box = new Rect((EditorGUIUtility.currentViewWidth / 2.0f) - 100, 400, 200, 200);
        Graph_DrawBackground(box);
        JawGraph_DrawCurves(config, wave_1_color, wave_2_color, interference_color, clamped_color, box);
    }

    private static void OnInspectorGUI_Jaw_ValueClamps(CharacterExpression_Jaw_Configuration config)
    {
        EditorGUILayout.LabelField("Value Clamps");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Min", GUILayout.MaxWidth(40));
        config.ValueClamp.x = EditorGUILayout.FloatField(config.ValueClamp.x);
        EditorGUILayout.MinMaxSlider(ref config.ValueClamp.x, ref config.ValueClamp.y, -5.0f, 5.0f);
        config.ValueClamp.y = EditorGUILayout.FloatField(config.ValueClamp.y);
        EditorGUILayout.LabelField("Max", GUILayout.MaxWidth(40));
        if (config.ValueClamp.x > config.ValueClamp.y)
        {
            config.ValueClamp.y = config.ValueClamp.x + 1.0f;
        }
        EditorGUILayout.EndHorizontal();
    }
    private static void OnInspectorGUI_Blink_ValueClamps(CharacterExpression_Blink_Configuration config)
    {
        EditorGUILayout.LabelField("Value Clamps");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Min", GUILayout.MaxWidth(40));
        config.ValueClamp.x = EditorGUILayout.FloatField(config.ValueClamp.x);
        EditorGUILayout.MinMaxSlider(ref config.ValueClamp.x, ref config.ValueClamp.y, -5.0f, 5.0f);
        config.ValueClamp.y = EditorGUILayout.FloatField(config.ValueClamp.y);
        EditorGUILayout.LabelField("Max", GUILayout.MaxWidth(40));
        if (config.ValueClamp.x > config.ValueClamp.y)
        {
            config.ValueClamp.y = config.ValueClamp.x + 1.0f;
        }
        EditorGUILayout.EndHorizontal();
    }

    private static void OnInspectorGUI_JawRange(CharacterExpression_Jaw_Configuration config)
    {
        EditorGUILayout.LabelField("Jaw Range");
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Closed ", GUILayout.MaxWidth(40));
        config.JawRange.x = EditorGUILayout.FloatField(config.JawRange.x);
        EditorGUILayout.MinMaxSlider(ref config.JawRange.x, ref config.JawRange.y, -90.0f, 90.0f);
        config.JawRange.y = EditorGUILayout.FloatField(config.JawRange.y);
        EditorGUILayout.LabelField("Open", GUILayout.MaxWidth(40));
        if (config.JawRange.x > config.JawRange.y)
        {
            config.JawRange.y = config.JawRange.x + 1.0f;
        }
        EditorGUILayout.EndHorizontal();
    }

    private static void JawGraph_DrawCurves(CharacterExpression_Jaw_Configuration config, Color wave_1_color, Color wave_2_color, Color interference_color, Color clamped_color, Rect box)
    {
        var graph_zero_offset = new Vector2(0, 200);
        var resolution = 0.05f;
        var scale = box.width / 4.0f;

        //unclamped
        Handles.color = interference_color;
        for (var x = 0.0f; x < 4.0f; x += resolution)
        {
            var point1 = new Vector2(x, -CosOfX(config, x) + -SinOfX(config, x));
            var point2 = new Vector2(x + resolution, -CosOfX(config, x + resolution) - SinOfX(config, x + resolution));
            Handles.DrawLine((point1 * scale) + box.position + graph_zero_offset, (point2 * scale) + box.position + graph_zero_offset);
        }

        Handles.color = wave_1_color;
        //wave1
        for (var x = 0.0f; x < 4.0f; x += resolution)
        {
            var point1 = new Vector2(x, -SinOfX(config, x));
            var point2 = new Vector2(x + resolution, -SinOfX(config, x + resolution));
            Handles.DrawLine((point1 * scale) + box.position + graph_zero_offset, (point2 * scale) + box.position + graph_zero_offset);
        }

        //wave2
        Handles.color = wave_2_color;
        for (var x = 0.0f; x < 4.0f; x += resolution)
        {
            var point1 = new Vector2(x, -CosOfX(config, x));
            var point2 = new Vector2(x + resolution, -CosOfX(config, x + resolution));
            Handles.DrawLine((point1 * scale) + box.position + graph_zero_offset, (point2 * scale) + box.position + graph_zero_offset);
        }

        //clamped
        Handles.color = clamped_color;

        for (var x = 0.0f; x < 4.0f; x += resolution)
        {
            var point1 = new Vector2(x, -CosOfX(config, x) - SinOfX(config, x));
            var point2 = new Vector2(x + resolution, -CosOfX(config, x + resolution) - SinOfX(config, x + resolution));
            var clamped_point1 = new Vector2(point1.x, -Mathf.Clamp(-point1.y, config.ValueClamp.x, config.ValueClamp.y));
            var clamped_point2 = new Vector2(point2.x, -Mathf.Clamp(-point2.y, config.ValueClamp.x, config.ValueClamp.y));
            var offset_point1 = (clamped_point1 * scale) + box.position + graph_zero_offset;
            var offset_point2 = (clamped_point2 * scale) + box.position + graph_zero_offset;
            Handles.DrawLine(offset_point1, offset_point2);
        }
    }

    private static void BlinkGraph_DrawCurves(CharacterExpression_Blink_Configuration config, Color wave_1_color, Color wave_2_color, Color interference_color, Color clamped_color, Rect box)
    {
        var graph_zero_offset = new Vector2(0, 200);
        var resolution = 0.05f;
        var scale = box.width / 4.0f;

       
        //clamped
        Handles.color = clamped_color;

        for (var x = 0.0f; x < 4.0f; x += resolution)
        {
            var value1 = -CosOfX3(config.Frequency3, config.Amplitude3, config.Offset3, x) - CosOfX2(config.Frequency2, config.Amplitude2, x) - SinOfX1(config.Frequency1, config.Amplitude1, x);
            var value2 = -CosOfX3(config.Frequency3, config.Amplitude3, config.Offset3, x+resolution) - CosOfX2(config.Frequency2, config.Amplitude2, x+resolution) - SinOfX1(config.Frequency1, config.Amplitude1, x + resolution);
            var point1 = new Vector2(x,value1);
            var point2 = new Vector2(x + resolution, value2);
            var clamped_point1 = new Vector2(point1.x, -Mathf.Clamp(-point1.y, config.ValueClamp.x, config.ValueClamp.y));
            var clamped_point2 = new Vector2(point2.x, -Mathf.Clamp(-point2.y, config.ValueClamp.x, config.ValueClamp.y));
            var offset_point1 = (clamped_point1 * scale) + box.position + graph_zero_offset;
            var offset_point2 = (clamped_point2 * scale) + box.position + graph_zero_offset;
            Handles.DrawLine(offset_point1, offset_point2);
        }
    }
    private static float CosOfX3(float Frequency3, float Amplitude3, float Offset3, float x)
    {
        return Mathf.Cos((x + Offset3) * Frequency3) * Amplitude3;
    }
    private static float CosOfX2(float Frequency2, float Amplitude2, float x)
    {
        return Mathf.Cos((x) * Frequency2) * Amplitude2;
    }
    private static float SinOfX1(float Frequency1, float Amplitude1, float x)
    {
        return Mathf.Sin((x) * Frequency1) * Amplitude1;
    }

    private static float CosOfX(CharacterExpression_Jaw_Configuration config, float x)
    {
        return Mathf.Cos(x * config.Frequency2) * config.Amplitude2;
    }

    private static float SinOfX(CharacterExpression_Jaw_Configuration config, float x)
    {
        return Mathf.Sin(x * config.Frequency) * config.Amplitude;
    }

    private static void Graph_DrawBackground(Rect box)
    {
        var color_dark_gray = new Color(0.16f, 0.16f, 0.16f);
        var color_gray = new Color(0.20f, 0.20f, 0.20f);
        var color_light_gray = new Color(0.26f, 0.26f, 0.26f);
        var color_bright_gray = new Color(0.66f, 0.66f, 0.66f);
        EditorGUI.DrawRect(box, color_dark_gray);

        //Vertical Lines
        EditorGUI.DrawRect(new Rect(box.x + 25, box.y, 1, box.height), color_gray);
        EditorGUI.DrawRect(new Rect(box.x + 50, box.y, 1, box.height), color_light_gray);
        EditorGUI.DrawRect(new Rect(box.x + 75, box.y, 1, box.height), color_gray);
        EditorGUI.DrawRect(new Rect(box.x + 100, box.y, 1, box.height), color_light_gray);
        EditorGUI.DrawRect(new Rect(box.x + 125, box.y, 1, box.height), color_gray);
        EditorGUI.DrawRect(new Rect(box.x + 150, box.y, 1, box.height), color_light_gray);
        EditorGUI.DrawRect(new Rect(box.x + 175, box.y, 1, box.height), color_gray);

        //Horizontal Lines

        EditorGUI.DrawRect(new Rect(box.x, box.y, box.width, 2), color_light_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y + 25, box.width, 1), color_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y + 50, box.width, 1), color_light_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y + 75, box.width, 1), color_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y + 100, box.width, 1), color_light_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y + 125, box.width, 1), color_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y + 150, box.width, 1), color_light_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y + 175, box.width, 1), color_gray);

        //Origin Lines
        EditorGUI.DrawRect(new Rect(box.x, box.y + 200, box.width, 1), color_bright_gray);
        EditorGUI.DrawRect(new Rect(box.x, box.y, 2, box.height), color_bright_gray);

    }
}
