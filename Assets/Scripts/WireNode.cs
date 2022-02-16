using UnityEngine;
using UnityEngine.EventSystems;
using LogicGateNodes;

public class WireNode : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    private LogicNode logicNode;
    private LogicNodeBehaviour logicMonoBehaviourComponent;

    [SerializeField]
    private bool _isInput;
    public bool isInput {
        get { return _isInput; }
    }

    void Awake() {
        logicMonoBehaviourComponent = transform.GetComponentInParent<LogicNodeBehaviour>();
        logicNode = logicMonoBehaviourComponent?.Node;
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
}