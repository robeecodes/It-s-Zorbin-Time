using UnityEngine;

public class ShowMouse : MonoBehaviour
{
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
