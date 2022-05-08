using System;
using System.IO;

namespace PollutionType_Editor
{
    class Program
    {
        enum GoopType : uint
        {
            Sink = 0,
            Burn = 1,
            Slip = 2,
            NonLateralMovement = 3,
            Shock = 4,
            Miss = 5,
            None = 6,
            BurnV2 = 7
        };

        static void Main(string[] args)
        {
            Console.Title = "Pollution Type Editor";

            string YMP;
            if (args.Length == 0 || Path.GetExtension(args[0]) != ".ymp")
            {
                Console.Write("Input 'ymap.ymp' File Path > ", 1);
                YMP = Console.ReadLine();
                if (Path.GetExtension(YMP) != ".ymp")
                {
                    Environment.Exit(0);
                }
                Console.Clear();
            }
            else
            {
                YMP = args[0];
            }

            var YMPBytes = File.ReadAllBytes(YMP);
            switch (YMPBytes[9])
            {
                case (byte)GoopType.Sink:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Mario sinks and takes damage)");
                    break;
                case (byte)GoopType.Burn:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Burns Mario)");
                    break;
                case (byte)GoopType.Slip:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Mario slips and takes damage)");
                    break;
                case (byte)GoopType.NonLateralMovement:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Prevents Mario from moving laterally)");
                    break;
                case (byte)GoopType.Shock:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Shocks Mario)");
                    break;
                case (byte)GoopType.Miss:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Kills Mario)");
                    break;
                case (byte)GoopType.None:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Stains clothes, does no damage)");
                    break;
                case (byte)GoopType.BurnV2:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (Burns Mario)");
                    break;
                default:
                    Console.WriteLine($"Current Pollution Type: {YMPBytes[9]} (No effect)");
                    break;
            }

            Console.WriteLine
                (
                "\nAll Pollution Types:\n" +
                "0: Mario sinks and takes damage\n" +
                "1: Burns Mario\n" +
                "2: Mario slips and takes damage\n" +
                "3: Prevents Mario from moving laterally\n" +
                "4: Shocks Mario\n" +
                "5: Kills Mario\n" +
                "6: Stains clothes, does no damage\n" +
                "7: Burns Mario\n" +
                "8+ : No effect\n"
                );
            Console.Write("Input New Pollution Type > ");
            int PollutionType = int.Parse(Console.ReadKey().KeyChar.ToString());

            FileStream Fs = new FileStream(YMP, FileMode.Open, FileAccess.ReadWrite);
            Fs.Position = 9; // because the pollution type is determined by the 9th byte
            Fs.WriteByte((byte)PollutionType);
            Fs.Close();

            Console.WriteLine($"\n\nSuccessfully set pollution type to {PollutionType}!");
            Console.Write("Press any key to continue . . .");
            Console.ReadKey();
        }
    }
}
