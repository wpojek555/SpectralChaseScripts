using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;


[CreateAssetMenuAttribute(fileName = "New Telephone Object", menuName = "Assets/New Telephone Object")]
public class TelephoneCall : ScriptableObject
{
    public AudioObject clip;

    public string nameOfCaller = "Dave";
}
