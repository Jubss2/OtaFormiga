using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novoRotMov : MonoBehaviour
{
    private bool isRotating = false;
    private bool isMoving = false;
    private Vector3 offset;
    private Vector3 lastPosition;

    private void Update()
    {
        // Verificar o clique direito para rotacionar
        if (Input.GetMouseButtonDown(1))
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRotating = false;
        }

        // Verificar o clique esquerdo para mover
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            offset = transform.position - GetMouseWorldPosition();
        }
        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        // Rotacionar o objeto
        if (isRotating)
        {
            float rotationSpeed = 500f;
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Rotacionar nos eixos Y e Z
            transform.Rotate(Vector3.up, -mouseX, Space.World);
            transform.Rotate(Vector3.forward, mouseY, Space.World);
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
            lastPosition = hit.point;
            return hit.point;
        }
        return lastPosition;
        
    }
}
