using UnityEngine;
using UnityEngine.SceneManagement;

public class FantasyMario : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void LoadSinglePlayer()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("gamemode",1);
        SceneManager.LoadScene("Gameplayscene");  
    }
    public void LoadMultiplePlayer()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("gamemode",2);
        SceneManager.LoadScene("Gameplayscene");
    }
    public void LoadOnGame()
    {
        SceneManager.LoadScene("OnGame");
    }
    public void LoadSetting()
    {
        SceneManager.LoadScene("Setting");
    }
    public void UnPauseGame()
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("PauseScene");
    }
    public void LoadMap2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Gameplayscene2");
    }
    
}
