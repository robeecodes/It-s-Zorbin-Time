using Alteruna;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] private Transform[] spawnPoints;
    private Multiplayer _multiplayer;
    private bool _moved;

    private void Awake() {
        _multiplayer = GameObject.Find("Multiplayer").GetComponent<Multiplayer>();
    }

    private void Update() {
        if (!_moved) {
            MoveZorbs();
            _moved = true;
        }
        
    }

    private void MoveZorbs() {
        var avatars = _multiplayer.GetAvatars();

        for (int i = 0; i < avatars.Count; i++) {
            Alteruna.Avatar playerAvatar = avatars[i];

            if (playerAvatar) {
                playerAvatar.transform.position = spawnPoints[i].position;
            }
        }
    }
}