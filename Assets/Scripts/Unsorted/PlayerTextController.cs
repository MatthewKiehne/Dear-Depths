using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]

public class PlayerTextController : MonoBehaviour {

    private TMP_Text textPro;
    private float timeTillFade = 0f;
    private float timePassed = 0f;
    private float fadeTime = 1f;

    private void Start() {
        this.textPro = this.GetComponent<TMP_Text>();
    }

    private void Update() {

        if(timePassed < timeTillFade) {
            timePassed += Time.deltaTime;
        } else if(timePassed < timeTillFade + fadeTime) {
            timePassed += Time.deltaTime;
            textPro.color = new Color(1, 1, 1, textPro.color.a - (Time.deltaTime / fadeTime));

            if(timePassed > timeTillFade + fadeTime) {
                this.textPro.color = new Color(0, 0, 0, 0);
            }
        } 
    }

    public void setText(string text) {

        this.textPro.overrideColorTags = true;

        this.textPro.text = text;
        this.textPro.color = new Color32(255, 255, 255, 255);

        this.timeTillFade = .15f * text.Length;
        this.timePassed = 0f;
    }
}
