using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierScriptLevel2 : MonoBehaviour
{
    //Référence aux sliders HP
    [SerializeField] private Slider groupe2Hp;
    [SerializeField] private Slider groupe2Hp1;
    [SerializeField] private Slider groupe2Hp2;
    [SerializeField] private Slider groupe2Hp3;
    [SerializeField] private Slider groupe2Hp4;
    [SerializeField] private Slider groupe2Hp5;
    [SerializeField] private Slider groupe2HpBoss;

    //Référence aux Colliders(Barrières)
    [SerializeField] private GameObject B2;

    // Update is called once per frame
    void Update()
    {
        if (groupe2Hp.value <= 0 && groupe2Hp1.value <= 0 && groupe2Hp2.value <= 0 && groupe2Hp3.value <= 0 && groupe2Hp4.value <= 0 && groupe2Hp5.value <= 0 && groupe2HpBoss.value <= 0)
        {
            B2.SetActive(false); //Enlève la barrière autour du trésor
        }
    }
}
