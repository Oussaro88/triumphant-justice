using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarrierScript : MonoBehaviour
{
    //Référence aux sliders HP
    [SerializeField] private Slider groupe1Hp;
    [SerializeField] private Slider groupe1Hp1;
    [SerializeField] private Slider groupe1Hp2;
    [SerializeField] private Slider groupe1Hp3;
    [SerializeField] private Slider groupe1HpBoss;
    [SerializeField] private Slider groupe2Hp;
    [SerializeField] private Slider groupe2Hp1;
    [SerializeField] private Slider groupe2Hp2;
    [SerializeField] private Slider groupe2Hp3;
    [SerializeField] private Slider groupe2HpBoss;
    [SerializeField] private Slider groupe3Hp;
    [SerializeField] private Slider groupe3Hp1;
    [SerializeField] private Slider groupe3Hp2;
    [SerializeField] private Slider groupe3Hp3;
    [SerializeField] private Slider groupe3HpBoss;


    //Référence aux Colliders(Barrières)
    [SerializeField] private GameObject B1;
    [SerializeField] private GameObject B2;
    [SerializeField] private GameObject B3;

    // Update is called once per frame
    void Update()
    {
        //Barrière N1
        if(groupe1Hp.value <= 0 && groupe1Hp1.value <= 0 && groupe1Hp2.value <= 0 && groupe1Hp3.value <= 0 && groupe1HpBoss.value <= 0)
        {
            B1.SetActive(false); //Enlève la barrière
        }

        //Barrière N2
        if (groupe2Hp.value <= 0 && groupe2Hp1.value <= 0 && groupe2Hp2.value <= 0 && groupe2Hp3.value <= 0 && groupe2HpBoss.value <= 0)
        {
            B2.SetActive(false); //Enlève la barrière
        }

        //Barrière N3
        if (groupe3Hp.value <= 0 && groupe3Hp1.value <= 0 && groupe3Hp2.value <= 0 && groupe3Hp3.value <= 0 && groupe3HpBoss.value <= 0)
        {
            B3.SetActive(false); //Enlève la barrière
        }

    }
}
