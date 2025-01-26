using Alteruna;
using UnityEngine;

public class CheckCollisions : MonoBehaviour {
    [SerializeField] private Alteruna.Avatar alterunaAvatar;

    private AudioSource rebound_sound;
    private RigidbodySynchronizable _rb;
    private float _distToGround;
    private Health _health;

    public bool grounded;

    private void Awake() {
        _rb = GetComponent<RigidbodySynchronizable>();
        _health = GetComponent<Health>();
        rebound_sound = GameObject.FindWithTag("SFX Manager").GetComponents<AudioSource>()[0];
    }
    
    private void Start() {
        if (!alterunaAvatar.IsMe) return;
        grounded = false;
        _distToGround = GetComponent<Collider>().bounds.extents.y;
    }
    
    private void Update() {
        if (!alterunaAvatar.IsMe) return;
        grounded = Physics.Raycast(transform.position, Vector3.down, _distToGround + 0.1f);
    }

    private void OnCollisionEnter(Collision collision) {
        if (!alterunaAvatar.IsMe) return;
        if (collision.gameObject.name != "Zorb") return;
        rebound_sound.Play();
        var collisionBody = collision.gameObject.GetComponent<RigidbodySynchronizable>();
        if (_rb.velocity.magnitude > collisionBody.velocity.magnitude) {
            collisionBody.AddForce(transform.forward * 100, ForceMode.Impulse);
            collision.gameObject.GetComponent<Health>().BroadcastRemoteMethod("TakeDamage", 10);
        } else {
            _rb.AddForce(collision.transform.forward * 100, ForceMode.Impulse);
            _health.BroadcastRemoteMethod("TakeDamage", 10);
        }
    }
}
