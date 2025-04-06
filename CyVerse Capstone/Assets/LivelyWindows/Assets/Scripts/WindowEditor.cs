using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace LivelyWindows
{
	[CustomEditor(typeof(Window))]
	[CanEditMultipleObjects]
	public class WindowEditor : Editor
	{

		new Window target { get { return base.target as Window; } }

		SerializedProperty PProperties;

		static Color FrameFillColor = new Color(0, 0, 0, 0);
		static Color FrameBorderColor = new Color(0.2f, 1, 0.2f);

		private void OnEnable()
		{
			PProperties = serializedObject.FindProperty("Properties");
		}

		public override void OnInspectorGUI()
		{
			serializedObject.Update();
			EditorGUILayout.PropertyField(PProperties, true);
			EditorGUILayout.Space();
			serializedObject.ApplyModifiedProperties();
			SceneView.RepaintAll();
		}

		private void OnSceneGUI()
		{
			Handles.matrix = target.transform.localToWorldMatrix;

			var corners = new Vector3[4];

			// outer rectangle
			target.RectTransform.GetLocalCorners(corners, target.Canvas, target.Properties.FrameOffset);
			Handles.DrawSolidRectangleWithOutline(corners, FrameFillColor, FrameBorderColor);

			// inner rectangle
			target.RectTransform.GetLocalCorners(corners, target.Canvas, target.Properties.FrameOffset + target.Properties.FrameThickness);
			if (target.Properties.FrameThickness > 0)
				Handles.DrawSolidRectangleWithOutline(corners, FrameFillColor, FrameBorderColor);

			// caption
			if (target.Properties.CaptionHeight > 0)
			{
				var scale = target.Canvas.CorrectLossyScale();
				corners[0].y = corners[1].y - target.Properties.CaptionHeight * scale.y;
				corners[3].y = corners[2].y - target.Properties.CaptionHeight * scale.y;
				Handles.DrawSolidRectangleWithOutline(corners, FrameFillColor, FrameBorderColor);
			}
		}
	}
}
