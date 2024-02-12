using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitlesUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI subtitle;

    public static SubtitlesUI instance;

    private void Awake()
    {
        instance = this;
    }

    public void SetSubtitle(string text, float delay)
    {
        subtitle.text = text;
        StartCoroutine(ClearAfterSeconds(delay));
    }

    public void CleanSubtitle()
    {
        subtitle.text = "";
    }

    private IEnumerator ClearAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);

        CleanSubtitle();
    }
}
