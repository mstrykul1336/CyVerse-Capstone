using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LivelyWindows
{
	[Serializable]
	public class CursorInfo
	{
		public string Name;
		public Texture2D Texture;
		public Vector2 Hotspot;

		public CursorInfo() { }
		public CursorInfo(string name)
		{
			Name = name;
			Hotspot = new Vector2(15, 15);
		}
	}

	[ExecuteInEditMode]
	public class Cursors : MonoBehaviour
	{
		public List<CursorInfo> Info;

		public static Cursors Instance { get; private set; }

		public void Awake()
		{
			if (Instance != null)
			{
				Debug.LogError("Multiple 'Cursors' classes found as the class is designed to act as a Singleton!");
			}
			else
			{
				Instance = this;
				EnsureCursorItem("Arrow");
				EnsureCursorItem("ResizeNS");
				EnsureCursorItem("ResizeWE");
				EnsureCursorItem("ResizeNWSE");
				EnsureCursorItem("ResizeNESW");
				EnsureCursorItem("Move");
			}
		}

		public CursorInfo Arrow { get { return Info[0]; } }
		public CursorInfo ResizeNS { get { return Info[1]; } }
		public CursorInfo ResizeWE { get { return Info[2]; } }
		public CursorInfo ResizeNWSE { get { return Info[3]; } }
		public CursorInfo ResizeNESW { get { return Info[4]; } }
		public CursorInfo Move { get { return Info[5]; } }

		void EnsureCursorItem(string name)
		{
			if (Info == null)
				Info = new List<CursorInfo>();
			if (!Info.Exists(d => d.Name == name))
				Info.Add(new CursorInfo(name));
		}

		public void SetCursor(CursorInfo info)
		{
			if (info.Texture)
				Cursor.SetCursor(info.Texture, info.Hotspot, CursorMode.Auto);
		}

	}
}