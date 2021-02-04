using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour{
    public int id;
    public string direction;
    public int ports;
    public Bicycle[] bicycles;
    public Player card;

    void Start(){
        
    }
    void Update(){
        
    }
    public (int, string, int) getInfo(){
        return (id, direction, ports);
    }
    public int getFreePorts(){
        int free = 0;
        int used = 0;
        foreach(Bicycle bike in bicycles){
            if(bike != null){
                used++;
            }
        }
        free = ports - used;
        return free;
    }
    public List<int> getIDsBicylces(){
        List<int> ids = new List<int>();
        foreach (Bicycle bike in bicycles){
            if (bike != null){
                ids.Add(bike.getID());
            }
            else{
                ids.Add(-1);
            }
        }
        return ids;
    }
    public void addBike(Bicycle bicycle){
        int port = 0;
        for (int a = 0; a <= bicycles.Length; a++){
            if(bicycles[a] == null){
                bicycles[a] = bicycle;
                port = a++;
                break;
            }
        }
        getPort(bicycle, port);
    }
    public (string, string) getPort(Bicycle Bike, int port){
        string idBike = Bike.getID().ToString();
        string portBike = port.ToString();
        return (idBike, portBike);
    }
    public void cardIntroduced(Player cardIntroduced){
        card = cardIntroduced;
    }
    public void cardRetired(){
        card = null;
    }
    public bool checkCard(Player card){
        bool isCard = false;
        if(card.isActived() == true){
            isCard = true;
        }
        return isCard;
    }
    public object removeBike(){
        if(checkCard(card) == true){
            int randomBike = 0;
            while(bicycles[randomBike] == null){
                randomBike = Random.Range(0, bicycles.Length);
            }
            card.setBicycle(bicycles[randomBike]);
            (string, string) bike = getPort(bicycles[randomBike], randomBike + 1);
            bicycles[randomBike] = null;
            return bike;
        }
        else{
            return false;
        }
    }
    public bool coupleBike(Bicycle bike, int port){
        if(bicycles[port - 1] != null){
            bicycles[port - 1] = bike;
            return true;
        }
        else{
            return false;
        }
    }
}