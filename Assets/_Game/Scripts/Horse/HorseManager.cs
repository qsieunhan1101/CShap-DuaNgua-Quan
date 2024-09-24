using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseManager : MonoBehaviour
{
    [SerializeField] private List<Transform> listHorsePos;

    [SerializeField] private Transform horseParent;

    [SerializeField] private GameObject horsePrefab;


    private void Start()
    {
        SetUpHorse();
    }
    private void SetUpHorse()
    {
        for (int i = 0; i < listHorsePos.Count; i++)
        {
            GameObject horse = Instantiate(horsePrefab, horseParent);
            horse.transform.position = listHorsePos[i].transform.position;
            horse.GetComponent<Horse>().SetSpeed(Random.RandomRange(80, 101));
        }
    }
}
