using Alteruna;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField] private Multiplayer multiplayer;
    private bool _loading;

    private void Awake() {
        DontDestroyOnLoad(Camera.main);
    }
    
    private void Update() {
        if (multiplayer.GetUsers().Count != 1 || _loading) return;
        multiplayer.LoadScene("Game");
        _loading = true;
    }
}
