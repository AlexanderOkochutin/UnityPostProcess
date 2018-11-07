using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DamageStatesSettings", menuName = "Damage/DamageStatesSettings", order = 1)]
public class DamageStatesSettings : ScriptableObject {

    #region Variables

    [SerializeField] private List<DamageState> damageStates;

    #endregion

    #region Properties

    public List<DamageState> DamageStates => damageStates;

    #endregion

}
