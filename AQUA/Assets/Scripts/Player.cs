using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    public float velocity;
    public float rotting;
    public Bicycle bicycle;
    public bool ridding;
    public string cardID;
    public bool cardActived;
    public float credit;
    public Interfaz interfaz;
    public UserGUI gui;

    void Start(){
        changeGUI();
        gui.action.gameObject.SetActive(false);
        bicycle.gameObject.SetActive(false);
        ridding = false;
    }
    void Update(){
        if (Input.GetKey("w")){
            transform.Translate(0, 0, velocity * Time.deltaTime);
        }
        if (Input.GetKey("s")){
            transform.Translate(0, 0, -velocity * Time.deltaTime);
        }
        if (Input.GetKey("a")){
            transform.Rotate(0, -rotting * Time.deltaTime, 0);
        }
        if (Input.GetKey("d")){
            transform.Rotate(0, rotting * Time.deltaTime, 0);
        }
        if (Input.GetKeyDown("e")){
            switch (ridding){
                case true:
                    ridding = false;
                    break;
                case false:
                    ridding = true;
                    break;
            }
        }
        if (ridding == true){
            bicycle.gameObject.SetActive(true);
        }
        else{
            bicycle.gameObject.SetActive(false);
        }
    }
    public void setBicycle(Bicycle bike){
        bicycle = bike;
    }
    public bool isActived(){
        return cardActived;
    }
    public float getCredit(){
        return credit;
    }
    public string getID(){
        return cardID;
    }
    public void setCredit(float tax){
        credit += tax;
    }
    public void changeInterfaz(){
        interfaz.gameObject.SetActive(true);
        gui.gameObject.SetActive(false);
    }
    public void changeGUI(){
        interfaz.gameObject.SetActive(false);
        interfaz.cardID.text = "ID de la targeta: N/A";
        interfaz.credit.text = "Credit de la targeta: N/A";
        gui.gameObject.SetActive(true);
    }
    private void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "Estacion"){
            gui.action.gameObject.SetActive(true);
            if (ridding == false){
                interfaz.station = other.gameObject.GetComponent<Station>();
            }
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag == "Estacion"){
            gui.action.gameObject.SetActive(false);
            interfaz.station = null;
        }
    }
}
