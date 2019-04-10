using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class StatePattern
    {
        public static void Test()
        {
            CDPlayer myPlayer = new CDPlayer(new PlayerReadyState());
            myPlayer.PressAudioSourceButton();
            myPlayer.PressAudioSourceButton();
        }
    }

    //State Pattern: Alter an object's behavior when its state changes
    //Example: The CD player has Audio Source Selection button and is a toggle button, it would play MP3 music from CD or play the Radio based on current state

    public abstract class CDPlayerState
    {
        public abstract void PressAudioSource(CDPlayer player);
    }

    public class CDPlayer
    {
        public CDPlayerState CurrentState { get; set; }

        public CDPlayer(CDPlayerState state)
        {
            CurrentState = state;
        }

        public void PressAudioSourceButton()
        {
            CurrentState.PressAudioSource(this);
        }
    }

    public class PlayerReadyState : CDPlayerState
    {
        public PlayerReadyState()
        {
            Console.WriteLine("Player is turned On and Ready for playing..");
        }

        public override void PressAudioSource(CDPlayer player)
        {
            player.CurrentState = new MP3PlayerState();
        }
    }

    public class MP3PlayerState : CDPlayerState
    {
        public MP3PlayerState()
        {
            Console.WriteLine("MP3 is playing");
        }

        public override void PressAudioSource(CDPlayer player)
        {
            player.CurrentState = new RadioState();
        }
    }
    public class RadioState : CDPlayerState
    {
        public RadioState()
        {
            Console.WriteLine("Radio is playing");
        }
        public override void PressAudioSource(CDPlayer player)
        {
            player.CurrentState = new MP3PlayerState();
        }
    }
}
