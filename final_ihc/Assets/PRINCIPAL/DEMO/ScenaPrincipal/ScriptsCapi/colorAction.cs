using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class colorAction : NetworkBehaviour {
    public GameObject modifico_este_color;
    private GameObject modifico_Este_color;
    // Use this for initialization
    void Start()
    {
        modifico_Este_color = GameObject.Find(modifico_este_color.name + "(Clone)");
    }

    void OnMouseDown()
    {
        //objneedshow.SetActive(true);
        PaintTuning health = modifico_Este_color.GetComponent<PaintTuning>();
        if (health != null)
        {
            Debug.Log("entro AL OTRO SCRIPT");
            //health.TakeDamage (10);
            var randomInt = Random.Range(1, 6);
            Debug.Log(randomInt);
            health.SetPaint(randomInt); //Le paso 6 que es distinto al otro
                                        //Le paso el color y el identificador de GameObject para que modifique este enemigo
                                        //string color = "Blue";
                                        //health.pintarObjeto(color);
        }
    }
    /*private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("entro");
            GameObject modifico_Este_color = GameObject.Find(modifico_este_color.name + "(Clone)");
            PaintTuning health = modifico_Este_color.GetComponent<PaintTuning>();
            if (health != null)
            {
                Debug.Log("entro AL OTRO SCRIPT");
                //health.TakeDamage (10);
                var randomInt = Random.Range(1,6);
                health.SetPaint(randomInt); //Le paso 6 que es distinto al otro
                                            //Le paso el color y el identificador de GameObject para que modifique este enemigo
                                            //string color = "Blue";
                                            //health.pintarObjeto(color);
            }
        }
    }*/
    /*public void capi(){
        Debug.Log("entro");
        GameObject modifico_Este_color = GameObject.Find(modifico_este_color.name + "(Clone)");
        PaintTuning health = modifico_Este_color.GetComponent<PaintTuning>();
        if (health != null)
        {
            Debug.Log("entro");
            //health.TakeDamage (10);
            var randomInt = Random.Range(1, 6);
            health.SetPaint(randomInt); //Le paso 6 que es distinto al otro
                                        //Le paso el color y el identificador de GameObject para que modifique este enemigo
                                        //string color = "Blue";
                                        //health.pintarObjeto(color);
        }
    }*/

}
