using System.Collections.Generic;
using System;
/*
 * This class is used as the base for all logic gates
 * 
 * This class represents a generic logic gate. Since there is no
 * functionality attached, it is abstract.
 */
public abstract class LogicNode {


    // stores the input signals being recieved
    public LogicNode[] Inputs { get; protected set; }

    // Getting the output involves taking all the inputs and synthesizing.
    // If any part of the circuit is open, return null.
    public bool? GetOutput() {
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
            bool? output = Inputs[i].GetOutput();

            // if any single one of our inputs is giving us null, the
            // circuit is open.
            if (output == null) {
                return null;
            }
            else {
                InputResults[i] = (bool)Inputs[i].GetOutput();
            }
        }

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