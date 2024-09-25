using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCamFinish : MonoBehaviour
{

    [SerializeField] private GameObject finish;





    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Horse"))
        {
            CameraCotroller.Instance.target = finish;
            CameraCotroller.Instance.MoveCamera(new Vector3(130,15,0), 0.2f);
        }
    }
}
