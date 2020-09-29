using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffAllRenderers : MonoBehaviour {

    private void Awake() {

        Renderer[] rends = UnityEngine.Object.FindObjectsOfType<Renderer>();
        foreach(Renderer ren in rends) {
            ren.enabled = false;
        }
    }
}
