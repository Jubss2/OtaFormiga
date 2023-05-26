using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset =1f;
    public Transform target;
    public Camera camera;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x,target.position.y + yOffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FollowSpeed*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.E)){
            camera.orthographicSize = 10f;

        }
        if(Input.GetKeyDown(KeyCode.R)){
            camera.orthographicSize = 5f;

        }
    }

    void Start(){
        camera = GetComponent<Camera>();


    }
}
