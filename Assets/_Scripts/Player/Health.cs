using Alteruna;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : AttributesSync {
    private Multiplayer _multiplayer;

    [SynchronizableField] private int _hp;
    [SynchronizableField] public int stocks;

    private RigidbodySynchronizable _rb;

    private bool _isDead;

    private void Awake() {
        
    }
    
    private void Start() {
        _hp = 100;
        stocks = 3;
        _rb = GetComponent<RigidbodySynchronizable>();
    }

    private void Update() {
        if (SceneManager.GetActiveScene().name != "Game") return;
        if (!_multiplayer) _multiplayer = FindFirstObjectByType<Multiplayer>();
        if (_hp <= 0) BroadcastRemoteMethod("Die");
        if (transform.position.y <= -10) BroadcastRemoteMethod("Die");
    }

    [SynchronizableMethod]
    public void TakeDamage(int damage) {
        if (SceneManager.GetActiveScene().name != "Game") return;
        _hp -= damage;
    }

    [SynchronizableMethod]
    private void Die() {
        if (_isDead) return;
        _isDead = true;
        stocks--;
        _hp = 100;

        if (stocks > 0) {
            _rb.position = new Vector3(-14.01f, 2.7f, -16.58f);
            _isDead = false;
        } else {
            _rb.position = new Vector3(0f, -200f, 0f);
            
        }
    }
}