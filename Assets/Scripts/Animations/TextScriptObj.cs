using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Text Writing", menuName = "Event")]
public class Event : ScriptableObject
{
    [TextArea]
    public string finalText;
}
