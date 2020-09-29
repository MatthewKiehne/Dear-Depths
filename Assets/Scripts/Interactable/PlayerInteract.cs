using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]

public class PlayerInteract : MonoBehaviour {

    private Camera cam;
    private float maxDistance = 5f;

    private void Start() {
        this.cam = this.GetComponent<Camera>();
    }


    public void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {

            Ray ray = new Ray(this.cam.transform.position, this.cam.transform.forward);

            RaycastHit hit;
            Physics.Raycast(ray, out hit, Mathf.Infinity);
            Physics.Raycast(ray, out hit, Mathf.Infinity);

            if(hit.collider != null && Vector3.Distance(hit.point, this.transform.position) < this.maxDistance) {

                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if(interactable != null) {
                    interactable.interact();
                } 
            }
        }
    }
}
