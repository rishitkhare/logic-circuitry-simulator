using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IDragHandler {
    public void OnDrag(PointerEventData eventData) {
        Vector3 screenSpace = Camera.main.WorldToScreenPoint(transform.position);

        screenSpace += (Vector3) eventData.delta;

        Vector3 worldSpace = Camera.main.ScreenToWorldPoint(screenSpace);
        worldSpace.z = 0;

        transform.position = worldSpace;
    }
}
