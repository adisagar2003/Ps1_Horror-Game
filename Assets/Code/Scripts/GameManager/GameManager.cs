using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private string firstLevel = "Level1";
    [SerializeField] private string thirdLevel = "Level3"; // player can only die in this levl
public void StartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Level3");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
