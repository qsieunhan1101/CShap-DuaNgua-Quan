using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Canvas_GamePlay : UICanvas
{
    [SerializeField] private List<TextMeshProUGUI> listTextRankings;


    private void Update()
    {
        UpdateRankingText(HorseManager.Instance.ListHorsesRanking);
    }

    private void UpdateRankingText(List<Horse> listHorses)
    {
        for (int i = 0; i < listHorses.Count; i++)
        {
            listTextRankings[i].text = $"{i + 1} {listHorses[i].name}";
        }
    }

}
