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
            // The wire is completed
            line.enabled = true;

            if(WireCreator.instance.straightLines) {
                DrawSingleLineWires();
            }
            else {
                DrawBlockWires();
            }
        }
        else {
            // the wire does not have any connections
            line.enabled = false;
        }


        UpdateColor();
    }

    // turn off all blinkers once the wire is destroyed
    void OnDestroy() {
        if (InputNode != null) {
            InputNode.SetBlinker(false);
        }

        if (OutputNode != null) {
            OutputNode.SetBlinker(false);
        }
    }

    private void UpdateColor() {
        if(OutputNode != null) {
            bool? nodeValue = OutputNode.GetOutput();

            

            if(nodeValue == null || nodeValue == false) {
                line.startColor = inactiveColor;
                line.endColor = inactiveColor;

                OutputNode.SetBlinker(false);
                if (InputNode != null) {
                    InputNode.SetBlinker(false);
                }
            }
            else {
                line.startColor = activeColor;
                line.endColor = activeColor;

                OutputNode.SetBlinker(true);
                if(InputNode != null){
                    InputNode.SetBlinker(true);
                }
            }
        }
    }

    // draws in a path created from vertical and horizontal wires
    private void DrawBlockWires() {
        Vector3[] positions = new Vector3[4];
        line.positionCount = 4;

        if (InputNode != null) {
            positions[0] = InputNode.transform.position;
        }
        else {
            positions[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        positions[0].z = 0;

        if (OutputNode != null) {
            positions[positions.Length - 1] = OutputNode.transform.position;
        }
        else {
            positions[positions.Length - 1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        positions[3].z = 0;

        float factor = 0.5f;

        if (InputNode != null && OutputNode != null) {
            float outputY = InputNode.transform.position.y - OutputNode.transform.position.y;
            float sizeY = Camera.main.orthographicSize;

            factor = 0.25f + (Mathf.Abs(outputY) / (2 * sizeY));
        }

        float midX = positions[3].x + ((positions[0].x - positions[3].x) * factor);

        positions[1] = new Vector3(midX, positions[0].y, 0);
        positions[2] = new Vector3(midX, positions[3].y, 0);


        line.SetPositions(positions);
    }


    // draws a single line from one node to other
    private void DrawSingleLineWires() {
        Vector3[] positions = new Vector3[2];
        line.positionCount = 2;

        if (InputNode != null) {
            positions[0] = InputNode.transform.position;
        }
        else {
            positions[0] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        positions[0].z = 0;

        if (OutputNode != null) {
            positions[1] = OutputNode.transform.position;
        }
        else {
            positions[1] = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        positions[1].z = 0;


        line.SetPositions(positions);
    }
}
