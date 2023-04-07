using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    bool isPaused = false;
    public void ChnageScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
        UIManager.instance.pausePanel.SetActive(true);
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        isPaused = false;
        UIManager.instance.pausePanel.SetActive(false);
    }

    public void InstructionPanelShow()
    {
        UIManager.instance.instructionPanel.SetActive(true);
    }

    public void InstructionPanelHide()
    {
        UIManager.instance.instructionPanel.SetActive(false);
    }
}
