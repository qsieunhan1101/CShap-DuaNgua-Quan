using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_GamePlay : UICanvas
{
    [SerializeField] private List<TextMeshProUGUI> listTextRankings;

    [SerializeField] private Button btnStart;

    public static Action startEvent;

    private void OnEnable()
    {
        btnStart.gameObject.SetActive(true);
    }
    private void Update()
    {
        UpdateRankingText(HorseManager.Instance.ListHorsesRanking);

        btnStart.onClick.AddListener(OnStart);
    }

    private void UpdateRankingText(List<Horse> listHorses)
    {
        for (int i = 0; i < listHorses.Count; i++)
        {
            listTextRankings[i].text = $"{i + 1} {listHorses[i].name}";
        }
    }

    private void OnStart()
    {
        startEvent?.Invoke();
        btnStart.gameObject.SetActive(false);

    }

}
