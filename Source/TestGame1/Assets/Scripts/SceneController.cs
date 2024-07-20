using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	public void LoadGame1() => SceneManager.LoadScene("Game1");

	public void LoadGame2() => SceneManager.LoadScene("Game2");

	public void LoadMenu() => SceneManager.LoadScene("MainMenu");
}
