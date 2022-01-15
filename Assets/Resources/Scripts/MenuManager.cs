using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private string introMenu = "IntroMenu";
    private string mainMenu = "MainMenu";
    private string breathingMenu = "BreathingMenu";
    private string environmentMenu = "EnvironmentMenu";
    private string breathingExercise = "BreathingExercise";
    private string diceGame = "DiceGame";
    public static int videoID;
    public bool guidedPressed;

    public void ChangeScene(int sceneID)
    {
        switch (sceneID)
        {
            case 0:
            {
                SceneManager.LoadScene(introMenu, LoadSceneMode.Single);
                break;
            }

            case 1:
            {
                SceneManager.LoadScene(mainMenu, LoadSceneMode.Single);
                break;
            }

            case 2:
            {
                SceneManager.LoadScene(breathingMenu, LoadSceneMode.Single);
                break;
            }

            case 3:
            {
                SceneManager.LoadScene(environmentMenu, LoadSceneMode.Single);
                break;
            }

            case 4:
            {
                SceneManager.LoadScene(breathingExercise, LoadSceneMode.Single);
                break;
            }

            case 5:
            {
                SceneManager.LoadScene(diceGame, LoadSceneMode.Single);
                break;
            }

            default:
            {
                Debug.LogError("Quit VRelax");
                Application.Quit();
                break;
            }
        }
    }

    public void Guided(bool pressed)
    {
        VideoManager.guided = pressed;
    }

    public void SelectEnvironment(int environmentID)
    {
        videoID = environmentID;
    }
}
