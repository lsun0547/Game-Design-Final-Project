using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseScreen;

    private PlayerController player;
    private AnimalThrower thrower;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        player = FindObjectOfType<PlayerController>();
        thrower = FindObjectOfType<AnimalThrower>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            //test if we are paused or not
            //time scale of 0 means we are paused
            if (Time.timeScale == 0) {
                ResumeGame();
            } else {
                PauseGame();
            }
        }
    }

    private void PauseGame()
    {
        pauseScreen.SetActive(true);

        Time.timeScale = 0f;
        player.canMove = false;
        thrower.canThrow = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
        player.canMove = true;
        thrower.canThrow = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Menu");
    }
}
