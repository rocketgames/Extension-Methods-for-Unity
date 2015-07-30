using UnityEngine;
public abstract class MonoSingletonExt<T> : MonoBehaviour where T : MonoSingletonExt<T>
{
    #region Variables

    private const string STR_NoInstanceOfATemporaryOneIsCreated = "No instance of {0}, a temporary one is created.";
    private const string STR_TempInstanceOf = "Temp Instance of ";
    private const string STR_ProblemDuringTheCreationOf = "Problem during the creation of {0}";
    private static T m_Instance = null;

    private static bool IsShuttingDown = false;

    // Variables
    #endregion

    public static T instance
    {
        get
        {
            // exit if shutting down
            if (IsShuttingDown)
                return null;

            // Instance required for the first time, we look for it
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType(typeof(T)) as T;

                // Object not found, we create a temporary one
                if (m_Instance == null)
                {
                    Debug.LogWarning(string.Format(STR_NoInstanceOfATemporaryOneIsCreated, typeof(T).ToString()));
                    m_Instance = new GameObject(STR_TempInstanceOf + typeof(T).ToString(), typeof(T)).GetComponent<T>();

                    // Problem during the creation, this should not happen
                    if (m_Instance == null)
                    {
                        Debug.LogError(string.Format(STR_ProblemDuringTheCreationOf, typeof(T).ToString()));
                    }
                }
                m_Instance.Init();
            }
            return m_Instance;
        }
    }

    // If no other monobehaviour request the instance in an awake function
    // executing before this one, no need to search the object.
    private void Awake()
    {
        if (m_Instance == null)
        {
            m_Instance = this as T;
            m_Instance.Init();
        }

        // TESTING
        Debug.Log(string.Format("Awaking: {0}", this.name));
    }

    // This function is called when the instance is used the first time
    // Put all the initializations you need here, as you would do in Awake
    public virtual void Init() { }

    // Make sure the instance isn't referenced anymore when the user quit, just in case.
    internal virtual void OnApplicationQuit()
    {
        IsShuttingDown = true;
        Debug.Log(string.Format("Quitting: {0}", this.name));


        //Destroy(m_Instance);
        m_Instance = null;
    }
}