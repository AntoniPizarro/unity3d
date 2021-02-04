using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserGUI : MonoBehaviour{
    public Player card;
    public Image crono;
    public Text cronoTime;
    private float[] time = new float[2];
    private float[] discount = new float[2];
    public float tax;
    public Button action;

    void Start(){
        time[0] = 10f;
        time[1] = time[0];
        discount[0] = 5f;
        discount[1] = 0f;
    }
    void Update(){
        crono.fillAmount = time[1] / time[0];
        cronoTime.text = ((int)time[1]).ToString();
        if (time[1] <= 0) {
            if(discount[1] <= 0){
                discount[1] = discount[0];
                card.setCredit(-tax);
            }
            discount[1] -= Time.deltaTime;
        }
        else{
            time[1] -= Time.deltaTime;
        }
    }
}
