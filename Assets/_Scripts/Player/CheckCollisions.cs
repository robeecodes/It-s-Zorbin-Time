using Alteruna;
using UnityEngine;

public class CheckCollisions : MonoBehaviour {
    [SerializeField] private Alteruna.Avatar alterunaAvatar;

    private RigidbodySynchronizable _rb;
    private float _distToGround;

    public bool grounded;

    private void Awake() {
        _rb = GetComponent<RigidbodySynchronizable>();
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
        var collisionBody = collision.gameObject.GetComponent<RigidbodySynchronizable>();
        if (_rb.velocity.magnitude > collisionBody.velocity.magnitude) {
            collisionBody.AddForce(transform.forward * 100, ForceMode.Impulse);
        } else {
            _rb.AddForce(collision.transform.forward * 100, ForceMode.Impulse);
        }
    }
}
