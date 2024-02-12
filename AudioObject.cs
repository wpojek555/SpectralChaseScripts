using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenuAttribute(fileName = "New Audio Object", menuName = "Assets/New Audio Object")]
public class AudioObject : ScriptableObject
{
    public AudioClip clip;
    public string subtitleEN;
    public string subtitlePL;


}
