using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interfaz : MonoBehaviour{
    public Station station;
    public Player card;
    public InputField portNum;
    public Text output;
    public Text credit;
    public Text cardID;

    void Start(){

    }
    void Update(){
        if(cardID != null){
            cardID.text = "ID de la targeta: " + card.getID();
            credit.text = "Credit de la targeta: " + card.getCredit().ToString() + "€";
        }
        else{
            cardID.text = "ID de la targeta: N/A";
            credit.text = "Credit de la targeta: N/A";
        }
    }
    public void getInfo(){
        var info = station.getInfo();
        output.text = "ID de l'estació: " + info.Item1.ToString() + "\nDirecció: " + info.Item2 + "\nNombre de ports: " + info.Item3.ToString();
    }
    public void getFreePorts(){
        output.text = "Ports lliures: " + station.getFreePorts().ToString();
    }
    public void doRetireBike(){
        station.card = card;
        station.removeBike();
    }
}
