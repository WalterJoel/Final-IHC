using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class HealthCar :  NetworkBehaviour
{
    public const string colorDefault = "Rojo";
    //Al estar enganchados, el valor de current health se pasa a la funcion onchange cada vez que cambia 
    //por eso deben ser del mismo tipo int ESTA FUNCION SE INVOCA EN EL SERVIDOR Y EN TODOS LOS CLIENTES
    [SyncVar(hook = "OnChangeColor")] public string colorActual = colorDefault;

    public void pintarObjeto(string nombreColor)
    {
        //Se le indica al  servidor que debe variar el color
        if (!isServer)
        {
            return;
        }
        colorActual = nombreColor;
    }
    void OnChangeColor(string color)
    {
        if (color == "Rojo")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }

    }
}
