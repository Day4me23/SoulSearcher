using UnityEngine;

public class AbilityInvisable : Ability
{
    Material material;
    public float playerOpacity = 1f;
    public bool invisProc = false;

    private void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        

        if (Input.GetKeyDown(key) && !currentlyActive)
        {
            UseAbility();
            timer = 0;
            currentlyActive = true;
            invisProc = true;
        }

        if (timer < abilityTimeLimit && currentlyActive)
        {
            timer += Time.deltaTime;

            if (playerOpacity > .15f)
                playerOpacity -= Time.deltaTime;

            if (timer >= abilityTimeLimit)
            {
                DisableAbility();
                timer = 0;
                currentlyActive = false;
                invisProc = false;
            }
        }

        if (display != null)
            display.fillAmount = timer / abilityTimeLimit;
        material.SetFloat("Opacity", playerOpacity);

        if (!currentlyActive)
            if (playerOpacity < 1)
                playerOpacity += Time.deltaTime;


    }

    protected override void UseAbility()
    {
        Debug.Log("Flying!");
        base.UseAbility();

    }
    protected override void DisableAbility()
    {
        base.DisableAbility();

    }
}
