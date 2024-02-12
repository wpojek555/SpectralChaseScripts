using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class TeleManager : MonoBehaviour
{
    public static TeleManager instance;
    [SerializeField] private AudioClip hangOutClip;
    [SerializeField] private AudioClip ringingingClip;
    [SerializeField] private GameObject UIBtns;
    [SerializeField] private TextMeshProUGUI title;

    bool isPlaying;
    bool isTalking;

    private AudioSource glosnik;

    private AudioObject TalkClip;

    private PlayableDirector EndCall;
    private TelephoneCall telephone;

    private void Awake()
    {
        instance = this;
        glosnik = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.F1) && !isTalking)
            {
                Vocals.instance.Say(TalkClip);
                UIBtns.SetActive(false);
                glosnik.Stop();
                title.text = telephone.nameOfCaller;
                StartCoroutine(StopPlaying(TalkClip.clip.length));
            }
            if (Input.GetKeyDown(KeyCode.F2) && !isTalking)
            {
                isPlaying = false;
                glosnik.loop = false;
                glosnik.clip = hangOutClip;
                EndCall.Play();
                StartCoroutine(WaitForSeconds(2));
            }
        }
    }

    public void CreateNewCall(TelephoneCall CallVoice, PlayableDirector CallNotification, PlayableDirector CallNotificationEnd)
    {
        CallNotification.Play();
        glosnik.loop = true;
        glosnik.clip = ringingingClip;
        glosnik.Play();
        title.text = CallVoice.nameOfCaller + " is calling";
        isPlaying = true;
        telephone = CallVoice;

        EndCall = CallNotificationEnd;

        TalkClip = CallVoice.clip;
    }
    IEnumerator StopPlaying(float delay)
    {
        yield return new WaitForSeconds(delay);
        EndCall.Play();
        StartCoroutine(WaitForSeconds(2));


    }
    IEnumerator WaitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        UIBtns.SetActive(true);
    }
}
