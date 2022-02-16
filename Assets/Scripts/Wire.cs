using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour {

    [SerializeField]
    private Color activeColor;

    [SerializeField]
    private Color inactiveColor;

    public WireNode InputNode;
    public WireNode OutputNode;

    private LineRenderer line;


    // cache LineRenderer component
    void Awake() {
        line = gameObject.GetComponent<LineRenderer>();
    }

    // update the line's endpoints to be at the nodes
    void Update() {
        if(InputNode != null || OutputNode != null) {
            line.enabled = true;
            Vector3[] positions = new Vector3[2];

            if(InputNode != null) {
                positions[0] = InputNode.transform.position;
            }
            else {
                positions[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if(OutputNode != null) {
                positions[1] = OutputNode.transform.position;
            }
            else {
                positions[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            positions[0].z = 0;
            positions[1].z = 0;

            line.SetPositions(positions);
        }
        else {
            line.enabled = false;
        }
    }
}
