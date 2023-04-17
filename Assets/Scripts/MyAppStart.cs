using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MyAppStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("unity-script: MyAppStart Start called");

        // Define auto-rotate (Hyperbeard TestSuite Issue)
        //Screen.autorotateToPortrait = true;
        //Screen.autorotateToPortraitUpsideDown = true;
        //Screen.orientation = ScreenOrientation.AutoRotation;

        // Set iS appkey and child-directed flags (dustin.ru@is.com test account appkeys)
        #if UNITY_ANDROID
        string APP_KEY = "1648056c5";
        #elif UNITY_IOS
        string APP_KEY = "14ba27bd1";
        #else
        string APP_KEY = "unsupported_platform";
        #endif

        string id = IronSource.Agent.getAdvertiserId();
        Debug.Log("unity-script: IronSource.Agent.getAdvertiserId : " + id);

        Debug.Log("unity-script: IronSource.Agent.validateIntegration");
        IronSource.Agent.validateIntegration();

        Debug.Log("unity-script: unity version" + IronSource.unityVersion());

        // Add SDK init completed callback event
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;

        // Set Metadata Flags Prior to Init
        setMetadataFlags();


        // Init ironSource
        Debug.Log("unity-script: IronSource.Agent.init");
        //IronSource.Agent.init(APP_KEY, IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.OFFERWALL, IronSourceAdUnits.BANNER);
        IronSource.Agent.init(APP_KEY);


        // Init AdQuality
        AdQualitySdkInit adQualitySdkInit = new AdQualitySdkInit();
        ISAdQualityConfig adQualityConfig = new ISAdQualityConfig
        {
            AdQualityInitCallback = adQualitySdkInit
        };
        adQualityConfig.UserId = "druTest";
        adQualityConfig.LogLevel = ISAdQualityLogLevel.VERBOSE;
        IronSourceAdQuality.Initialize(APP_KEY, adQualityConfig);

        // Add onImpressionDataReadyEvent
        IronSourceEvents.onImpressionDataReadyEvent += ImpressionDataReadyEvent;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // App Paused
    void OnApplicationPause(bool isPaused)
    {
        Debug.Log("unity-script: OnApplicationPause = " + isPaused);
        IronSource.Agent.onApplicationPause(isPaused);
    }

    void setMetadataFlags()
    {
        #if UNITY_ANDROID
            //IronSource.Agent.setMetaData("is_deviceid_optout", "true");
            //IronSource.Agent.setMetaData("is_child_directed", "true");
        #elif UNITY_IOS
            //IronSource.Agent.setMetaData("is_child_directed", "true");
        #endif

        // Set Consent
        //IronSource.Agent.setConsent(false);

        // Set metadata flag for Test Suite
        IronSource.Agent.setMetaData("is_test_suite", "enable");
    }

    // Enable Test Suite
    public void LoadTestSuite()
    {
        IronSource.Agent.launchTestSuite();
    }

    private void SdkInitializationCompletedEvent() { }

    public class AdQualitySdkInit : ISAdQualityInitCallback
    {

        public void adQualitySdkInitSuccess()
        {
            Debug.Log("unity: adQualitySdkInitSuccess");
        }
        public void adQualitySdkInitFailed(ISAdQualityInitError adQualitySdkInitError, string errorMessage)
        {
            Debug.Log("unity: adQualitySdkInitFailed " + adQualitySdkInitError + " message: " + errorMessage);
        }
    }

    private void ImpressionDataReadyEvent(IronSourceImpressionData impressionData) { }
}
