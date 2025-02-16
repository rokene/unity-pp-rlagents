using UnityEngine;

/// <summary>
/// Manages a single flower with nectar
/// </summary>
public class Flower : MonoBehaviour
{
    [Tooltip("The color when the flower is full")]
    public Color fullFlowerColor = new Color(1f, 0f, .3f);

    [Tooltip("The color when the flower is empty")]
    public Color emptyFlowerColor = new Color(0.5f, 0f, 1f);

    /// <summary>
    /// The trigger colider representing the nectar.
    /// </summary>
    [HideInInspector]
    public Collider nectarCollider;

    // the solid collider representing the flower petals
    private Collider flowerCollider;

    // the flower's material
    private Material flowerMaterial;

    /// <summary>
    /// A vector pointing straight out of the flower
    /// </summary>
    public Vector3 FlowerUpVector
    {
        get
        {
            return nectarCollider.transform.up;
        }
    }

    /// <summary>
    /// The center position of the nectar collider
    /// </summary>
    public Vector3 FlowerCenterPosition
    {
        get
        {
            return nectarCollider.transform.position;
        }
    }

    /// <summary>
    /// The amount of nectar reaining in the flower
    /// </summary>
    public float NectarAmount { get; private set; }

    public bool HasNectar
    {
        get
        {
            return NectarAmount > 0f;
        }
    }

    /// <summary>
    /// Attempts to remove nectar from the flower
    /// </summary>
    /// <param name="amount">The amount of nectar to remove</param>
    /// <returns>The actual amount succesffuly removed</returns>
    public float Feed(float amount)
    {
        // Trac how muc nectar was successfully taken (cannot take more than available)
        float nectarTaken = Mathf.Clamp(amount, 0f, NectarAmount);

        // Substract thye nectar
        NectarAmount -= amount;

        if( NectarAmountAmount <= 0)
        {
            // no nectar remaining
            NectarAmount = 0;

            // disable flower and nectar colliders
            flowerCollider.gameObject.SetActive(false);
            nectarCollider.gameObject.SetActive(false);

            // change flower color to indicate empty
            flowerMaterial.SetColor("_BaseColor", emptyFlowerColor);
        }

        //Return the amount of nectar that was taken
        return nectarTaken;
    }
    /// <summary>
    /// Resets the flower
    /// </summary>
    public void ResetFlower()
    {
        // refil nectar
        NectarAmount = 1f;

        // enable the flower and colliders
        flowerCollider.gameObject.SetActive(true);
        nectarCollider.gameObject.SetActive(true);

        // change flower color to indicate itis full
        flowerMaterial.SetColor("_BaseColor", fullFlowerColor);
    }

    /// <summary>
    /// Called when the flower wakes up
    /// </summary>
    private void Awake()
    {
        // find the flower's mesh render and get the main material
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
        flowerMaterial = meshRenderer.material;

        // find flower and nectar colliders
        flowerCollider = transform.Find("FlowerCollider").GetComponent<Collider>();

        nectarCollider = transform.Find("FlowerNectarCollider").GetComponent<Collider>();
    }
}
