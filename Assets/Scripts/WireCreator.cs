using UnityEngine;

/*
 * (Singleton)
 * 
 * This class reads the user's mouse inputs
 * to allow creation of wires between logic nodes
 */
public class WireCreator : MonoBehaviour {
    
    public static WireCreator instance;

    public bool straightLines;

    [SerializeField]
    private GameObject wirePrefab;

    public WireNode InputNode{set; get;}
    public WireNode OutputNode{set; get;}

    private GameObject wireObject;
    private Wire wireObjectComponent;

    public enum State {
        Inactive,
        Creating
    }

    public State CreatorState{get; set;}

    void Awake() {
        CreatorState = State.Inactive;

        if(instance != null) {
            Debug.LogWarning("Doubled singleton instantiation. " +
                "There should only be one WireCreator");
        }

        instance = this;

        CreatorState = State.Inactive;
    }


    // returns true when attachement is successful
    public bool AttachNode(WireNode node) {
        if(node.isInput && InputNode == null) {
            InputNode = node;
            WireObjectUpdateEnds();
            return true;
        }

        if(!node.isInput && OutputNode == null) {
            OutputNode = node;
            WireObjectUpdateEnds();
            return true;
        }

        return false;
    }

    private void WireObjectUpdateEnds() {
        CreatorState = State.Creating;

        // if a new wireObject is required, then create it
        if (wireObject == null) {
            wireObject = Instantiate(wirePrefab, transform);
            wireObjectComponent = wireObject.GetComponent<Wire>();
        }
        wireObjectComponent.InputNode = InputNode;
        wireObjectComponent.OutputNode = OutputNode;
    }

    // attempts to connect the existing wires. If the
    // connection fails, then it clears the current
    // creation data.
    public bool AttemptConnection() {
        if(InputNode == null || OutputNode == null) {
            Reset();
            return false;
        }



        if(!InputNode.SetInput(OutputNode, wireObject)) {
            Reset();
            return false;
        }

        InputNode = null;
        OutputNode = null;
        CreatorState = State.Inactive;
        wireObject = null;
        wireObjectComponent = null;
        return true;
    }

    public void Reset() {
        InputNode = null;
        OutputNode = null;
        CreatorState = State.Inactive;

        Destroy(wireObject);
        wireObject = null;
        wireObjectComponent = null;
    }
}
