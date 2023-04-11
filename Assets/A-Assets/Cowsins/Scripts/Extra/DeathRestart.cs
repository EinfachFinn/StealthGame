using UnityEngine;
using cowsins;
using UnityEngine.SceneManagement; 

public class DeathRestart : MonoBehaviour
{
    private void Update()
    {
	    if (InputManager.reloading) SceneManager.LoadScene(0);
    }
	public void Restart()
    {
	    if (InputManager.reloading) SceneManager.LoadScene(0);
    }
}
