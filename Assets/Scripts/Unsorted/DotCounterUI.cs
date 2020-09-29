using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]

public class DotCounterUI : MonoBehaviour {

    [SerializeField]
    private DotsManager dotManager;

    private Text textUI;

    private void Start() {
        this.textUI = this.GetComponent<Text>();
    }

    public void Update() {
        this.textUI.text = String.Format("{0:n0}", dotManager.DotCounter);
    }
}
