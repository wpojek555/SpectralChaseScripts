using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoverSound : MonoBehaviour
{
    [SerializeField] private AudioSource audio;
    public bool play;
    private bool switchBool;

    private void Update()
    {
        if (play && !switchBool)
        {
            audio.Play();
            switchBool = true;
        }
        if (!play) switchBool = false;
    }
}
