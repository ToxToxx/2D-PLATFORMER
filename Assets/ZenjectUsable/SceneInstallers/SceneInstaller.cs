using UnityEngine;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovementSO _playerMovementConfig;
    public override void InstallBindings()
    {
        PlayerInstallersBind();
        InstallConfig();
    }

    private void PlayerInstallersBind()
    {

        Container.Install<PlayerInstaller>();
    }

    private void InstallConfig()
    {
        Container.Bind<PlayerMovementSO>().FromInstance(_playerMovementConfig);
    }
}