using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;


/**
 * Author      : Joshua Reynolds
 * Email       : joshuare@mtu.edu
 * Description : This class houses the function for the occlusion debugger functionality.
 */
public class OcculsionDebugger : MonoBehaviour
{
    // Initialize variables
    public sentenceScript ss;
    
    /**
     * Description : Turn on the mesh
     */
    public void OnButtonMesh()
    {
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
        
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Visible;
        observer.Resume();
    }
    
    /**
     * Description : Turn off the mesh
     */
    public void OffButtonMesh()
    {
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
        
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Occlusion;
        observer.Resume();
        ss.SpatialAwareness();
    }
}
