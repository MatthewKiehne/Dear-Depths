using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayText : MonoBehaviour, Interactable {

    [SerializeField]
    private string textDisplayed;
    private PlayerTextController playerText;

    private void Start() {
        this.playerText = GameObject.Find("PlayerTextWithAVeryLongName").GetComponent<PlayerTextController>();
    }


    public void exit() {
        throw new System.NotImplementedException();
    }

    public void interact() {
        this.playerText.setText(this.textDisplayed);
    }
}
