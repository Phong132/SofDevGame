using UnityEngine;
using UnityEngine.SceneManagement;

//Script used in the death Menu.
public class DeathMenu : MonoBehaviour {

    public int resetScore = 0;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
	}
	

//activate the death menu
    public void ToggleMenu()
    {
        gameObject.SetActive(true);
    }


    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        //when player dies and restarts, lives are reset to 3
        PlayerPrefs.SetInt("PlayerCurrentLives", 3);

        //when player dies and restarts, score is set to 0
        PlayerPrefs.SetInt("CurrentScore", resetScore);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

}
