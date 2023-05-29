using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class mov2d : MonoBehaviour
{
    private bool estaMovendo = false;
    private Vector3 offset;

    private void OnMouseDown()
    {
        // Calcular o deslocamento inicial entre o objeto e o ponto onde o mouse clicou
        offset = transform.position - GetMouseWorldPosition();
        estaMovendo = true;
    }

    private void OnMouseUp()
    {
        estaMovendo = false;
    }

    private void Update()
    {
        if (estaMovendo)
        {
            // Atualizar a posição do objeto com base no movimento do mouse
            transform.position = GetMouseWorldPosition() + offset;
        }
    }

    private Vector3 GetMouseWorldPosition()
    {
        // Converter a posição do mouse para o mundo 2D
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePos);
    }
}

