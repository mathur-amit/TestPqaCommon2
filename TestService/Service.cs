using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{
    public enum ServiceType
    {
        UDP,
        TCP,
        PING
    }

    public enum PqaAppType
    {
        EmbeddedApp,
        TetheredApp,
        NoApp
    }

    public enum DauType
    {
        DapiIperf,
        DapiThroughput
    }
    public abstract class Service
    {
        protected ServiceType serviceType;
        protected Service()
        {
            Console.WriteLine("Default Service Constructor");
        }
        Service(ServiceType serviceType)
        {
            Console.WriteLine("Service Constructor with Parameter");
        }

        void RunLocal()
        {
            Console.WriteLine("Run of Service");
        }

        public abstract void Test();
        public abstract void Run();
    }

    class UDPService: Service
    {
        public int Bandwidth { get; set; }

        public UDPService(ServiceType serviceType)
        {
            base.serviceType = serviceType;
        }
        public override void Test()
        {
            Console.WriteLine("Udp test()");
        }

        public void RunLocal(int bandwidth)
        {
            Bandwidth = bandwidth;
            Console.WriteLine("UDP: RunLocal()..Bandwidth set as = {0:D}",Bandwidth);
        }

        public override void Run()
        {
            Console.WriteLine("Udp Run()");
        }
    }

    class TCPService : Service
    {
        public int WindowSize { get; set; }

        public override void Run()
        {
            Console.WriteLine("TCP: Run()");
        }

        public override void Test()
        {
            Console.WriteLine("Tcp test()");
        }

        void RunLocal()
        {
            Console.WriteLine("TCP: RunLocal()");
        }
    }



    public abstract class AppHandler
    {
        // Attributes

        protected PqaAppType AppType;
        protected AppHandler()
        {
            Console.WriteLine("Default AppHandler Constructor");
        }
        AppHandler(PqaAppType appType)
        {
            Console.WriteLine("AppHandler Constructor with Parameter");
        }
        // Associations
        public abstract void ConfigureUdp();
        public abstract void ConfigureTcp();
    } /* end class AppHandler */


    internal class EmbeddedAppHandler : AppHandler
    {
        // Operations
        public EmbeddedAppHandler(PqaAppType appType)
        {
            AppType = appType;
        }
        public override void ConfigureTcp()
        {
            Console.WriteLine("EmbeddedApp Handler - ConfigureTcp()");
        }

        public override void ConfigureUdp()
        {
            Console.WriteLine("EmbeddedApp Handler - ConfigureUdp()");
        }
    } /* end class EmbeddedAppHandler */

    public class TetheredAppHandler : AppHandler
    {
        public TetheredAppHandler(PqaAppType appType)
        {
            AppType = appType;
        }
        public override void ConfigureTcp()
        {
            Console.WriteLine("TetheredAppHandler - ConfigureTcp()");
        }

        public override void ConfigureUdp()
        {
            Console.WriteLine("TetheredAppHandler - ConfigureUdp()");
        }

    } /* end class TetheredAppHandler */


    public class NoAppHandler : AppHandler
    {
        public NoAppHandler(PqaAppType appType)
        {
            AppType = appType;
        }
        public override void ConfigureTcp()
        {
            Console.WriteLine("NoAppHandler - ConfigureTcp()");
        }

        public override void ConfigureUdp()
        {
            Console.WriteLine("NoAppHandler - ConfigureUdp()");
        }

        public void PerformPing()
        {

        }
    } /* end class NoAppHandler */




    public abstract class DauHandler
    {
        // Attributes

        protected DauType DauType;
        protected DauHandler()
        {
            Console.WriteLine("Default DauHandler Constructor");
        }
        DauHandler(DauType dauType)
        {
            Console.WriteLine("DauHandler Constructor with Parameter");
        }
        // Associations
        public abstract void ConfigureUdp();
        public abstract void ConfigureTcp();

        public abstract void ConfigurePing();
    } /* end class AppHandler */

    public class DAPIIperfHandler : DauHandler
    {
        public DAPIIperfHandler(DauType dauType)
        {
            DauType = dauType;
        }
        public override void ConfigurePing()
        {
            Console.WriteLine("DAPIIperfHandler - ConfigurePing");
        }

        public override void ConfigureTcp()
        {
            Console.WriteLine("DAPIIperfHandler - ConfigureTcp");
        }

        public override void ConfigureUdp()
        {
            Console.WriteLine("DAPIIperfHandler - ConfigureUdp");
        }
    } /* end class DAPIIperfHandler */

    public class DAPIThroughputServiceHandler : DauHandler
    {
        public DAPIThroughputServiceHandler(DauType dauType)
        {
            DauType = dauType;
        }
        public override void ConfigurePing()
        {
            Console.WriteLine("DAPIThroughputServiceHandler - ConfigurePing");
        }

        public override void ConfigureTcp()
        {
            Console.WriteLine("DAPIThroughputServiceHandler - ConfigureTcp");
        }

        public override void ConfigureUdp()
        {
            Console.WriteLine("DAPIThroughputServiceHandler - ConfigureUdp");
        }
    } /* end class DAPIThroughputServiceHandler */
}
