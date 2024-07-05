using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaSumaDeRotacion : MonoBehaviour
{
    [SerializeField] Transform Padre; 
    [SerializeField] Transform HijoI; 
    [SerializeField] Transform HijoD;
    [SerializeField] Transform Hijo3;
    [SerializeField] float velocidad;
    [SerializeField] UDPSendTest LosValores;
    Quaternion quaternionHijoI;
    Quaternion quaternionHijoD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {/*
        Vector3 V = Padre.rotation.eulerAngles;
        //V.z = LosValores.sliderA.value / 250f * 100 - 50;
        LosValores.sliderA.value = V.z + 50/100 *250;
        print("Z "+ V.z + 50 / 100 * 250);
        LosValores.sliderB.value = V.x + 50/100 *250;
        print("X "+V.x + 50 / 100 * 250);
        //V.x = LosValores.sliderB.value / 250f * 100 - 50;
        LosValores.sliderC.value = 250 - LosValores.sliderB.value;
        //Padre.rotation = Quaternion.Euler(V);
        /*
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 V = Padre.rotation.eulerAngles;
            V.x += velocidad * Time.deltaTime;
            Padre.rotation = Quaternion.Euler(V);

        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 V = Padre.rotation.eulerAngles;
            V.x -= velocidad * Time.deltaTime;
            Padre.rotation = Quaternion.Euler(V);

        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 V = Padre.rotation.eulerAngles;
            V.z += velocidad * Time.deltaTime;
            Padre.rotation = Quaternion.Euler(V);

        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 V = Padre.rotation.eulerAngles;
            V.z -= velocidad * Time.deltaTime;
            Padre.rotation = Quaternion.Euler(V);

        }
        */
        quaternionHijoI = HijoI.rotation;
        quaternionHijoD = HijoD.rotation;

        Vector3 x = Padre.rotation.eulerAngles;
        //pone un limite en la rotacion del eje x de 50 a -50
        x.x = x.x <= 180 && x.x >= 50 ?  50 : x.x >= 180 && x.x <= 310 ? 310 : x.x ;
        //pone un limite en la rotacion del eje z de 50 a -50
        x.z = x.z <= 180 && x.z >= 50 ?  50 : x.z >= 180 && x.z <= 310 ? 310 : x.z ;

        //Padre.rotation = Padre.rotation.eulerAngles != x ? Quaternion.Euler(x) : Padre.rotation;
        
        HijoI.rotation = Quaternion.Euler(new Vector3(0, 0, x.x));
        HijoD.rotation = Quaternion.Euler(new Vector3(0, 0, x.x));
        Hijo3.rotation = Quaternion.Euler(new Vector3(-x.z, 0, 0));

        LosValores.sliderA.value = x.z <= 50 ? (x.z + 50) / 100 * 250 : x.z >= 310 ? (x.z - 310) / 100 * 250 : LosValores.sliderA.value;
        LosValores.sliderB.value = x.x <= 50 ? (x.x + 50) / 100 * 250 : x.x >= 310 ? (x.x - 310) / 100 * 250 : LosValores.sliderB.value;
        LosValores.sliderC.value = 250 - LosValores.sliderB.value;
        /*
        LosValores.sliderA.value = (x.z + 50) / 100 * 250;
        print("Z " + (x.z + 50) / 100 * 250);
        LosValores.sliderB.value = (x.x + 50) / 100 * 250;
        print("X " + (x.x + 50) / 100 * 250);
        */
    }
}
