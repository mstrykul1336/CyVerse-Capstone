using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LivelyWindows
{

	public static class CanvasExt
	{
		// the lossy scale is not in pixels if using screen space canvas
		public static Vector3 CorrectLossyScale(this Canvas canvas)
		{
			if (!Application.isPlaying)
				return Vector3.one;

			if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
			{
				var scaler = canvas.GetComponent<CanvasScaler>();
				if (scaler && scaler.enabled)
				{
					scaler.enabled = false;
					var before = canvas.GetComponent<RectTransform>().lossyScale;
					scaler.enabled = true;
					var after = canvas.GetComponent<RectTransform>().lossyScale;
					return new Vector3(after.x / before.x, after.y / before.y, after.z / before.z);
				}
				return Vector3.one;
			}

			return canvas.GetComponent<RectTransform>().lossyScale;
		}
	}

	public static class RectTransformExt
	{
		public static void GetLocalCorners(this RectTransform rt, Vector3[] fourCornersArray, Canvas canvas, float inset)
		{
			rt.GetLocalCorners(fourCornersArray);
			if (inset != 0)
			{
				var uis = canvas.CorrectLossyScale();
				fourCornersArray[0].x += inset * uis.x; fourCornersArray[0].y += inset * uis.y;
				fourCornersArray[1].x += inset * uis.x; fourCornersArray[1].y -= inset * uis.y;
				fourCornersArray[2].x -= inset * uis.x; fourCornersArray[2].y -= inset * uis.y;
				fourCornersArray[3].x -= inset * uis.x; fourCornersArray[3].y += inset * uis.y;
			}
		}

		public static void GetScreenCorners(this RectTransform rt, Vector3[] fourCornersArray, Canvas canvas, float inset)
		{
			// if screen space overlay mode then world corners are already in screen space
			// if screen space camera mode then screen settings are in world and need to be converted to screen
			rt.GetWorldCorners(fourCornersArray);
			if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
				for (int i = 0; i < 4; i++)
				{
					fourCornersArray[i] = canvas.worldCamera.WorldToScreenPoint(fourCornersArray[i]);
					fourCornersArray[i].z = 0;
				}
			if (inset != 0)
			{
				var uis = canvas.CorrectLossyScale();
				fourCornersArray[0].x += inset * uis.x; fourCornersArray[0].y += inset * uis.y;
				fourCornersArray[1].x += inset * uis.x; fourCornersArray[1].y -= inset * uis.y;
				fourCornersArray[2].x -= inset * uis.x; fourCornersArray[2].y -= inset * uis.y;
				fourCornersArray[3].x -= inset * uis.x; fourCornersArray[3].y += inset * uis.y;
			}
		}
	}
}