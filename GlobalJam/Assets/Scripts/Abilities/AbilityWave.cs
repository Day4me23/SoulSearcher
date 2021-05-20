using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityWave : Ability
{
    private void Update()
    {
        if (Input.GetKeyDown(key) && !currentlyActive)
        {
            UseAbility();
            timer = 0;
            currentlyActive = true;
        }

        if (timer < abilityTimeLimit && currentlyActive)
        {

            timer += Time.deltaTime;

            if (timer >= abilityTimeLimit)
            {
                DisableAbility();
                timer = 0;
                currentlyActive = false;
            }
        }

        if (display != null)
            display.fillAmount = timer / abilityTimeLimit;
    }

    protected override void UseAbility()
    {
        Debug.Log("Waving!");
        base.UseAbility();

    }
    protected override void DisableAbility()
    {
        base.DisableAbility();

    }
}