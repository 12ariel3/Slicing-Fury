using Assets.Code.Player;
using UnityEngine;

namespace Assets.Code.Core.Installers
{
    public class PlayerInstallerInstaller : Installer
    {
        [SerializeField] private PlayerInstaller _playerInstaller;

        public override void Install(ServiceLocator serviceLocator)
        {
            DontDestroyOnLoad(_playerInstaller.gameObject);
            serviceLocator.RegisterService(_playerInstaller);
        }
    }
}