using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionRaycaster : MonoBehaviour {

    [SerializeField]
    private Transform cameraTrans;

    [SerializeField]
    private DotsManager dotManager;

    [SerializeField]
    private LayerMask ground;

    private Random rand = new Random();

    private float dotsPerSecond = 500;

    public void Update() {

        if (Input.GetKey(KeyCode.Mouse0)) {

            this.castVision();

        } else if (Input.GetKeyDown(KeyCode.Mouse1)) {
            dotManager.clearVision();
        }
    }

    private void castVision() {

        if (this.dotManager.canMakeDots()) {
            
            //gets the number of dots
            int numShots = (int)(Time.deltaTime * this.dotsPerSecond);
            
            if(this.dotManager.DotCounter + numShots > this.dotManager.MaxDots) {
                numShots = this.dotManager.MaxDots - this.dotManager.DotCounter;
            }
            
            for (int i = 0; i < numShots; i++) {
                Vector3 fireDirection = this.transform.forward;
                Quaternion fireRotation = Quaternion.LookRotation(fireDirection);
                Quaternion randomRotation = Random.rotation;

                fireRotation = Quaternion.RotateTowards(fireRotation, randomRotation, Random.Range(0f, 15f));

                Vector3 direction = Random.insideUnitCircle;
                direction = transform.TransformDirection(direction);

                Ray ray = new Ray(this.transform.position, fireRotation * Vector3.forward);

                RaycastHit hit;
                Physics.Raycast(ray, out hit, Mathf.Infinity, this.ground);

                if (hit.collider &&
                    Vector3.Distance(hit.point, this.transform.position) > .5f) {

                    this.dotManager.makeDot(hit.point, hit.transform.tag);
                } 
            }
        }
    }
}
