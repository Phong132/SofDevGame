using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathMenu : MonoBehaviour {

    //public int playerLives = 3;

    public int resetScore = 0;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

    }

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
