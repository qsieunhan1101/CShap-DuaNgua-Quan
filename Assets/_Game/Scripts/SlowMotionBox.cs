using System.Collections;
using UnityEngine;

public class SlowMotionBox : MonoBehaviour
{

    [SerializeField] private GameObject finish;
    [SerializeField] Vector3 newOffSet = new Vector3(130, 15, 0);
    [SerializeField] float newSmooth = 0.2f;

    [SerializeField] private bool isSetFinishCam = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Horse"))
        {
            if (isSetFinishCam == false)
            {
                isSetFinishCam = true;
                Time.timeScale = 0.2f;
                Time.fixedDeltaTime = Time.timeScale * 0.02f;
                CameraCotroller.Instance.target = finish;
                CameraCotroller.Instance.MoveCamera(newOffSet, newSmooth);
                StartCoroutine(ResetTimScale());
            }
        }
    }

    private IEnumerator ResetTimScale()
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = 0.02f;
    }
}
