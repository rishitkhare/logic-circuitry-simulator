/*
 * Represents a "NAND" gate. Returns true whenever
 * at least one input is false.
 */
public class NandGate : LogicNode {
    /*
     * No parameters means the input is nothing
     */
    public NandGate() : this(null, null) { }

    /*
     * One parameter sets first input
     */
    public NandGate(LogicNode inputA) : this(inputA, null) { }
    public NandGate(bool inputA) : this(new InputNode(inputA), null) { }


    // Constructor
    public NandGate(bool inputA, bool inputB) :
        this(new InputNode(inputA), new InputNode(inputB)) { }

    public NandGate(LogicNode inputA, LogicNode inputB) {
        Inputs = new LogicNode[2];
        Inputs[0] = inputA;
        Inputs[1] = inputB;
    }

    /*
     * Returns true whenever
     * at least one input is false.
     */
    protected override bool PerformOperation(bool[] inputs) {
        return !inputs[0] || !inputs[1];
    }
}