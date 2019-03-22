using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace TestService
{

    public abstract class AbstractServiceF
    {
        public Service CreateService(ServiceType servcType)
        {
            Service service = this.GetService(servcType);

            return service;

        }
        public abstract Service GetService(ServiceType servType);
    }

    public class ThroughputService : AbstractServiceF
    {
        public override Service GetService(ServiceType servType)
        {
            switch (servType)
            {
                case ServiceType.UDP:
                    return new UDPService(servType);
                    //break;
                case ServiceType.TCP:
                    return new TCPService();
                    //break;
                default:
                    return null;
                    //break;

            }
        }
    }
    class Rules
    {
    }

    public abstract class AbstractAppHandlerF
    {
        public AppHandler CreateHandler(PqaAppType appType)
        {
            AppHandler  apHandler = this.GetHandler(appType);

            return apHandler;
        }
        public abstract AppHandler GetHandler(PqaAppType appType);
    }

    public class ThroughputAppHandler : AbstractAppHandlerF
    {
        public override AppHandler GetHandler(PqaAppType appType)
        {
            switch (appType)
            {
                case PqaAppType.EmbeddedApp:
                    return new EmbeddedAppHandler(appType);

                case PqaAppType.TetheredApp:
                    return new TetheredAppHandler(appType);

                case PqaAppType.NoApp:
                    return new NoAppHandler(appType);

                default:
                    return null;
            
            }
        }
    }

    public abstract class AbstractDauHandlerF
    {
        public DauHandler CreateHandler(DauType dauType)
        {
            DauHandler dauHandler = this.GetHandler(dauType);

            return dauHandler;
        }
        public abstract DauHandler GetHandler(DauType dauType);
    }

    public class DAPIIperfDauHandler : AbstractDauHandlerF
    {
        public override DauHandler GetHandler(DauType dauType)
        {
            switch (dauType)
            {
                case DauType.DapiIperf:
                    return new DAPIIperfHandler(dauType);

                default:
                    return null;

            }
        }
    }

    public class DAPIThroughputDauHandler : AbstractDauHandlerF
    {
        public override DauHandler GetHandler(DauType dauType)
        {
            switch (dauType)
            {
                case DauType.DapiThroughput:
                    return new DAPIThroughputServiceHandler(dauType);

                default:
                    return null;

            }
        }
    }
}
