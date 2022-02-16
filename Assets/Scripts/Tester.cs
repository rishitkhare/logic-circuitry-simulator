using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Used for console output ONLY! This component 
 * should not be used in the final product.
 */
public class Tester : MonoBehaviour {
    /*
     * The following method is run once 
     * upon program startup. It acts as
     * a main method.
     */
    void Start() {
        TestNotGate();
        TestNandGate();
        TestNorGate();
    }

    public static bool TestNotGate() {
        // NOT(false) should return true
        if(new NotGate(new InputNode(false)).GetOutput() != true) {
            Debug.Log("inverter did not work on false");
            return false;
        }

        // NOT(true) should return false
        if (new NotGate(new InputNode(true)).GetOutput() != false) {
            Debug.Log("inverter did not work on true");
            return false;
        }

        // NOT(NOT(true)) should return true
        if (new NotGate(new NotGate(new InputNode(true))).GetOutput() != true) {
            Debug.Log("inverter did not nest");
            return false;
        }

        // NOT(empty) should return false
        if (new NotGate(new NotGate(null)).GetOutput() != null) {
            Debug.Log("should default to false when inputs are incomplete");
            return false;
        }


        Debug.Log("All NotGate tests passed!");
        return true;
    }

    public static bool TestNandGate() {
        // just tests the truth table

        if (new NandGate(true, true).GetOutput() != false) {
            Debug.Log("Nand case 1 failed");
            return false;
        }

        if (new NandGate(true, false).GetOutput() != true) {
            Debug.Log("Nand case 2 failed");
            return false;
        }

        if (new NandGate(false, true).GetOutput() != true) {
            Debug.Log("Nand case 3 failed");
            return false;
        }

        if (new NandGate(false, false).GetOutput() != true) {
            Debug.Log("Nand case 4 failed");
            return false;
        }

        Debug.Log("All NandGate tests passed!");
        return true;
    }

    public static bool TestNorGate() {
        // just tests the truth table

        if (new NorGate(true, true).GetOutput() != false) {
            Debug.Log("Nor case 1 failed");
            return false;
        }

        if (new NorGate(true, false).GetOutput() != false) {
            Debug.Log("Nor case 2 failed");
            return false;
        }

        if (new NorGate(false, true).GetOutput() != false) {
            Debug.Log("Nor case 3 failed");
            return false;
        }

        if (new NorGate(false, false).GetOutput() != true) {
            Debug.Log("Nor case 4 failed");
            return false;
        }

        Debug.Log("All NorGate tests passed!");
        return true;
    }
}
