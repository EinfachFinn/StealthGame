using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RandomDeathAnimation : MonoBehaviour
{
    // Update is called once per frame
	public void SelectScene()
	{
		Debug.Log("SceneSwitch");
		SceneManager.LoadScene(Random.Range(1,3));
	}
    
	public void Restart()
	{
		Debug.Log("SceneSwitch");
		SceneManager.LoadScene(0);
	}
}
