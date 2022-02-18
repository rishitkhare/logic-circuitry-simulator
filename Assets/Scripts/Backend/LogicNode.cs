using System.Collections.Generic;
using System;
using UnityEngine;

namespace LogicGateNodes {
    /*
     * This class is used as the base for all logic gates
     * 
     * This class represents a generic logic gate. Since there is no
     * functionality attached, it is abstract.
     */
    public abstract class LogicNode {


        // stores the input signals being recieved
        public LogicNode[] Inputs;

        private bool oldState;

        // Getting the output involves taking all the inputs and synthesizing.
        // If any part of the circuit is open, return null.

        public bool? GetOutput() {

            bool? outputResult = GetOutput(new List<LogicNode>());

            if(outputResult == null) {
                oldState = false;
            }
            else {
                oldState = (bool) outputResult;
            }

            return outputResult;
        }

        public bool? GetOutput(List<LogicNode> stackTrace) {
            // if we have already tried getting the output of this node,
            // then we are stuck in an infinite loop
            if(stackTrace.Contains(this)) {
                return oldState;
            }
            stackTrace.Add(this);

            // get the inputs ready, (recursive)

            // the results array should never contain null, because they
            // are going to be operated on
            bool[] InputResults = new bool[Inputs.Length];

            for (int i = 0; i < Inputs.Length; i++) {

                // if any of the inputs are not supplied circuit is open
                if(Inputs[i] == null) {
                    return null;
                }

                // get the values of the input
                bool? output = Inputs[i].GetOutput(stackTrace);

                // if any single one of our inputs is giving us null, the
                // circuit is open.
                if (output == null) {
                    return null;
                }
                else {
                    InputResults[i] = (bool) output;
                }
            }

            stackTrace.Remove(this);

            // we only reach this point if the circuit is closed
            return PerformOperation(InputResults);
        }

        /*
         * Should calculate the state based on the given inputs.
         */
        protected abstract bool PerformOperation(bool[] inputs);

        /*
         * Returns the output of the string.
         */
        public override string ToString() {
            return "" + GetType() + ": " + GetOutput();
        }
    }
}