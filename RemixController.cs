using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class RemixController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (slider.value == -20f)
        {
            audioMixer.SetFloat("Volume", -80f);

        }
        else
        {
            audioMixer.SetFloat("Volume", slider.value);
        }
    }

}
