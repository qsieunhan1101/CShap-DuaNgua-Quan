using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : Singleton<Finish>
{
    [SerializeField] private List<string> horseFinishName;
    [SerializeField] private bool isAllFinish = false;
    public List<string> HorseFinishName => horseFinishName;
    private void Update()
    {
        
        if (isAllFinish == false && horseFinishName.Count == 12)
        {
            StartCoroutine(FinishEvent());
            isAllFinish = true;
        }
    }
    private IEnumerator FinishEvent()
    {
        yield return new WaitForSeconds(2);
        GameManager.Instance.ChangeState(GameState.Finish);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Horse"))
        {
            horseFinishName.Add(other.name);
        }
    }
}
