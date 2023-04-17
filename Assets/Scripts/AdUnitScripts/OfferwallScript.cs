using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OfferwallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        IronSourceEvents.onOfferwallClosedEvent += OfferwallClosedEvent;
        IronSourceEvents.onOfferwallOpenedEvent += OfferwallOpenedEvent;
        IronSourceEvents.onOfferwallShowFailedEvent += OfferwallShowFailedEvent;
        IronSourceEvents.onOfferwallAdCreditedEvent += OfferwallAdCreditedEvent;
        IronSourceEvents.onGetOfferwallCreditsFailedEvent += GetOfferwallCreditsFailedEvent;
        IronSourceEvents.onOfferwallAvailableEvent += OfferwallAvailableEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowOfferwall()
    {
        //show offerwall when user clicks the offerwall button 
        IronSource.Agent.showOfferwall();
    }

    /**
    * Invoked when there is a change in the Offerwall availability status.
    * @param - available - value will change to YES when Offerwall are available. 
    * You can then show the video by calling showOfferwall(). Value will change to NO when Offerwall isn't available.
    */
    void OfferwallAvailableEvent(bool canShowOfferwall)
    {
    }
    /**
     * Invoked when the Offerwall successfully loads for the user.
     */
    void OfferwallOpenedEvent()
    {
    }
    /**
     * Invoked when the method 'showOfferWall' is called and the OfferWall fails to load.  
    *@param desc - A string which represents the reason of the failure.
     */
    void OfferwallShowFailedEvent(IronSourceError error)
    {
    }
    /**
      * Invoked each time the user completes an offer.
      * Award the user with the credit amount corresponding to the value of the ‘credits’ 
      * parameter.
      * @param dict - A dictionary which holds the credits and the total credits.   
      */
    void OfferwallAdCreditedEvent(Dictionary<string, object> dict)
    {
        Debug.Log("I got OfferwallAdCreditedEvent, current credits = " + dict["credits"] + "totalCredits = " + dict["totalCredits"]);
    }
    /**
      * Invoked when the method 'getOfferWallCredits' fails to retrieve 
      * the user's credit balance info.
      * @param desc -string object that represents the reason of the  failure. 
      */
    void GetOfferwallCreditsFailedEvent(IronSourceError error)
    {
    }
    /**
      * Invoked when the user is about to return to the application after closing 
      * the Offerwall.
      */
    void OfferwallClosedEvent()
    {
    }

}
