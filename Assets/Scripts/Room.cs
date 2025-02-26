using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Text/Room")]
public class Room : ScriptableObject
{
    public string roomName;
    [TextArea]      //makes this a larger area to type description
    public string description;
    public Exit[] exits;

    public bool hasKey;
    public bool hasOrb;
}
