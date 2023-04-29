using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace CameraFading
{
	/// <summary>
	/// Simple class to fade camera view to a color. Must be attached to camera.
	/// Author: Daniel Castaño Estrella (daniel.c.estrella@gmail.com)
	/// Based on this example: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnPostRender.html
	/// 
	/// INSTRUCTIONS
	/// Use namespace CameraFading (using CameraFading;)
	///	Call CameraFade.In or CameraFade.Out functions passing duration,from anywhere in your code.
	///	Set color with CameraFade.Color
	///	Set alpha manually with CameraFade.Alpha
	///	
	/// EXTRA
	/// Possibility to force restart Fade In and Fade Out functions when called.
	/// Possibility to force fixed duration when fades don't restart. By default fades use a fraction of duration if they start from middle-state-alpha.
	/// Possibility to pass callback functions or lambda functions. Example:
	/// 
	/// CameraFading.CameraFade.Out(() =>
	///	{
	///		Debug.Log("fade out finished");
	///	});
	///	
	/// </summary>
	public class CameraFade : MonoBehaviour
	{
		/// <summary>
		/// Static reference to instance
		/// </summary>
		public static CameraFade Instance { get; private set; }

		//public SpriteRenderer sprite { get; set; }

		/// <summary>
		/// Static reference to the color.
		/// Color to fade.
		/// It sets the color of the material used to do fades.
		/// </summary>
		public static Color Color
		{
			get { if (Instance == null) return Color.clear; return Instance.color; }
			set { if (Instance == null) return; Instance.color = new Color(value.r, value.g, value.b, Instance.alpha); Instance.image.color = Instance.color; }
		}

		public static float Alpha
		{
			get { if (Instance == null) return 0; return Instance.alpha; }
			set { if (Instance == null) return; if (Instance.alpha != value) { Instance.alpha = value; Instance.color.a = value; Instance.image.color = Instance.color; } }
		}
		public static Image ImageFade
		{
			get { Instance.image.enabled = true; return Instance.image; }
			set { Instance.image = value; }
		}

		//color of the fade
		[SerializeField] private Color color = new Color(0, 0, 0, 0);
		//current alpha value
		[SerializeField] private float alpha = 0;

		[SerializeField] private Image image;

		/// <summary>
		/// Set reference to instance
		/// </summary>
		void OnEnable()
		{
			Instance = this;
		}

		/// <summary>
		/// Set instance reference to null
		/// </summary>
		void OnDisable()
		{
			Instance = null;
		}

		/// <summary>
		/// Add a quad in front of camera to fade with color.
		/// </summary>
		public void OnPostRender()
		{
#if UNITY_EDITOR
			//To change fade color and alpha using inspector variables
			if (alpha != color.a)
			{
				color.a = alpha;
			}
#endif
		}

		/// <summary>
		/// Call this method to Fade In.
		/// </summary>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		public static void In(float duration = 1, bool restart = false, bool fixedDuration = false)
		{
			if (Instance == null) return;
			
			Instance.StopAllCoroutines();
			Instance.StartCoroutine(Instance.CameraFadeIn(duration, restart, fixedDuration));
		}

		/// <summary>
		/// Call this method to Fade In with a Callback Action.
		/// </summary>
		/// <param name="Callback">Method or lambda function to call after fade is finished.</param>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		public static void In(System.Action Callback, float duration = 1, bool restart = false, bool fixedDuration = false)
		{
			if (Instance == null) return;
			Instance.StopAllCoroutines();
			Instance.StartCoroutine(Instance.CameraFadeIn(Callback, duration, restart, fixedDuration));
		}

		/// <summary>
		/// Call this method to Fade Out.
		/// </summary>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		public static void Out(float duration = 1, bool restart = false, bool fixedDuration = false)
		{
			if (Instance == null) return;

			Instance.StopAllCoroutines();
			Instance.StartCoroutine(Instance.CameraFadeOut(duration, restart, fixedDuration));
		}

		/// <summary>
		/// Call this method to Fade Out with a Callback Action.
		/// </summary>
		/// <param name="Callback">Method or lambda function to call after fade is finished.</param>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		public static void Out(System.Action Callback, float duration = 1, bool restart = false, bool fixedDuration = false)
		{
			if (Instance == null) return;

			Instance.StopAllCoroutines();
			Instance.StartCoroutine(Instance.CameraFadeOut(Callback, duration, restart, fixedDuration));
		}

		/// <summary>
		/// Coroutine to Fade In.
		/// </summary>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		/// <returns></returns>
		private IEnumerator CameraFadeIn(float duration, bool restart, bool fixedDuration)
		{
			//Debug.Log("_______________________ init Fade In");
			//Debug.Log("init time: " + Time.time);

			if (restart) Alpha = 1;
			else if (fixedDuration) duration /= Alpha;

			for (float i = Alpha; (i - Time.deltaTime / duration) > 0; i -= Time.deltaTime / duration)
			{
				Alpha = i;
				yield return null;
			}
			//Debug.Log("time end: " + Time.time);

			Alpha = 0;
		}

		/// <summary>
		/// Coroutine to Fade In with a Callback
		/// </summary>
		/// <param name="Callback">Method or lambda function to call after fade is finished.</param>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		/// <returns></returns>
		private IEnumerator CameraFadeIn(System.Action Callback, float duration, bool restart, bool fixedDuration)
		{
			//Debug.Log("_______________________ init Fade In");
			//Debug.Log("init time: " + Time.time);

			if (restart) Alpha = 1;
			else if (fixedDuration) duration /= Alpha;

			for (float i = Alpha; (i - Time.deltaTime / duration) > 0; i -= Time.deltaTime / duration)
			{
				Alpha = i;
				yield return null;
			}
			//Debug.Log("time end: " + Time.time);

			Alpha = 0;
			Callback();
		}

		/// <summary>
		/// Coroutine to Fade Out
		/// </summary>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		/// <returns></returns>
		private IEnumerator CameraFadeOut(float duration, bool restart, bool fixedDuration)
		{
			//Debug.Log("_______________________ init Fade Out");
			//Debug.Log("init time: " + Time.time);

			if (restart) Alpha = 0;
			else if (fixedDuration) duration /= (1 - Alpha);

			for (float i = Alpha; (i + Time.deltaTime / duration) < 1; i += Time.deltaTime / duration)
			{
				Alpha = i;
				yield return null;
			}
			//Debug.Log("time end: " + Time.time);

			Alpha = 1;
		}

		/// <summary>
		/// Coroutine to Fade Out with a Callback
		/// </summary>
		/// <param name="Callback">Method or lambda function to call after fade is finished.</param>
		/// <param name="duration">1 by default. How long does it take?</param>
		/// <param name="restart">false by default. If true it starts from alpha = 1.</param>
		/// <param name="fixedDuration">false by default. If false fade's duration is proportional to alpha change, if true it allways take same full duration. Only makes change if restart parameter is false.</param>
		/// <returns></returns>
		private IEnumerator CameraFadeOut(System.Action Callback, float duration, bool restart, bool fixedDuration)
		{
			//Debug.Log("_______________________ init Fade Out");
			//Debug.Log("init time: " + Time.time);

			if (restart) Alpha = 0;
			else if (fixedDuration) duration /= (1 - Alpha);

			for (float i = Alpha; (i + Time.deltaTime / duration) < 1; i += Time.deltaTime / duration)
			{
				Alpha = i;
				yield return null;
			}
			//Debug.Log("time end: " + Time.time);

			Alpha = 1;
			Callback();
		}
	}
}
