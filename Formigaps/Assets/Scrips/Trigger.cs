using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    private testRotMov[] objetos3D;
    // Start is called before the first frame update
    void Start()
    {
        objetos3D = FindObjectsOfType<testRotMov>(); 
        for(int i =0; i < objetos3D.Length; i++){
            objetos3D[i].SetCanMoving(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
