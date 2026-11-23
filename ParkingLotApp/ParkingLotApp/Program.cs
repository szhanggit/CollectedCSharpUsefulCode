using ParkingLogApp.BaseCommand;
using ParkingLogApp.Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            IParkingLogManagementService service = new ParkingLogManagementService("DefaultParkingLotSize".ConfigIntValue(1));
            Dictionary<string, IAppCommand> appCommandDic = InitAppCommandDictionary();
            string Message = string.Empty;
            string CommandMethod = string.Empty;

            while (!CommandMethod.Equals("exit", StringComparison.InvariantCultureIgnoreCase))
            {
                
                string input = Console.ReadLine();
                string[] inputArr = input.Split(' ');
                CommandMethod = inputArr[0].ToLower().Trim();
                string[] inputParam = inputArr.Skip(1).ToArray(); ;
                //if (appCommandDic.ContainsKey(CommandMethod))
                if(false)
                {
                    //appCommandDic[CommandMethod].ValidateInput(CommandMethod, out Message, inputParam);
                }
                else
                {
                    switch (CommandMethod)
                    {
                        case "create_parking_lot":
                            IAppCommand create_parking_lot = new ParkingLogApp.CreateCommand.AppCommand();
                            Message = create_parking_lot.Execute(service, inputParam);                            
                            break;
                        case "park":
                            IAppCommand park = new ParkingLogApp.ParkCommand.AppCommand();
                            Message = park.Execute(service, inputParam);
                            break;
                        case "leave":
                            IAppCommand leave = new ParkingLogApp.LeaveCommand.AppCommand();
                            Message = leave.Execute(service, inputParam);
                            break;
                        case "status":
                            IAppCommand status = new ParkingLogApp.StatusCommand.AppCommand();
                            Message = status.Execute(service, inputParam);
                            break;
                        case "registration_numbers_for_cars_with_colour":
                            IAppCommand registration_numbers_for_cars_with_colour = new ParkingLogApp.SearchCarPlatesByColorCommand.AppCommand();
                            Message = registration_numbers_for_cars_with_colour.Execute(service, inputParam);
                            break;
                        case "slot_number_for_cars_with_colour":
                            IAppCommand slot_number_for_cars_with_colour = new ParkingLogApp.SearchSlotByColorCommand.AppCommand();
                            Message = slot_number_for_cars_with_colour.Execute(service, inputParam);
                            break;
                        case "slot_number_for_registration_number":
                            IAppCommand slot_number_for_registration_number = new ParkingLogApp.SearchSlotByCarPlateCommand.AppCommand();
                            Message = slot_number_for_registration_number.Execute(service, inputParam);
                            break;
                        case "exit":
                            IAppCommand exit = new ParkingLogApp.ExitCommand.AppCommand();
                            Message = exit.Execute(service, inputParam);
                            break;
                    }
                    Console.WriteLine(Message);
                }
            }

            /*string Message = string.Empty;
            string CommandName = "create_parking_lot";
            IParkingLogManagementService service = new ParkingLogManagementService("DefaultParkingLotSize".ConfigIntValue(1));
            Dictionary<string, IAppCommand> appCommandDic = InitAppCommandDictionary();                     
            IAppCommand create = appCommandDic[CommandName];
            Message = create.Execute(service, 6);
            Console.WriteLine(Message);

            CommandName = "park";
            IAppCommand park = appCommandDic[CommandName];
            Message = park.Execute(service, "KA-01-HH-1234", "White");
            Console.WriteLine(Message);
            Message = park.Execute(service, "KA-01-HH-9999", "White");
            Console.WriteLine(Message);
            Message = park.Execute(service, "KA-01-BB-0001", "Black");
            Console.WriteLine(Message);
            Message = park.Execute(service, "KA-01-HH-7777", "Red");
            Console.WriteLine(Message);
            Message = park.Execute(service, "KA-01-HH-2701", "Blue");
            Console.WriteLine(Message);
            Message = park.Execute(service, "KA-01-HH-3141", "Black");
            Console.WriteLine(Message);

            IAppCommand leave = new ParkingLogApp.LeaveCommand.AppCommand();
            Message = leave.Execute(service, 4);
            Console.WriteLine(Message);
            IAppCommand status = new ParkingLogApp.StatusCommand.AppCommand();
            Message = status.Execute(service);
            Console.WriteLine(Message);

            CommandName = "park";
            park = appCommandDic[CommandName];
            Message = park.Execute(service, "KA-01-P-333", "White");
            Console.WriteLine(Message);
            Message = park.Execute(service, "DL-12-AA-9999", "White");
            Console.WriteLine(Message);

            IAppCommand registration_numbers_for_cars_with_colour = new ParkingLogApp.SearchCarPlatesByColorCommand.AppCommand();
            Message = registration_numbers_for_cars_with_colour.Execute(service, "White");
            Console.WriteLine(Message);

            IAppCommand slot_number_for_cars_with_colour = new ParkingLogApp.SearchSlotByColorCommand.AppCommand();
            Message = slot_number_for_cars_with_colour.Execute(service, "White");
            Console.WriteLine(Message);

            IAppCommand slot_number_for_registration_number = new ParkingLogApp.SearchSlotByCarPlateCommand.AppCommand();
            Message = slot_number_for_registration_number.Execute(service, "KA-01-HH-3141");
            Console.WriteLine(Message);
            Message = slot_number_for_registration_number.Execute(service, "MH-04-AY-1111");
            Console.WriteLine(Message);

            IAppCommand exit = new ParkingLogApp.ExitCommand.AppCommand();
            Message = exit.Execute(service);
            Console.WriteLine(Message);

            Console.ReadKey();*/
        }

        static Dictionary<string, IAppCommand> InitAppCommandDictionary()
        {
            Dictionary<string, IAppCommand> appCommandDic = new Dictionary<string, IAppCommand>();
            var dicConfig = CommonHelper.InitAppCommandConfig();
            foreach (var item in dicConfig)
            {
                IAppCommand com = (IAppCommand)AssemblyLoadingHelper.GetObj(item.Value["AssemblyName"], item.Value["TypeFullName"]);
                appCommandDic.Add(item.Key, com);
            }

            return appCommandDic;
        }
    }
}
