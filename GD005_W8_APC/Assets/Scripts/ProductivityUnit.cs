using UnityEngine;

public class ProductivityUnit : Unit

    

    
{
    ResourcePile currentPile = null;
    public float productivityMultiplier = 2;

    //This makes it so that the Productivityunit script doesn't have any issues when calling the Unit script.
    protected override void BuildingInRange()
    {
        if (currentPile == null)
        {
            //The ''as'' is making sure the m_Target knows to check if its a ResourcePile.  
            ResourcePile pile = m_Target as ResourcePile;

            if(pile!=null)
            {
                currentPile = pile;
                currentPile.ProductionSpeed *= productivityMultiplier;
            }
        }
    }

    void resetProductivity()
    {
        if(currentPile != null)
        {
            currentPile.ProductionSpeed /= productivityMultiplier;
            currentPile = null;
        }
    }


    public override void GoTo(Building target)
    {
        base.GoTo(target);
        resetProductivity();
    }

    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
        resetProductivity();
    }
}
