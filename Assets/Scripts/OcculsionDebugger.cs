using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.SpatialAwareness;
using UnityEngine;

public class OcculsionDebugger : MonoBehaviour
{
    public sentenceScript ss;
    public void OnButtonMesh()
    {
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
        
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Visible;
        observer.Resume();
    }
    
    public void OffButtonMesh()
    {
        var observer = CoreServices.GetSpatialAwarenessSystemDataProvider<IMixedRealitySpatialAwarenessMeshObserver>();
        
        observer.DisplayOption = SpatialAwarenessMeshDisplayOptions.Occlusion;
        observer.Resume();
        ss.SpatialAwareness();
    }
}
