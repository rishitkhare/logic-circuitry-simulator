using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicGateNodes;

public class OutputNodeBehavior : LogicNodeBehavior {

    // this is the reference to the light that shows
    // the output's state
    private KnobStatus blinker;

    void Awake() {
        Node = new OutputNode();
        blinker = transform.Find("Status").GetComponent<KnobStatus>();
    }

    // TODO make this only update when wiring changes (maybe?)
    void Update() {
        bool? output = Node.GetOutput();
        if (output == null) {
            blinker.SetStatus(false);
        }
        else {
            blinker.SetStatus((bool) output);
        }
    }
}
