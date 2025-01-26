using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BGMusic : MonoBehaviour
{
    public AudioSource menu_music;
    public AudioSource bg_music;
    private string active_scene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active_scene != SceneManager.GetActiveScene().name) 
        {
            active_scene = SceneManager.GetActiveScene().name;
            if (active_scene == "Title Menu")
            {
                menu_music.Play();
                menu_music.loop = true;
                bg_music.Pause();
            }
            else
            {
                bg_music.Play();
                bg_music.loop = true;
                menu_music.Pause();
            }
        }
        
    }
}
