using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicGateNodes;

// TODO deprecate this class bruh
public class NotGateBehavior : LogicNodeBehaviour {
    public NotGate notGate { get; private set; }

    // init the backend object
    void Awake() {
        notGate = new NotGate();
    }
}
