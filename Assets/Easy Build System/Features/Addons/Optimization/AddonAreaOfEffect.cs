using EasyBuildSystem.Runtimes.Internal.Addons;
using UnityEngine;
using EasyBuildSystem.Runtimes.Internal.Managers;

[AddOn(ADDON_NAME, ADDON_AUTHOR, ADDON_DESCRIPTION, AddOnTarget.BuilderBehaviour)]
public class AddonAreaOfEffect : AddOnBehaviour
{
    #region AddOn Fields

    public const string ADDON_NAME = "Area Of Effect";
    public const string ADDON_AUTHOR = "Cryptoz";
    public const string ADDON_DESCRIPTION = "Disable all the socket/part/area which are out of range, allows to increase significantly the performance of your scene.";

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

    [Header("Area Of Effects Settings")]
    public bool UseAOEOnAreas = true;
    public bool UseAOEOnParts = false;
    public bool UseAOEOnSockets = true;

    [Tooltip("Define here the radius area effect.")]
    public float Radius = 30f;

    [Tooltip("Define here the refresh interval (Default:0.5f).")]
    public float RefreshInterval = 0.5f;

    #endregion

    #region Private Methods

    private void Start()
    {
        InvokeRepeating("Refresh", RefreshInterval, RefreshInterval);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Radius);
    }

    private void Refresh()
    {
        if (UseAOEOnAreas)
            for (int i = 0; i < BuildManager.Instance.Areas.Count; i++)
                BuildManager.Instance.Areas[i].gameObject.SetActive((Vector3.Distance(transform.position, BuildManager.Instance.Areas[i].transform.position) <= Radius));

        if (UseAOEOnParts)
            for (int i = 0; i < BuildManager.Instance.Parts.Count; i++)
                BuildManager.Instance.Parts[i].gameObject.SetActive((Vector3.Distance(transform.position, BuildManager.Instance.Parts[i].transform.position) <= Radius));

        if (UseAOEOnSockets)
            for (int i = 0; i < BuildManager.Instance.Sockets.Count; i++)
                BuildManager.Instance.Sockets[i].gameObject.SetActive(Vector3.Distance(transform.position, BuildManager.Instance.Sockets[i].transform.position) <= Radius);
    }

    #endregion
}