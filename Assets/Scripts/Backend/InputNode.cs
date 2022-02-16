namespace LogicGateNodes {
    /*
     * Represents a basic input node. It does not perform any
     * operations. It acts as a base case for the recursive calls
     * of the other nodes.
     */
    public class InputNode : LogicNode {

        public bool state{ get; set; }

        /*
         * Constructor determines the number of 
         * allowed inputs and sets the state of
         * this node.
         */
        public InputNode(bool initial_state) {
            Inputs = new LogicNode[0];
            state = initial_state;
        }

        /*
         * Returns its own state
         */
        protected override bool PerformOperation(bool[] inputs) {
            return state;
        }
    }
}