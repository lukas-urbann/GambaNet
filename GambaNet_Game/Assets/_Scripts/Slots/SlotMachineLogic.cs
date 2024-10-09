using UnityEngine;

public abstract class SlotMachineLogic : MonoBehaviour
{
    [SerializeField]
    private int slotColumns = 3;
    
    [SerializeField]
    private int slotRows = 3;


    public abstract void Spin();
    
    public abstract void GetWinChance();
    
    public abstract void GetWinChance();
}
