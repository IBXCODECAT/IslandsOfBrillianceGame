using EasyBuildSystem.Runtimes.Events;
using EasyBuildSystem.Runtimes.Extensions;
using EasyBuildSystem.Runtimes.Internal.Addons;
using EasyBuildSystem.Runtimes.Internal.Part;
using UnityEngine;

[System.Serializable]
public class DestructibleAppearance
{
    public string Name;
    public int AppearanceIndex = 0;
    public GameObject FracturedAppearance;
    public float FracturedLifeTime;
}

[AddOn(ADDON_NAME, ADDON_AUTHOR, ADDON_DESCRIPTION, AddOnTarget.PartBehaviour)]
public class AddonDestructibleAppearance : AddOnBehaviour
{
    #region AddOn Fields

    public const string ADDON_NAME = "Destructible Appearances";
    public const string ADDON_AUTHOR = "Cryptoz";
    public const string ADDON_DESCRIPTION = "Allow to instantiate child gameObject(s) according to the appearance of the part after the destruction.";

    [HideInInspector]
    public string _Name = ADDON_NAME;

    public override string Name
    {
        get
        {
            return _Name;
        }

        protected set
        {
            _Name = value;
        }
    }

    [HideInInspector]
    public string _Author = ADDON_AUTHOR;

    public override string Author
    {
        get
        {
            return _Author;
        }

        protected set
        {
            _Author = value;
        }
    }

    [HideInInspector]
    public string _Description = ADDON_DESCRIPTION;

    public override string Description
    {
        get
        {
            return _Description;
        }

        protected set
        {
            _Description = value;
        }
    }

    #endregion AddOn Fields

    #region Public Fields

    [Header("Destructible Appearance(s) Settings")]

    [Tooltip("Define here the gameObject(s) at instantiate when the destruction of gameObject.")]
    public DestructibleAppearance[] Destructibles;

    [Tooltip("This allows to define the max depenetration velocity before the destruction of gameObject.")]
    public float MaxDepenetrationVelocity = .5f;

    #endregion

    #region Private Fields

    private PartBehaviour Part;

    private bool IsExiting;

    #endregion

    #region Private Methods

    private void OnEnable()
    {
        EventHandlers.OnAffectedPart += OnAffectedPart;
        EventHandlers.OnDestroyedPart += OnDestroyedPart;
    }

    private void OnDisable()
    {
        EventHandlers.OnAffectedPart -= OnAffectedPart;
        EventHandlers.OnDestroyedPart -= OnDestroyedPart;
    }
    
    private void Awake()
    {
        Part = GetComponent<PartBehaviour>();
    }

    private void OnApplicationQuit()
    {
        IsExiting = true;
    }

    private void OnDestroy()
    {
        if (IsExiting)
            return;

        if (Part.CurrentState == StateType.Remove || Part.CurrentState == StateType.Placed)
            InstantiateObjects();
    }

    private void OnAffectedPart(PartBehaviour part)
    {
        if (part != Part)
            return;

        if (!Part.CheckStability())
            InstantiateObjects();
    }

    private void OnDestroyedPart(PartBehaviour part)
    {
        if (part != Part)
            return;

        if (!Part.CheckStability())
            InstantiateObjects();
    }

    private bool AlreadyInstantiated;
    private void InstantiateObjects()
    {
        if (AlreadyInstantiated) return;

        AlreadyInstantiated = true;

        gameObject.ChangeAllMaterialsInChildren(Part.Renderers.ToArray(), Part.InitialsRenders);

        for (int i = 0; i < Destructibles.Length; i++)
        {
            if (Part.AppearanceIndex == Destructibles[i].AppearanceIndex)
            {
                if (Destructibles[i] == null)
                    return;

                Destructibles[i].FracturedAppearance.SetActive(true);

                GameObject Temp = Instantiate(Destructibles[i].FracturedAppearance.gameObject,
                    Destructibles[i].FracturedAppearance.transform.position, 
                    Destructibles[i].FracturedAppearance.transform.rotation);

                for (int x = 0; x < Temp.transform.childCount; x++)
                    Temp.transform.GetChild(x).GetComponent<Rigidbody>().maxDepenetrationVelocity = MaxDepenetrationVelocity;

                Destroy(Temp, Destructibles[i].FracturedLifeTime);

                Destroy(gameObject);

                break;
            }
        }
    }

    #endregion
}