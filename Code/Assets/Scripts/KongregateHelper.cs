using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class KongregateController : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);



        /*
         * Try to connect to Kongregate. The GameObject's name is supplied so that if
         * Kongregate replies back, it will use SendMessage on the following GameObject
         * towards a method name called 'OnKongregateAPILoaded'
        */
        if (!KongregateConnected)
            Application.ExternalEval("if(typeof(kongregateUnitySupport) != 'undefined'){kongregateUnitySupport.initAPI('" + gameObject.name + "','OnKongregateAPILoaded');};");
    }



    #region Kongregate

    public Sprite ConnectionEstablishedImage;
    const string KONGREGATE_STAT_SUBMIT = "kongregate.stats.submit";

    private bool _kongregateConnected = false;
    public bool KongregateConnected
    {
        get { return _kongregateConnected; }
    }

    #region Callbacks

    /// <summary>
    /// Called when the Kongregate API is loaded and responds to our initialization
    /// request.
    /// </summary>
    /// <param name="userInfoString">
    /// A pipe separated string containing the User Id, Username and AuthToken.
    /// </param>
    public void OnKongregateAPILoaded(string userInfoString)
    {
        _kongregateConnected = true;

        if (ConnectionEstablishedImage)
            transform.GetComponent<SpriteRenderer>().sprite = ConnectionEstablishedImage;

        try
        {
            //string[] parameters = userInfoString.Split(new char[] { '|' }, System.StringSplitOptions.RemoveEmptyEntries);

            //int userId = Convert.ToInt32(parameters[0]);
            //string userName = parameters[1], gameAuthToken = parameters[2];
        }
        catch { }

        ReportInitialization();
    }

    /// <summary>
    /// Called when the Kongregate user signs in.
    /// </summary>
    /// <param name="userInfoString">
    /// A pipe separated string containing the User Id, Username and AuthToken.
    /// </param>
    public void OnKongregateUserSignedIn(string userInfoString)
    {
        //string[] parameters = userInfoString.Split(new char[] { '|' }, System.StringSplitOptions.RemoveEmptyEntries);

        //int userId = Convert.ToInt32(parameters[0]);
        //string userName = parameters[1], gameAuthToken = parameters[2];
    }

    #endregion Callbacks

    public void ReportInitialization()
    {
        Application.ExternalCall(KONGREGATE_STAT_SUBMIT, "Initialized", 1);
    }

    public void ReportGameCompleted()
    {
        if (KongregateConnected)
            Application.ExternalCall(KONGREGATE_STAT_SUBMIT, "GameCompleted", 1);
    }

    #endregion Kongregate
}