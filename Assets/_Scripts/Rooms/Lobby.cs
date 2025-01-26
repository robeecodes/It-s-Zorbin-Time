using Alteruna;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : AttributesSync
{
    [SerializeField] private Multiplayer multiplayer;
    [SerializeField] private GameObject button;
    private bool _loading;

    private void Awake() {
        DontDestroyOnLoad(Camera.main);
    }
    
    private void Update() {
        if (multiplayer.GetUsers().Count >= 2)
        {
            button.SetActive(true);
        }
        else
        {
            button.SetActive(false);
        }
    }

    public void StartButtonPressed()
    {
        BroadcastRemoteMethod("LoadGame");
    }

    [SynchronizableMethod]
    void LoadGame()
    {
        Debug.Log("Loading game . . .\n");
        multiplayer.LoadScene("Game");
        _loading = true;
    }
}
