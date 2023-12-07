using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*****************************************************************
 * A lot of this is taken from Carlos's Actor script from Bonbon.
*****************************************************************/

/// <summary>
/// Setting the data for a specific character that "Actor" class will use
/// </summary>
public class ActorData : ScriptableObject
{
    [Header("Actor Details")]
    [SerializeField] private string actorName = "Dummy";
    [SerializeField] private int maxHitpoints = 100;

    // read only fields
    public string ActorName => actorName;
    public int MaxHitpoints => maxHitpoints;
}
