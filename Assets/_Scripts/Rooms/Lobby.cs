using Alteruna;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Lobby : AttributesSync
{
    [SerializeField] private Multiplayer multiplayer;
    [SerializeField] private GameObject button;

    private void Awake() {
        DontDestroyOnLoad(Camera.main);
    }
    
    private void Update() {
        button.SetActive(multiplayer.GetUsers().Count >= 2);
    }

    public void StartButtonPressed()
    {
        BroadcastRemoteMethod("LoadGame");
        LoadGame();
    }

    [SynchronizableMethod]
    private void LoadGame()
    {
        multiplayer.LoadScene("Game");
    }
}
