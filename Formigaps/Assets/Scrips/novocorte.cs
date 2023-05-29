using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class novocorte : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tileApagado;

    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificar se a colis�o ocorreu com o Tilemap
        if (collision.gameObject.CompareTag("Tilemap"))
        {
            // Obter a posi��o de colis�o no Tilemap
            Vector3Int cellPosition = tilemap.WorldToCell(collision.transform.position);

            // Remover o tile na posi��o de colis�o
            tilemap.SetTile(cellPosition, tileApagado);
        }
    }

    private void Update()
    {
        // Movimentar o bloco usando as setas do teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f);
        transform.position += movement * Time.deltaTime;

        // Resetar a posi��o do bloco quando a tecla R for pressionada
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = initialPosition;
        }
    }
}
