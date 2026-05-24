using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    //This script is responsible for the buttons in the main menu, such as starting the game and quitting the game
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    //Function to quit the game, which will only work in a built version of the game, in the editor it will do nothing
    public void QuitGame()
    {
        Application.Quit();
    }
}
