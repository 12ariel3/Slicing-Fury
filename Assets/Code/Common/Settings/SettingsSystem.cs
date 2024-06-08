namespace Assets.Code.Common.Settings
{
    public interface SettingsSystem
    {
        void SaveMainMenuMusicIntensity(float mainMenuMusicIntensity);
        float GetMainMenuMusicIntensity();
        void SaveGameMusicIntensity(float gameMusicIntensity);
        float GetGameMusicIntensity();
        void SaveSwordIntensity(float swordIntensity);
        float GetSwordIntensity();
        void SaveProjectileIntensity(float projectileIntensity);
        float GetProjectileIntensity();
        void SaveSoundIntensity(float soundIntensity);
        float GetSoundIntensity();
        
        void SaveIfVibrationIsActived(bool isVibrationActived);

        bool IsVibrationActived();
    }
}