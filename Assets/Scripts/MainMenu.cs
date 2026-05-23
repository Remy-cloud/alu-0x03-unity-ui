using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Material trapMat;
    public Material goalMat;
    public Toggle colorblindMode;

    private Color trapOriginalColor = Color.red;
    private Color goalOriginalColor = Color.green;

    public void PlayMaze()
    {
        if (colorblindMode.isOn)
        {
            trapMat.color = new Color32(255, 112, 0, 255);
            goalMat.color = Color.blue;
        }
        else
        {
            trapMat.color = trapOriginalColor;
            goalMat.color = goalOriginalColor;
        }

        SceneManager.LoadScene("Maze");
    }

    public void QuitMaze()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
