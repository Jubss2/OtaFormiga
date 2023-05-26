using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRotMov : MonoBehaviour
{
    private bool isRotating = false;
    private bool isMoving = false;
    private Vector3 offset;

    private bool CanMove;

    private void Update()
    {
        if(!CanMove)
        return;
        // Verificar o clique direito para rotacionar
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        // Verificar o clique esquerdo para mover
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            offset = transform.position - GetMouseWorldPosition();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        // Rotacionar o objeto
        if (isRotating)
        {
            float rotationSpeed = 500f;
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            transform.Rotate(Vector3.up, -mouseX, Space.World);
            transform.Rotate(Vector3.right, mouseY, Space.Self);
        }

        // Mover o objeto
        if (isMoving)
        {
            Vector3 targetPosition = GetMouseWorldPosition() + offset;
            targetPosition.z = transform.position.z; // Manter o valor atual do eixo Z

            transform.position = targetPosition;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.point;
        }
        return Vector3.zero;
    }

     public void SetCanMoving(bool Move){
            CanMove = Move;
        
    }
}
