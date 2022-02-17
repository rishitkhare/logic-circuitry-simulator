using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicGateNodes;

public class NorGateBehavior : LogicNodeBehavior {
    // init the backend object
    void Awake() {
        Node = new NorGate();
    }
}
