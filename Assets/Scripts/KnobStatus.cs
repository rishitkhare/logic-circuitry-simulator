using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This class only stores a power status (on/off) and sets 
 * the Knob to that power
 */
public class KnobStatus : MonoBehaviour {

    private bool _power;
    public bool Power {
        get{return _power;}
        set {
            _power = value;
            powerGO.SetActive(_power);
        }
    }

    private GameObject powerGO;

    void Awake() {
        powerGO = transform.Find("Power").gameObject;
    }

    public void SetStatus(bool state) {
        Power = state;
    }
}
