using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseDataManager : Singleton<HorseDataManager>
{

    [SerializeField] private MaterialTableObject materialHorse;

    public MaterialTableObject MaterialHorse => materialHorse;

}
