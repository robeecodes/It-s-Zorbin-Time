using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public PlayerSkin charSelected = PlayerSkin.NULL;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    // Main Menu Buttons
    public void OnStartPressed()
    {
        SceneManager.LoadScene("Character Select");
    }
    public void OnQuitPressed()
    {
        Application.Quit();
    }

    // Character Select Buttons
    public void OnPlayPressed()
    {
        if (charSelected != PlayerSkin.NULL)
        {
            Debug.Log(charSelected);
            SceneManager.LoadScene("Lobby");
        }
    }
    public void OnBackPressed()
    {
        SceneManager.LoadScene("Title Menu");
    }
    // player skins
    public void DefaultSelected()
    {
        charSelected = PlayerSkin.Default;
    }
    public void RobotSelected()
    {
        charSelected = PlayerSkin.Robot;
    }
    public void SansSelected()
    {
        charSelected = PlayerSkin.Sans;
    }
    public void AmongusSelected()
    {
        charSelected = PlayerSkin.Amongus;
    }
}
