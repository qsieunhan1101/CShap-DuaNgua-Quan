using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Horse : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private Vector3 lastPosition;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed = 100;

    [SerializeField] private Transform canvasName;
    [SerializeField] private TextMeshProUGUI textHorseName;

    [SerializeField] private SkinnedMeshRenderer horseSkinMesh;

    [SerializeField] private Animator anim;
    [SerializeField] private string currentAnim;
    private Quaternion canvasNameOrinRotation;

    private bool isMove = false;

    private void Start()
    {
        OnInit();

    }
    private void OnEnable()
    {
        Canvas_GamePlay.startEvent += StartRun;
    }
    private void OnDisable()
    {
        Canvas_GamePlay.startEvent -= StartRun;
    }
    private void Update()
    {
        Move();
    }
    private void LateUpdate()
    {
        canvasName.rotation = CameraCotroller.Instance.transform.rotation * canvasNameOrinRotation;
    }

    private void OnInit()
    {
        lastPosition = transform.position;
        speed = maxSpeed / 1.50f;

        canvasNameOrinRotation = canvasName.rotation;

        SetHorseColor();

        ChangeAnim("Idle");
    }

    private void Move()
    {
        if (!isMove)
        {
            return;
        }
        ChangeAnim("Run");
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed * Vector3.forward.z);
        RandomSpeed();
    }
    private void RandomSpeed()
    {
        if (Vector3.Distance(transform.position, lastPosition) >= 100.0f)
        {
            lastPosition = transform.position;
            speed = UnityEngine.Random.Range(maxSpeed - 30, maxSpeed + 1);
        }
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

    private void ChangeAnim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
    private IEnumerator StopMove()
    {
        yield return new WaitForSeconds(2f);
        isMove = false;
        speed = 0;
        ChangeAnim("Idle");
    }
    private void StartRun()
    {
        isMove = true;
    }
    public void SetHorseName(string newName)
    {
        textHorseName.text = newName;
    }
    public void SetTextNameColor()
    {
        textHorseName.color = Color.green;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            StartCoroutine(StopMove());
        }
    }

}
