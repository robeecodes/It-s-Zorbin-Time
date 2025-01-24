using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAvatar : MonoBehaviour
{
    private Alteruna.Avatar _alterunaAvatar;
    
    private void Start() {
        _alterunaAvatar = GetComponent<Alteruna.Avatar>();

        if (!_alterunaAvatar.IsMe) return;
    }

    private void Update()
    {
        if (!_alterunaAvatar.IsMe) return;
    }
}
