using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KureManager : MonoBehaviour
{
    public GameObject kure;
    public GameObject cizgi;
    GameObject[] silinen;
    Vector3 konum;
    Vector3 scale;
    public float buyukluk;
    public float tekrar;
    public float minx;
    public float maxx;

    void Start()
    {

    }

    void Update()
    {
        konum = kure.transform.position;
        kure.transform.position = new Vector3(Mathf.Clamp(Mathf.Sin(Time.time/2f)*tekrar*2f,minx,maxx), Mathf.Sin(Time.time*tekrar)*buyukluk*1.1f, konum.z);
        #region Renk
        if (konum.y >= buyukluk)
        {
            kure.GetComponent<MeshRenderer>().material.color = Color.blue;
        }
        else if (konum.y <= buyukluk)
        {
            kure.GetComponent<MeshRenderer>().material.color = Color.grey;
        }
        if (konum.y >=-0.5 && konum.y<=0.5)
        {
            kure.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        if (konum.y <= -buyukluk)
        {
            kure.GetComponent<MeshRenderer>().material.color = Color.red;
        }
        #endregion
        #region Çizgi

        Invoke("Create", Time.time);
   
        #endregion
    }

    void Create()
    {
        GameObject yenicizgi = Instantiate(cizgi, konum, Quaternion.Euler(new Vector3(0, 0, 0)));
        silinen = GameObject.FindGameObjectsWithTag("cizgi");
        for (int i = 0; i < silinen.Length; i++)
        {
            silinen[i].GetComponent<MeshRenderer>().material.color = kure.GetComponent<MeshRenderer>().material.color;
        }
        Destroy(yenicizgi, 2);  
    }
}
