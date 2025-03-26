using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.XR.Management;

public class MetaQuestSettings : EditorWindow
{
    [MenuItem("Ommy/Set Meta Quest Player Settings")]
    public static void ShowWindow()
    {
        GetWindow<MetaQuestSettings>("Meta Quest Player Settings");
    }

    private void OnGUI()
    {
        GUILayout.Label("Set Meta Quest Player Settings", EditorStyles.boldLabel);

        if (GUILayout.Button("Apply Settings"))
        {
            ApplyMetaQuestSettings();
            Debug.Log("Meta Quest Player Settings applied successfully.");
        }
    }

    private static void ApplyMetaQuestSettings()
    {
        // Set Android platform
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        // Player Settings
        PlayerSettings.SetScriptingBackend(BuildTargetGroup.Android, ScriptingImplementation.IL2CPP);
        PlayerSettings.Android.targetArchitectures = AndroidArchitecture.ARM64;
        PlayerSettings.Android.minSdkVersion = AndroidSdkVersions.AndroidApiLevel29;
        //PlayerSettings.Android.targetSdkVersion = AndroidSdkVersions.AndroidApiLeve33;

        // Graphics API
        PlayerSettings.SetGraphicsAPIs(BuildTarget.Android, new[] { GraphicsDeviceType.OpenGLES3 });
        PlayerSettings.MTRendering = true;

        // Optimization
        PlayerSettings.stripEngineCode = true;
        PlayerSettings.SetManagedStrippingLevel(BuildTargetGroup.Android, ManagedStrippingLevel.Medium);
        //PlayerSettings.keepLoadedShadersAlive = false;

        // XR Settings
        // Ensure Oculus XR Plugin is enabled
        if (!IsOculusPluginEnabled())
        {
            Debug.LogWarning("Oculus XR Plugin is not enabled. Make sure it is installed and enabled in XR Plugin Management.");
        }

        // Enable Multiview for performance optimization
        //PlayerSettings.VR.SetVREnabled(BuildTargetGroup.Android, true);
        PlayerSettings.stereoRenderingPath = StereoRenderingPath.SinglePass;

        // Build settings
        //EditorUserBuildSettings.buildSystem = BuildSystem.Gradle;

        // Other necessary settings can be added here

        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private static bool IsOculusPluginEnabled()
    {
        var oculusPlugin = "Unity.XR.Oculus";
        var xrGeneralSettings = AssetDatabase.LoadAssetAtPath<XRGeneralSettings>("Assets/XR/Settings/XRGeneralSettings.asset");
        if (xrGeneralSettings != null)
        {
            foreach (var loader in xrGeneralSettings.AssignedSettings.loaders)
            {
                if (loader != null && loader.name.Contains(oculusPlugin))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
