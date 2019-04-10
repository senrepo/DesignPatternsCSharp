using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsCSharp
{
    public static class BridgePattern
    {
        public static void Test()
        {
            ITV sonyTv = new SonyTV();
            Remote remote = new Remote(sonyTv);
            remote.On();
            remote.SetChannel(1);
            remote.Off();

            //replace the normal remote with power remove
            PowerRemote powerRemote = new PowerRemote(sonyTv);
            powerRemote.On();
            powerRemote.SetChannel(1);
            powerRemote.NextChannel();
            powerRemote.PrevChannel();
            powerRemote.Off();
        }
    }

    /*  Isolate the interface from its implementation
        Remote and TV are two different products and their functionality can be extended anytime later. 
        This pattern address the concerns of one product extension wouldn't affect another product. 
        For ex. Let say a Remote works with Sony TV and we can replace this normal remote with prower remote anytime which should smoothly with Sony Tv without any needed on TV side.
     
        Bridge pattern applied for the cases we try make bridge between two products and which are going to created. 
        The Adapter patter applied to make work two different products which are already developed.
     */


    public interface IRemote
    {
        void On();
        void Off();
        void SetChannel(int channel);
    }

    public interface IPowerRemote
    {
        void On();
        void Off();
        void SetChannel(int channel);
        void NextChannel();
        void PrevChannel();
    }

    public interface ITV
    {
        void TurnOn();
        void TurnOff();
        void TuneChannel(int channel);
    }

    public class Remote : IRemote
    {
        protected ITV tv { get; set; }

        public Remote(ITV tv)
        {
            this.tv = tv;
        }

        #region IRemote Members

        public void On()
        {
            this.tv.TurnOn();
        }

        public void Off()
        {
            this.tv.TurnOff();
        }

        public virtual void SetChannel(int channel)
        {
            this.tv.TuneChannel(channel);
        }

        #endregion
    }

    public class PowerRemote : Remote, IPowerRemote
    {
        private int currChannel;

        public PowerRemote(ITV tv)
            : base(tv)
        {
            this.tv = tv;
        }

        public override void SetChannel(int channel)
        {
            base.SetChannel(channel);
            currChannel = channel;
        }

        #region IPowerRemote Members

        public void NextChannel()
        {
            SetChannel(currChannel + 1);
        }

        public void PrevChannel()
        {
            SetChannel(currChannel - 1);
        }

        #endregion
    }

    public class TV : ITV
    {
        #region ITV Members

        public virtual void TurnOn()
        {
            Console.WriteLine("TV turned on");
        }

        public virtual void TurnOff()
        {
            Console.WriteLine("TV turned off");
        }

        public virtual void TuneChannel(int channel)
        {
            Console.WriteLine("TV is tuned with " + channel);
        }

        #endregion
    }

    public class SonyTV : TV
    {
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine("TV auto brightness adjusted");
        }
    }

    public class PhilipsTV : TV
    {
        public override void TurnOn()
        {
            base.TurnOn();
            Console.WriteLine("TV auto brightness and color adjusted");
        }
    }


}
