#if UNITY_EDITOR
using Timeline.Samples;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace CharacterExpressions
{
    [CustomTimelineEditor(typeof(CharacterExpression_Jaw_PlayableClip))]
    public class CharacterExpression_Jaw_PlayableClip_Editor_InTrack : ClipEditor
    {

        public override void DrawBackground(TimelineClip clip, ClipBackgroundRegion region)
        {
            base.DrawBackground(clip, region);

            CharacterExpression_Jaw_PlayableClip jawClip = clip.asset as CharacterExpression_Jaw_PlayableClip;

            if (jawClip == null) return;
            var config = jawClip.jawConfig;
            if (config == null) return;

            var box = new Rect(region.position.x, region.position.y, region.position.width, region.position.height);

            Vector2 graph_zero_offset = new Vector2(0, box.height*0.5f);

            float end_delta = (float)region.endTime - (float)clip.start;
            float start_delta = (float)region.startTime - (float)clip.start;

            var denominator = (float)region.endTime - (float)region.startTime;
            var ratio = region.position.width / denominator;

            float scale_x = ratio ; // this is the problem
            float step = 0.03f;
            float scale_y =box.height/2.0f;

            float start = start_delta > 0.0f ? start_delta : 0.0f;

            float end = end_delta< scale_x ? scale_x : end_delta;

            //clamped
            Handles.color = CharacterExpression_EditorService.clamped_color;
            for (var x = start; x < end; x += step)
            {
                var point_1_x = x ;
                var point_1_y = -CharacterExpression_EditorService.CosOfX(config, x) - CharacterExpression_EditorService.SinOfX(config, x);
                var point1 = new Vector2(point_1_x, point_1_y);

                var point_2_x = (x + step);
                var point_2_y = (-CharacterExpression_EditorService.CosOfX(config, x + step) - CharacterExpression_EditorService.SinOfX(config, x + step));
                var point2 = new Vector2(point_2_x, point_2_y);

                var clamped_point1 = new Vector2(point1.x, -Mathf.Clamp(-point1.y, config.ValueClamp.x, config.ValueClamp.y));
                var clamped_point2 = new Vector2(point2.x, -Mathf.Clamp(-point2.y, config.ValueClamp.x, config.ValueClamp.y));

                clamped_point1.x *= scale_x;
                clamped_point1.y *= scale_y;
                clamped_point2.x *= scale_x;
                clamped_point2.y *= scale_y;

                var handlePoint_1 = (clamped_point1) + graph_zero_offset;
                var handlePoint_2 = (clamped_point2 ) + graph_zero_offset;
                Handles.DrawLine(handlePoint_1, handlePoint_2);
            }
        }
    }
}
#endif