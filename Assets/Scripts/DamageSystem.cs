using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour {

    public DamageController damageController;

	// Use this for initialization
	void Start () {
        damageController = GetComponent<DamageController>();
	}

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            damageController.SetIndexOfDamage(1);
        }
        else
        if (Input.GetKey(KeyCode.Alpha2))
        {
            damageController.SetIndexOfDamage(2);
        }
        else
        if (Input.GetKey(KeyCode.Alpha3))
        {
            damageController.SetIndexOfDamage(3);
        }
        else
        if (Input.GetKey(KeyCode.Alpha4))
        {
            damageController.SetIndexOfDamage(4);
        }
    }
}
