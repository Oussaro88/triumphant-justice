using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{
    public Transform player;

    void Update() //called after update or fixed Update
    {
        Vector3 newPosition = player.position; //Position du joueur
        newPosition.y = transform.position.y; //position Y prendra la valeur de la position de la MinimapCamera
        transform.position = newPosition; //la position de la camera prendra les valeurs déjà attribuées à là valeur newPosition

    }
}
