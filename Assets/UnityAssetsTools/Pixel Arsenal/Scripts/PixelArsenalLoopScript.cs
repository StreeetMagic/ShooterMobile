using System.Collections;
using UnityEngine;

namespace UnityAssetsTools.Pixel_Arsenal.Scripts
{
public class PixelArsenalLoopScript : MonoBehaviour {

	public GameObject chosenEffect;
    public float loopTimeLimit = 2.0f;

	void Start ()
	{
		PlayLoopingPEffect();
	}


	public void PlayLoopingPEffect()
	{
		StartCoroutine("EffectLoop");
	}
	

	IEnumerator EffectLoop()
	{
		GameObject effectPlayer = (GameObject) Instantiate(chosenEffect, transform.position, transform.rotation);

		yield return new WaitForSeconds(loopTimeLimit);

		Destroy (effectPlayer);
		PlayLoopingPEffect();
	}
}
}