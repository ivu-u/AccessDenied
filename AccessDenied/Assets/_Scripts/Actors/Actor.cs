using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*****************************************************************
 * A lot of this is taken from Carlos's Actor script from Bonbon.
*****************************************************************/

/// <summary>
/// The parent class for actors.
/// </summary>
public class Actor : MonoBehaviour
{
    #region Data Attributes
    [SerializeField] private ActorData data;
    public ActorData Data => data;
    #endregion

    #region Variable Attributes
    [SerializeField] private int _hitpoints;

    public int Hitpoints => _hitpoints;
    #endregion

    void Awake() {
        // initialize actor attributes
        _hitpoints = data.MaxHitpoints;
    }

    public void DepleteHitpoints(int damage) {
        _hitpoints -= damage;

        if (_hitpoints <= 0) Faint();
    }

    public void RestoreHitpoints(int heal) {
        _hitpoints += heal;
    }

    private void Faint() {
        // probably override this based on if it's a player or an enemy
    }
}
