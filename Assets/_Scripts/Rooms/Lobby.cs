using System;
using System.Collections;
using System.Collections.Generic;
using Alteruna;
using UnityEngine;

public class Lobby : MonoBehaviour
{
    [SerializeField] private Multiplayer multiplayer;

    void Update() {
        if (multiplayer.GetUsers().Count == 4) {
            multiplayer.LoadScene("Main", true);
        }
    }
}
