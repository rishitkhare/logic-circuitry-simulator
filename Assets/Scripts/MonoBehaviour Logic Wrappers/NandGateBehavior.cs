using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicGateNodes;

public class NandGateBehavior : LogicNodeBehavior {

    // init the backend object
    void Awake() {
        Node = new NandGate();
    }
}