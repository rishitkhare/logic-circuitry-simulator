using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LogicGateNodes {
    /*
     * Represents a basic output node. It does not perform any
     * operations. It acts as a base case for the recursive calls
     * of the other nodes.
     */
    public class OutputNode : LogicNode {

        /*
         * Constructor determines the number of 
         * allowed outputs and sets the state of
         * this node.
         */
        public OutputNode() {
            Inputs = new LogicNode[1];
        }

        // return whatever it is given
        protected override bool PerformOperation(bool[] inputs) {
            return inputs[0];
        }
    }
}
