using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZorbCam : MonoBehaviour {
    [Header("Cinemachine")]
    [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
    public GameObject CinemachineCameraTarget;

    [Tooltip("How far in degrees can you move the camera up")]
    public float TopClamp = 70.0f;

    [Tooltip("How far in degrees can you move the camera down")]
    public float BottomClamp = -30.0f;

    [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
    public float CameraAngleOverride = 0.0f;

    [Tooltip("For locking the camera position on all axis")]
    public bool LockCameraPosition = false;

    // Cinemachine camera variables
    private float _cinemachineTargetYaw;
    private float _cinemachineTargetPitch;
    private float _originalCameraTargetY;

    private GameObject _mainCamera;
    
    [SerializeField] private GameObject zorb;
    
    private Alteruna.Avatar _alterunaAvatar;

    // Sensitivity for mouse input
    public float MouseSensitivityX = 200f;
    public float MouseSensitivityY = 100f;

    private void Awake() {
        // get a reference to our main camera
        if (_mainCamera == null) {
            _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
        
        _alterunaAvatar = GetComponent<Alteruna.Avatar>();
    }

    private void Start() {
        _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;
        _originalCameraTargetY = CinemachineCameraTarget.transform.localPosition.y;
    }

    private void Update() {
        if (!_alterunaAvatar.IsMe) return;
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(0f, _cinemachineTargetYaw, 0f);
        CinemachineCameraTarget.transform.position = new Vector3(zorb.transform.position.x, _originalCameraTargetY, zorb.transform.position.z);
        
        CameraRotation();
        ApplyCameraRotation();
    }

    private void LateUpdate() {
        if (!_alterunaAvatar.IsMe) return;
        CameraRotation();
        ApplyCameraRotation();
    }

    private void CameraRotation() {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // Apply mouse movement to the yaw (horizontal) and pitch (vertical)
        _cinemachineTargetYaw += mouseX * MouseSensitivityX * Time.deltaTime;
        _cinemachineTargetPitch -= mouseY * MouseSensitivityY * Time.deltaTime;

        _cinemachineTargetPitch = Mathf.Clamp(_cinemachineTargetPitch, BottomClamp, TopClamp);
    }

    private void ApplyCameraRotation() {
        CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride, _cinemachineTargetYaw, 0f);
    }
}
