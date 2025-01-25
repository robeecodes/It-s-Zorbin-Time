using Alteruna;
using UnityEngine;


public class ControlZorb : MonoBehaviour {
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private RigidbodySynchronizable zorb;

    private Camera _mainCamera;

    private Alteruna.Avatar _avatar;

    private void Awake() {
        _avatar = GetComponent<Alteruna.Avatar>();
        _mainCamera = Camera.main;
    }

    private void Start() {
        if (!_avatar.IsMe) return;
    }

    private void FixedUpdate() {
        if (!_avatar.IsMe) return;

        // Get camera's forward and right directions
        Vector3 cameraForward = _mainCamera.transform.forward;
        Vector3 cameraRight = _mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        cameraForward = cameraForward.normalized;
        cameraRight = cameraRight.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = cameraRight * horizontalInput + cameraForward * verticalInput;

        zorb.AddForce(movement * moveSpeed, ForceMode.VelocityChange);
    }
}