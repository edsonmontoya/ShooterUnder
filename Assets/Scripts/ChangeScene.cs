using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
