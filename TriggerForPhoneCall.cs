using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TriggerForPhoneCall : MonoBehaviour
{
    bool isActivated;
    public PlayableDirector start;
    public PlayableDirector end;

    [SerializeField] private float delay;

    public TelephoneCall Clip;

    
    private void OnTriggerStay(Collider other)
    {
        if (!isActivated)
        {
            isActivated = true;
            StartCoroutine(StartCall(delay));
            Debug.Log("Powinno dzia³aæ");
        }
    }

    IEnumerator StartCall(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (TeleManager.instance != null)
        {
            TeleManager.instance.CreateNewCall(Clip, start, end);
        }
        else
        {
            Debug.LogError("TeleManager.instance is null!");
        }
    }
}
