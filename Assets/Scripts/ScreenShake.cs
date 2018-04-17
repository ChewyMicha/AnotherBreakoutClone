using System.Collections;
using UnityEngine;

public class ScreenShake : MonoBehaviour {

	private float _magnitude;
	public IEnumerator currShake=null;  // makes sure that there is always just 1 coroutine running at once
	
	/// <summary>
	/// Screenshake changing rotation and position
	/// </summary>
	/// <param name="duration"></param>
	/// <param name="magnitude"></param>
	/// <returns></returns>
	public IEnumerator Shake(float duration, float magnitude)
	{
		currShake = (Shake(duration, magnitude));
		Vector3 startPos = transform.localPosition;

		_magnitude = Mathf.Pow(magnitude, 2); // so the screenshake is really intens at the start but gets weaker quickly


		float timeShaked = 0f;

		while (timeShaked<duration)
		{
			float x = Random.Range(-1f, 1f);
			float y = Random.Range(-1f, 1f);

			transform.position += new Vector3 (x*.1f,y*.1f,0)*_magnitude;
			transform.rotation = Quaternion.Euler(0, 0, y*_magnitude);

			timeShaked +=  Time.deltaTime;
			_magnitude = Mathf.Sqrt(_magnitude); // so the screenshake is really intens at the start but gets weaker quickly
			//Debug.Log(_magnitude);
												
			yield return null;
		}
		transform.rotation = Quaternion.Euler(0, 0, 0);
		transform.localPosition = startPos;
		currShake = null;
	}
}
