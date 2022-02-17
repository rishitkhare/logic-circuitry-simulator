using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicGateNodes;

public class NotGateBehavior : LogicNodeBehavior {

    // init the backend object
    void Awake() {
        Node = new NotGate();
    }
}
