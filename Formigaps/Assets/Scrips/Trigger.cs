using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    private testRotMov[] objetos3D;
    private GameObject[] objetos3DGO;
    private GameObject player;
    // Start is called before the first frame update

    void Start(){
    
        player = GameObject.Find("Player");
        
    }

    void OnTriggerStay(Collider other)
    {
            if (other.CompareTag("Player")){
                 player.GetComponent<Player>().canMove3D = true;
                 
            //faz a ação
        }
          
   }
    void OnTriggerExit(Collider other)
    {
            if (other.CompareTag("Player")){
                 player.GetComponent<Player>().canMove3D = false;
                 UnityEngine.Debug.Log("Mover3D");
            //faz a ação
        }
           
          
   }
}

