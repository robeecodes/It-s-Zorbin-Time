using Alteruna;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckGameovers : AttributesSync
{
    private GameObject[] _zorbs;
    // Start is called before the first frame update
    void Start()
    {
        _zorbs = GameObject.FindGameObjectsWithTag("Zorb");
    }

    // Update is called once per frame
    void Update()
    {
        int count = 0;
        foreach (var zorb in _zorbs)
        {
            if (zorb == null)
            { return;  }
            var _rb = zorb.GetComponent<RigidbodySynchronizable>();
            if (_rb.position.y <= -200)
            {
                count++;
            }
            
        }
        if (count >= _zorbs.Length - 1)
        {
            BroadcastRemoteMethod("GameOver");
            GameOver();
        }
    }

    [SynchronizableMethod]
    void GameOver()
    {
        SceneManager.LoadScene("Title Menu");
    }    
}
