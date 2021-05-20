using UnityEngine.UI;
using UnityEngine;

public class Ability : MonoBehaviour
{
    protected bool currentlyActive = false;
    public KeyCode key;
    protected float timer = 0f;
    public float abilityTimeLimit = 5f;
    public Image display;
    public float depreciationAmount = 5;

    protected virtual void UseAbility()
    {
        timer = 0;
        GetComponent<Candle>().Depreciate(depreciationAmount);
    }
    protected virtual void DisableAbility()
    {

    }
}