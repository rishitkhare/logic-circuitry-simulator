using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicGateNodes;

public class InputNodeBehavior : LogicNodeBehavior {

    // this is the reference to the light that shows
    // the input's state
    private KnobStatus blinker;

    void Awake() {
        Node = new InputNode(true);
        blinker = transform.Find("Status").GetComponent<KnobStatus>();
    }
    
    public void InvertState() {
        InputNode inputNode = (InputNode) Node;

        inputNode.state = !inputNode.state;
        blinker.SetStatus(inputNode.state);
    }
}
