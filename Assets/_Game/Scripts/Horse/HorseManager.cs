using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseManager : Singleton<HorseManager>
{
    [SerializeField] private List<Transform> listHorsePos;

    [SerializeField] private Transform horseParent;

    [SerializeField] private GameObject horsePrefab;

    [SerializeField] private List<Horse> listHorses;

    [SerializeField] private List<Horse> listHorsesRanking;

    public List<Horse> ListHorsesRanking => listHorsesRanking;


    private void Start()
    {
        SetUpHorse();
    }
    private void Update()
    {
        listHorsesRanking = SortHorse(listHorses);
    }
    private void SetUpHorse()
    {
        int ranHorse = Random.Range(0, listHorsePos.Count);
        for (int i = 0; i < listHorsePos.Count; i++)
        {
            GameObject horse = Instantiate(horsePrefab, horseParent);
            horse.transform.position = listHorsePos[i].transform.position;
            horse.name = $"Horse {i+1}";
            Horse hor = horse.GetComponent<Horse>();
            listHorses.Add(horse.GetComponent<Horse>());


            hor.SetHorseName(horse.name);
            if (i == ranHorse)
            {
                CameraCotroller.Instance.target = horse;
                hor.SetTextNameColor();
            }
        }
    }

    private List<Horse> SortHorse(List<Horse> listHorses)
    {
        for (int i = 0; i < listHorses.Count; i++)
        {
            for (int j = i+1; j < listHorses.Count; j++)
            {
                if (listHorses[j].transform.position.z > listHorses[i].transform.position.z)
                {
                    Horse horse = listHorses[i];
                    listHorses[i] = listHorses[j];
                    listHorses[j] = horse;
                }
            }
        }

        return listHorses;
    }
}
