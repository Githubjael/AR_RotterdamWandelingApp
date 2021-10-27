using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.Networking;

public class My_Class : MonoBehaviour
{
    //create a assetbundle variable to store the data of the bundles
    AssetBundle placholders_bundle;
    public bool asset_bundles_loaded = false;

    [Obsolete]
    private void Start()
    {
        //Start the coroutinethat will load all needed asset bundles
        StartCoroutine(load_asset_bundles());
    }

    public void Update()
    {
        //Wait for all asset bundles to be loaded
        if (asset_bundles_loaded)
        {
            //once loaded use the assets in the asset bundles
            //to get the data in the bundle, you must do your bundle.LoadAsset<type_of_your_asset>("name_of_the_asset_case_sensitive");
            GameObject asset_loaded_prefab = (GameObject) placholders_bundle.LoadAsset<GameObject>("placeholder");

            GameObject instance = (GameObject)GameObject.Instantiate(asset_loaded_prefab);
        }
    }

    [Obsolete]
    private IEnumerator load_asset_bundles()
    {
        //Reuse this line to load different asset bundles of different names
        StartCoroutine(load_asset_bundle("placeholder"));

        /*
         * The delay has been added here to make sure it will load.
         * I'm lookinginto a solution to make it as quick as possible
         * But this is another problemand is not required here.
        */
        yield return new WaitForSeconds(2);
        asset_bundles_loaded = true;
        yield return true;
    }

    [Obsolete]
    IEnumerator load_asset_bundle(string bundle_name)
    {
        //this coroutine loads in 1 asset bundle at a time
        string uri;
        string path_to_use;

#if (UNITY_ANDROID && !UNITYEDITOR)
        {
            //this path is to require an asset bundle in Assets/StreamingAssets on android
            path_to_use = Path.Combine("jar:file//" + Application.dataPath + "!assets/", bundle_name);
            uri = path_to_use;
        }
#else
        {
            //same path but for computer
            path_to_use = Application.dataPath;
            uri = path_to_use + "/" + bundle_name;
        }
#endif

        //Ask for the bundle
        UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);

        yield return request.Send();
        switch (bundle_name)
        {
            case "placeholder":
                //get the bundle data and store it in the AssetBundle variable created at the begining
                placholders_bundle = DownloadHandlerAssetBundle.GetContent(request);
                break;
            default:
                break;
        }
        //Delay for now just to make sure it loas in properly before its use.
        yield return new WaitForSeconds(1);
    }

}
