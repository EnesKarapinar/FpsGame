using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject pauseMenuUI;
    public Animation cam;
    public GameObject[] selected;
    public Button startGame;

    private bool isPaused;
    public static bool whichCharacterSelected;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu"){
            Time.timeScale = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name != "MainMenu"){
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                if(isPaused == true)
                {
                    ResumeGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
        else if(SceneManager.GetActiveScene().name == "MainMenu"){
            if(whichCharacterSelected){
                selected[0].SetActive(false);
                selected[1].SetActive(true);
            }else{
                selected[0].SetActive(true);
                selected[1].SetActive(false);
            }
        }
    }

    public void Play(){
        cam.Play("menuToSelectCharacter");
    }

    public void StartGame(){
        Application.LoadLevel(1);
    }

    public void PageToMainMenu(){
        cam.Play("selectCharacterToMenu");
    }

    public void WhichCharacter(Button btn){
        if(btn.name == "maleBtn"){
            whichCharacterSelected = true;
        }else{
            whichCharacterSelected = false;
        }
    }

    void PauseGame()
    {
        pauseMenuUI.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        isPaused = true;
    }

    void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
        isPaused = false;
    }

    public void MainMenu(){
        Application.LoadLevel(0);
    }

    public void AppQuit()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
}