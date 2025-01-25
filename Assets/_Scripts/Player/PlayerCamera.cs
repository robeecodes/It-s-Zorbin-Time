using Cinemachine;
using UnityEngine;

public class PlayerCamera : MonoBehaviour {
    private Alteruna.Avatar _avatar;
    private CinemachineVirtualCamera _vcam;
    [SerializeField] private Transform cameraRoot;

    private void Awake() {
        _avatar = GetComponent<Alteruna.Avatar>();
    }

    private void Start() {
        _vcam = GetComponentInChildren<CinemachineVirtualCamera>();
        if (_avatar.IsMe) {
            if (_vcam != null) {
                _vcam.gameObject.SetActive(true); // Enable the camera for the local player
            }

            _vcam.Follow = cameraRoot; // Set follow to the player's transform
            _vcam.LookAt = cameraRoot; // Set look-at to the player's transform
        }
        else {
            _vcam.gameObject.SetActive(false);
        }
    }

    void OnDestroy() {
        if (_vcam != null) {
            _vcam.gameObject.SetActive(false);
        }
    }
}