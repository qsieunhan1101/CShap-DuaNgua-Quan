using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Finish : UICanvas
{
    [SerializeField] private TextMeshProUGUI[] textRanks;

    [SerializeField] private Button btnNext;


    private void Start()
    {
        btnNext.onClick.AddListener(OnNext);
    }
    private void OnEnable()
    {
        GameManager.finishEvent += SetHorseTextRank;
    }
    private void OnDisable()
    {
        GameManager.finishEvent -= SetHorseTextRank;

    }
    private void OnNext()
    {
        GameManager.Instance.ChangeState(GameState.MainMenu);
    }

    private void SetHorseTextRank()
    {
        List<string> names = Finish.Instance.HorseFinishName;
        for (int i = 0; i < names.Count; i++)
        {
            textRanks[i].text = $"Top {i+1}: {names[i]}";
            Debug.Log(names[i]);
        }
    }

}
