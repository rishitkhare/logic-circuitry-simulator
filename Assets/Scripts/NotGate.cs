/*
 * Represents a "NOT" gate. Inverts the input and 
 * passes it as output.
 */
public class NotGate : LogicNode {
    /*
     * No parameters means the input is nothing
     */
    public NotGate() : this(null) {}

    /*
     * Constructor with just bools
     */
    public NotGate(bool input) : this(new InputNode(input)){}
    
    // constructor
    public NotGate(LogicNode input) {
        Inputs = new LogicNode[1];
        Inputs[0] = input;
    }

    /*
     * Inverts the input passed to it.
     */
    protected override bool PerformOperation(bool[] inputs) {
        return !inputs[0];
    }
}
