using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public Button a;
    public AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Button();
    }

    public void Button()
    {
        Button a = GetComponent<Button>();
        AudioSource sound = GetComponent<AudioSource>();
        a.onClick.AddListener(delegate () { sound.Play(); });
    }
}
