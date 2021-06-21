using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class ScreenShooter : MonoBehaviour 
{
	[Header("Viewport")]
	public int viewportWidth = 1920;
	public int viewportHeight = 1080;

	[Header("Settings")] 
	public AntialisingLevel antialisingLevel = AntialisingLevel.X8; 
	public enum AntialisingLevel { Disabled = 0, X2 = 2, X4 = 4, X8 = 8 }
	
	[Header("Output")]
	[Tooltip("Relative to project dir")]
	public string outDirectory = "Screenshots";
	public string fileNameMask = "screen";
	public enum ImageMime { Jpeg, Png }
	public ImageMime imageMime = ImageMime.Png;
	public TextureFormat textureFormat = TextureFormat.RGB24;

	[Header("Shoot")]
	public KeyCode editorKeyCode = KeyCode.F12;
	public bool shootNow = false;

	void OnValidate ()
	{
		if (shootNow)
		{
			shootNow = false;
			Shoot ();
		}
	}

	void Shoot ()
	{
		var rt = new RenderTexture(viewportWidth, viewportHeight, 16, RenderTextureFormat.Default, RenderTextureReadWrite.Default);

		rt.antiAliasing = (int) this.antialisingLevel;
		
		var cam = this.GetComponent<Camera>();

		cam.targetTexture = rt;
		cam.Render();

		RenderTexture.active = rt;

		var tex2d = new Texture2D(viewportWidth, viewportHeight, textureFormat, false);
		tex2d.ReadPixels(new Rect(0, 0, viewportWidth, viewportHeight), 0, 0);

		string ext;
		switch (imageMime)
		{
		case ImageMime.Jpeg: ext = "jpg"; break;
		case ImageMime.Png: ext = "png"; break;
		default:
			Debug.LogError ("Unknown MIME");
			return;
		}

		try {
			var filename = GetFilename(ext);

			switch (imageMime)
			{
			case ImageMime.Jpeg:
				System.IO.File.WriteAllBytes(filename, tex2d.EncodeToJPG());
				break;
			case ImageMime.Png:
				System.IO.File.WriteAllBytes(filename, tex2d.EncodeToPNG());
				break;
			}
			Debug.Log("Screenshot saved to:\n" + filename);
		}
		finally {
			RenderTexture.active = null;
			cam.targetTexture = null;
			MyDestroy(rt);
			MyDestroy(tex2d);
		}
	}

	void MyDestroy (Object obj)
	{
		if (Application.isPlaying)
			Destroy(obj);
		else
			DestroyImmediate(obj);
	}


	string GetFilename (string ext)
	{
		var projDir = System.IO.Directory.GetParent(Application.dataPath).FullName;
		var dir = System.IO.Path.Combine(projDir, outDirectory);
		if (!System.IO.Directory.Exists(dir))
			System.IO.Directory.CreateDirectory(dir);

		var fnSearch = string.Format("{0}*.{1}", fileNameMask, ext);
		int index = 0;
		{
			var files = System.IO.Directory.GetFiles(dir, fnSearch);
			if (files != null && files.Length > 0)
			{
				var hs = new System.Collections.Generic.HashSet<string>();
				foreach (var f in files)
					hs.Add(System.IO.Path.GetFileName(f));

				while (hs.Contains(string.Format("{0}{1:000}.{2}", fileNameMask, index, ext)))
					index++;
			}
		}
		var filename = string.Format("{0}{1:000}.{2}", fileNameMask, index, ext);
		return System.IO.Path.Combine(dir, filename);
	}
	
	void Update () 
	{
		#if UNITY_EDITOR
		if (Input.GetKeyDown(editorKeyCode))
			shootNow = true;
		#endif
		
		if (shootNow)
		{
			shootNow = false;
			Shoot ();
		}
	}
}

