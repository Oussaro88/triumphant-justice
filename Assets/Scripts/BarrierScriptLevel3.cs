using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierScriptLevel3 : MonoBehaviour
{
    //Référence aux sliders HP
    [SerializeField] private Slider groupe3Hp;
    [SerializeField] private Slider groupe3Hp1;
    [SerializeField] private Slider groupe3Hp2;
    [SerializeField] private Slider groupe3Hp3;
    [SerializeField] private Slider groupe3Hp4;
    [SerializeField] private Slider groupe3Hp5;
    [SerializeField] private Slider groupe3Hp6;
    [SerializeField] private Slider groupe3Hp7;
    [SerializeField] private Slider groupe3HpBoss;

    //Référence aux Colliders(Barrières)
    [SerializeField] private GameObject B3;

    // Update is called once per frame
    void Update()
    {
        if (groupe3Hp.value <= 0 && groupe3Hp1.value <= 0 && groupe3Hp2.value <= 0 && groupe3Hp3.value <= 0 && groupe3Hp4.value <= 0 && groupe3Hp5.value <= 0 && groupe3Hp6.value <= 0 && groupe3Hp7.value <= 0 && groupe3HpBoss.value <= 0)
        {
            B3.SetActive(false); //Enlève la barrière autour du trésor
        }
    }
}
