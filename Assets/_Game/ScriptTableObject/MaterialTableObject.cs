using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HorseMaterial")]
public class MaterialTableObject : ScriptableObject
{
    [SerializeField] private Material[] bodys;
    [SerializeField] private Material[] manes;
    [SerializeField] private Material[] eyes;



    public Material GetRandomMatBody()
    {
        Debug.Log("Lay mau body");
        //return bodys[Random.Range(0, bodys.Length)];
        return bodys[Random.Range(0, bodys.Length)];

    }
    public Material GetRandomMatEye()
    {
        return eyes[Random.Range(0, eyes.Length)];
    }
    public Material GetRandomMatMane()
    {
        return manes[Random.Range(0, manes.Length)];
    }
}
