using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierScriptLevel1 : MonoBehaviour
{
    //Référence aux sliders HP
    [SerializeField] private Slider groupe1Hp;
    [SerializeField] private Slider groupe1Hp1;
    [SerializeField] private Slider groupe1Hp2;
    [SerializeField] private Slider groupe1Hp3;
    [SerializeField] private Slider groupe1Hp4;
    [SerializeField] private Slider groupe1HpBoss;

    //Référence aux Colliders(Barrières)
    [SerializeField] private GameObject B1;

    // Update is called once per frame
    void Update()
    {
        if (groupe1Hp.value <= 0 && groupe1Hp1.value <= 0 && groupe1Hp2.value <= 0 && groupe1Hp3.value <= 0 && groupe1Hp4.value <= 0 && groupe1HpBoss.value <= 0)
        {
            B1.SetActive(false); //Enlève la barrière autour du trésor
        }
    }
}
