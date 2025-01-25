using System;
using Alteruna;
using UnityEngine;

public class ControlZorb : MonoBehaviour {
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private GameObject zorb;
    
    private CheckCollisions _zorbCollider;
    private RigidbodySynchronizable _zorbRigidbody;
    
    private Camera _mainCamera;
    private Alteruna.Avatar _avatar;

    private void Awake() {
        _avatar = GetComponent<Alteruna.Avatar>();
        _mainCamera = Camera.main;
        _zorbCollider = zorb.GetComponent<CheckCollisions>();
        _zorbRigidbody = zorb.GetComponent<RigidbodySynchronizable>();
    }
    
    private void Update() {
        if (!_avatar.IsMe) return;
        if (Input.GetKeyDown(KeyCode.Space) && _zorbCollider.grounded) {
            _zorbRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
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

        _zorbRigidbody.AddForce(movement * moveSpeed, ForceMode.VelocityChange);
    }
}