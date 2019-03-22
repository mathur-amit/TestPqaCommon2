using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using First17DLL;
using TestService;
using  PQACommon;
using PQACommon.Utilities;

namespace ConsoleDLLConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            //string showDescription = "This is a executable that tests consuming the vs 2017 dll methods :\n * Addition \n * Modulus \n * \n\n\n";
            //Console.WriteLine(showDescription);
            //int a, b, c;
            //Console.WriteLine("Enter first Number for Addition");
            //bool isSuccessfullyConverted = Int32.TryParse(  Console.ReadLine(), out a);
            //Console.WriteLine("Enter Second Number for Addition");
            //isSuccessfullyConverted = Int32.TryParse(Console.ReadLine(), out b);

            //First17DLL.Calculator calc = new Calculator();
            //c = calc.Add(a, b);
            //Console.WriteLine("Additin Result is " + c);





            //AbstractServiceF absService = new ThroughputService();
            //Service ser = absService.CreateService(ServiceType.UDP);
            //ser.Run();
            //ser.Test();

            //ser = absService.CreateService(ServiceType.TCP);
            //ser.Run();
            //ser.Test();

            //AbstractAppHandlerF absHandler = new ThroughputAppHandler();
            //AppHandler appHandle = absHandler.CreateHandler(PqaAppType.TetheredApp);
            //appHandle.ConfigureTcp();
            //appHandle.ConfigureUdp();



            //appHandle = absHandler.CreateHandler(PqaAppType.NoApp);
            //appHandle.ConfigureTcp();
            //appHandle.ConfigureUdp();

            //AbstractDauHandlerF absDauHandler = new DAPIIperfDauHandler();
            //DauHandler dapiDauHandler =  absDauHandler.CreateHandler(DauType.DapiIperf);
            //dapiDauHandler.ConfigureUdp();
            //dapiDauHandler.ConfigureTcp();
            //dapiDauHandler.ConfigurePing();

            //absDauHandler = new DAPIThroughputDauHandler();
            //dapiDauHandler = absDauHandler.CreateHandler(DauType.DapiThroughput);
            //dapiDauHandler.ConfigureUdp();
            //dapiDauHandler.ConfigureTcp();
            //dapiDauHandler.ConfigurePing();

            //Console.Read();



            List<ThroughputParameters> throughputParamList;

            // var serviceParameter = new ServiceParameters();
            var throughPutParameter = new ThroughputParameters();

            throughPutParameter.Id = 1083;
            throughPutParameter.ServiceType = PqaData.ServiceType.Tcp;
            throughPutParameter.DirectionType = PqaData.Direction.DL;
            throughPutParameter.ExpectedDlThroughput = 280000;
            throughPutParameter.TestStepDuration = 60;
            throughPutParameter.ProcessSeqNumber = 1;

            throughputParamList = new List<ThroughputParameters>();
            throughputParamList.Add(throughPutParameter);

            PqaCommon pqaCommon = PqaCommon.PqaCommonInstance;
            pqaCommon.Init();
            pqaCommon.InitService(PqaData.PqaAppType.EmbeddedApp, PqaData.DauType.DapiThroughputService);
            Console.WriteLine("Helloooo All ");
            Console.WriteLine("throughputParamList = "+ (throughputParamList[0]).ToString() );
            pqaCommon.StartServices(ref throughputParamList); 

            Console.ReadLine();
            // pqaCommon.StartSingleService(throughPutParameter); //works

        }
    }
}
