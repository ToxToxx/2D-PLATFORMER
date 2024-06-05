using UnityEngine;
using Zenject;

public class PlayerInstaller : Installer
{
    public override void InstallBindings()
    {
        BindPlayerInput();
    }

    private void BindPlayerInput()
    {
        Container.Bind<PlayerInputController>().AsSingle().NonLazy();
    }
}