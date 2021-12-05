using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.Networking;

public class Your_Class : MonoBehaviour
{
    AssetBundle placeholder_bundle;
    bool asset_bundles_loaded = false;

    // Start is called before the first frame update
    [Obsolete]
    void Start()
    {
        StartCoroutine(load_asset_bundles());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [Obsolete]
    private IEnumerator load_asset_bundles()
    {
        StartCoroutine(load_sub_asset_bundle("placeholders"));

        yield return new WaitForSeconds(2f);
        asset_bundles_loaded = true;
        yield return true;

    }

    [Obsolete]
    private IEnumerator load_sub_asset_bundle(string bundle_name)
    {
        string uri;
        string path_to_use;

        //This is the path to require an asset bundle in Assets/StreamingAssets on Android
        path_to_use = Path.Combine("jar:file//" + Application.dataPath + "!assets/", bundle_name);
        uri = path_to_use;

        //path_to_use = Application.path_to_use;
        //uri = path_to_use + "/" + bundle_name;

        UnityEngine.Networking.UnityWebRequest request = UnityEngine.Networking.UnityWebRequestAssetBundle.GetAssetBundle(uri, 0);

        yield return request.Send();

        switch (bundle_name)
        {
            case "placeholders":

                placeholder_bundle = DownloadHandlerAssetBundle.GetContent(request);
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(1);
    }
}
