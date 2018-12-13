using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PaintTuning : NetworkBehaviour {
    //Agregando Red
    public const int numeroColorDefault = 20;
    [SyncVar(hook = "OnChangeColor")] public int numeroColorActual = numeroColorDefault;
    //Fin Agregando Red

    private int CarSelected;
	[Header ("Body Paint:")]
	public Texture[] Colors;
	public Material CarMaterial;   //Carro material
	[Header ("Neon Color:")]
	public Texture[] NeonColors;
	public Material NeonMaterial; //Piso suelo de color




    //__________________________GET CAR SELECTED__________________________________________________________________________________________
    public void SetCarSelected(int car){
		//get car selected
		CarSelected = car;
		//load and show the paint
		LoadPaint();
	}

	//__________________________LOAD VOID________________________________________________________________________________________________
	//load and apply all paint value on car
	public void LoadPaint(){
		//set paint on car
		CarMaterial.SetTexture ("_MainTex", Colors[PlayerPrefs.GetInt(CarSelected + "_BodyPaint",0)]);
		//set neon on car
		NeonMaterial.SetTexture ("_ShadowTex", NeonColors [PlayerPrefs.GetInt(CarSelected + "_NeonColor",0)]);
	}

	//__________________________UI VOIDS________________________________________________________________________________________________
	//set body paint by UI
	public void SetPaint(int paint){
        //Debug.Log("Clickeando");

        //Se le indica al  servidor que debe variar el color
        if (!isServer)
        {
            return;
        }
        Debug.Log("Clickeando");
        //Aqui deberia cambiar la variable sincronizada y hacer efecto en la red
        numeroColorActual = paint; //Le paso el numero 6 por ejemplo de acuerdo al color en la lista
        Debug.Log(numeroColorActual);
    }
    //__________________________FUNCION SINCRONIZADA________________________________________________________________________________________________

    void OnChangeColor(int numeroColor)
    {
        CarMaterial.SetTexture("_MainTex", Colors[numeroColor]);
        //save the paint color
        PlayerPrefs.SetInt(CarSelected + "_BodyPaint", numeroColor);
    }


    //set neon paint by UI
    public void SetNeonPaint(int neon){
		//set neon on car
		NeonMaterial.SetTexture ("_ShadowTex", NeonColors [neon]);
		//save the neon color
		PlayerPrefs.SetInt(CarSelected + "_NeonColor",neon);
	}
}
