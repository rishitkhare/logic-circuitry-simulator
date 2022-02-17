using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LogicGateNodes;

public class LogicNodeBehavior : MonoBehaviour {

    public LogicNode Node { get; protected set; }


    public void SetInput(int index, LogicNodeBehavior other) {
        Node.Inputs[index] = other.Node;
    }
}

