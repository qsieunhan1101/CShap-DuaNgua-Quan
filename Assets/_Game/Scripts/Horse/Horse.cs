using TMPro;
using UnityEditor;
using UnityEngine;

public class Horse : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 lastPosition;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed = 100;

    [SerializeField] private Transform canvasName;
    [SerializeField] private TextMeshProUGUI textHorseName;

    [SerializeField] private SkinnedMeshRenderer horseSkinMesh;

    private Quaternion canvasNameOrinRotation;


    public Material testMat;

    private void Start()
    {
        lastPosition = transform.position;
        speed = maxSpeed / 1.50f;

        canvasNameOrinRotation = canvasName.rotation;

        SetHorseColor();

    }

    private void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * Vector3.forward.z);



        if (Vector3.Distance(transform.position, lastPosition) >= 100.0f)
        {
            lastPosition = transform.position;
            speed = Random.Range(maxSpeed - 30, maxSpeed + 1);
        }
    }
    private void LateUpdate()
    {
        canvasName.rotation = CameraCotroller.Instance.transform.rotation * canvasNameOrinRotation;
    }

    private void SetHorseColor()
    {
        Material[] mats = new Material[horseSkinMesh.materials.Length];
        MaterialTableObject horseData = HorseDataManager.Instance.MaterialHorse;
        mats[0] = horseData.GetRandomMatMane();
        mats[1] = horseData.GetRandomMatEye();
        mats[2] = horseData.GetRandomMatBody();
        horseSkinMesh.materials = mats;
    }

    public void SetHorseName(string newName)
    {
        textHorseName.text = newName;
    }
    public void SetTextNameColor()
    {
        textHorseName.color = Color.green;
    }


}
