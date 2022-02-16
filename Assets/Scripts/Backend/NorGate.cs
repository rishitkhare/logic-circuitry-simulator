namespace LogicGateNodes {
    /*
     * Represents a "NAND" gate. Returns true whenever
     * both inputs are false.
     */
    public class NorGate : LogicNode {
        /*
         * No parameters means the input is nothing
         */
        public NorGate() : this(null, null) { }

        /*
         * One parameter sets first input
         */
        public NorGate(LogicNode inputA) : this(inputA, null) { }

        // with only bool
        public NorGate(bool inputA) : this(new InputNode(inputA), null) { }

        /*
         * Constructor
         */

        // with only bool
        public NorGate(bool inputA, bool inputB) :
            this(new InputNode(inputA), new InputNode(inputB)) { }

        public NorGate(LogicNode inputA, LogicNode inputB) {
            Inputs = new LogicNode[2];
            Inputs[0] = inputA;
            Inputs[1] = inputB;
        }

        /*
         * Returns true when both inputs
         * are false.
         */
        protected override bool PerformOperation(bool[] inputs) {
            return !inputs[0] && !inputs[1];
        }
    }
}