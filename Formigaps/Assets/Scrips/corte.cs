using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class corte : MonoBehaviour
{
    public Tilemap tilemap;
    public BoxCollider blocoCollider;

    private void Update()
    {
        // Verificar se o bloco está em movimento (por exemplo, através da entrada do jogador)
        if (Input.GetKey(KeyCode.A))
        {
            // Obter a área de colisão do bloco em coordenadas do mundo
            Bounds bounds = blocoCollider.bounds;

            // Detectar os colisores do Tilemap de "grama alta" dentro da área de colisão
            Collider2D[] colliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0f);

            // Remover os tiles da área de colisão
            foreach (Collider2D collider in colliders)
            {
                Tilemap tilemapGramaAlta = collider.GetComponent<Tilemap>();
                if (tilemapGramaAlta != null)
                {
                    // Obter a posição do tile em coordenadas do mundo
                    Vector3Int tilePosition = tilemapGramaAlta.WorldToCell(collider.transform.position);

                    // Remover o tile da posição atual
                    tilemapGramaAlta.SetTile(tilePosition, null);
                }
            }
        }
    }
}
