using UnityEngine;
using UnityEngine.EventSystems;
using LogicGateNodes;

public class WireNode : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    private LogicNode logicNode;
    private LogicNodeBehavior logicMonoBehaviourComponent;

    private GameObject blinker;

    [SerializeField]
    private bool _isInput;
    public bool isInput {
        get { return _isInput; }
    }

    void Start() {
        logicMonoBehaviourComponent = transform.parent.GetComponent<LogicNodeBehavior>();
        logicNode = logicMonoBehaviourComponent?.Node;

        blinker = transform.Find("Power").gameObject;

        if(logicNode == null) {
            Debug.LogWarning("No gate component attached! (" + GetPath(gameObject) + ")");
        }
    }

    private string GetPath(GameObject obj) {
        string path = "/" + obj.name;
        while (obj.transform.parent != null) {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }
        return path;
    }

    public void OnDrag(PointerEventData eventData) {}

    public void OnBeginDrag(PointerEventData eventData) {
        WireCreator.instance.AttachNode(this);
    }

    public void OnEndDrag(PointerEventData eventData) {
        bool successfulDrag = false;

        foreach(GameObject obj in eventData.hovered) {
            WireNode component = obj.GetComponent<WireNode>();

            if(component != null) {
                WireCreator.instance.AttachNode(component);
                successfulDrag = true;
                break;
            }
        }

        if(!successfulDrag) {
            WireCreator.instance.Reset();
        }
        else {
            WireCreator.instance.AttemptConnection();
        }
    }

    public void SetInput(WireNode other) {
        if(!_isInput) {
            Debug.LogWarning("Tried to set an input from an output");
        }
        else {
            logicMonoBehaviourComponent.SetInput(0, other.logicMonoBehaviourComponent);
        }
    }

    public bool? GetOutput() {
        return logicMonoBehaviourComponent.Node.GetOutput();
    }

    public void SetBlinker(bool set) {
        blinker.SetActive(set);
    }
}