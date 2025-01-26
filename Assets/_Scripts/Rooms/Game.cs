using System.Linq;
using Alteruna;
using UnityEngine;

public class Game : MonoBehaviour {
    [SerializeField] public Transform[] spawnPoints;
    private Multiplayer _multiplayer;
    private bool _moved;

    private void Awake() {
        _multiplayer = GameObject.Find("Multiplayer").GetComponent<Multiplayer>();
    }

    private void Update() {
        if (_moved) return;
        _moved = true;
        MoveZorbs();

    }

    private void MoveZorbs() {
        var zorbs = GameObject.FindGameObjectsWithTag("Zorb");

        for (int i = 0; i < zorbs.Length; i++) {
            var zorb = zorbs[i];
            
            var _rb = zorb.GetComponent<RigidbodySynchronizable>();
            _rb.velocity = Vector3.zero;
            _rb.angularVelocity = Vector3.zero;
            _rb.Sleep();
            
            if (zorb) {
                _rb.position = spawnPoints[i].position;
            }
        }
    }
}