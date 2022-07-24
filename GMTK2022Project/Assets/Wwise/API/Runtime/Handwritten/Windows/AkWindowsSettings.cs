
public partial class AkCommonUserSettings
{
	partial void SetSampleRate(AkPlatformInitSettings settings)
	{
		settings.uSampleRate = m_SampleRate;
	}
}


public class AkWindowsSettings : AkWwiseInitializationSettings.PlatformSettings
{
#if UNITY_EDITOR
	[UnityEditor.InitializeOnLoadMethod]
	private static void AutomaticPlatformRegistration()
	{
		RegisterPlatformSettingsClass<AkWindowsSettings>("Windows");
	}
#endif // UNITY_EDITOR

	protected override AkCommonUserSettings GetUserSettings()
	{
		return UserSettings;
	}

	protected override AkCommonAdvancedSettings GetAdvancedSettings()
	{
		return AdvancedSettings;
	}

	protected override AkCommonCommSettings GetCommsSettings()
	{
		return CommsSettings;
	}

	[System.Serializable]
	public class PlatformAdvancedSettings : AkCommonAdvancedSettings
	{
		[UnityEngine.Tooltip("Maximum number of System Audio Objects to reserve. Other processes will not be able to use them. Default is 128.")]
		public uint MaxSystemAudioObjects = 128;

		public override void CopyTo(AkPlatformInitSettings settings)
		{

			settings.uMaxSystemAudioObjects = MaxSystemAudioObjects;

		}
	}

	[UnityEngine.HideInInspector]
	public AkCommonUserSettings UserSettings;

	[UnityEngine.HideInInspector]
	public PlatformAdvancedSettings AdvancedSettings;

	[UnityEngine.HideInInspector]
	public AkCommonCommSettings CommsSettings;
}
