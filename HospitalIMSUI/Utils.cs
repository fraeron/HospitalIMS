using System;
using System.Collections.Generic;

namespace HospitalIMSUI
{
    public class Utils
    {
        public static string GetPrescriptionCard()
        {
            string card = ("""
                
                """);
            return card;
        }

        public static void ShowTitleCard()
        {
            string title = """

            $$$$$$$\                  $$\                   $$\                $$$$$$\                                         
            $$  __$$\                 $$ |                  $  |              $$  __$$\                                        
            $$ |  $$ | $$$$$$\   $$$$$$$ | $$$$$$\   $$$$$$\\_/$$$$$$$\       $$ /  \__| $$$$$$\  $$$$$$\   $$$$$$$\  $$$$$$\  
            $$$$$$$  |$$  __$$\ $$  __$$ |$$  __$$\ $$  __$$\ $$  _____|      $$ |$$$$\ $$  __$$\ \____$$\ $$  _____|$$  __$$\ 
            $$  ____/ $$$$$$$$ |$$ /  $$ |$$ |  \__|$$ /  $$ |\$$$$$$\        $$ |\_$$ |$$ |  \__|$$$$$$$ |$$ /      $$$$$$$$ |
            $$ |      $$   ____|$$ |  $$ |$$ |      $$ |  $$ | \____$$\       $$ |  $$ |$$ |     $$  __$$ |$$ |      $$   ____|
            $$ |      \$$$$$$$\ \$$$$$$$ |$$ |      \$$$$$$  |$$$$$$$  |      \$$$$$$  |$$ |     \$$$$$$$ |\$$$$$$$\ \$$$$$$$\ 
            \__|       \_______| \_______|\__|       \______/ \_______/        \______/ \__|      \_______| \_______| \_______|

            ====================================================================================================================
                     H O S P I T A L     I N F O R M A T I O N     M A N A G E M E N T     S Y S T E M   v . 1 . 0
            ====================================================================================================================
                             
                                "In the name of the divine - care meets compassion, regardless of religion."

            """;
            Console.WriteLine(title);
        }

        public static void ShowDoctorCard()
        {
            string title = $"""

                8888888b.                    888                    d8b              888b     d888                            
                888  "Y88b                   888                    88P              8888b   d8888                            
                888    888                   888                    8P               88888b.d88888                            
                888    888  .d88b.   .d8888b 888888 .d88b.  888d888 "  .d8888b       888Y88888P888  .d88b.  88888b.  888  888 
                888    888 d88""88b d88P"    888   d88""88b 888P"      88K           888 Y888P 888 d8P  Y8b 888 "88b 888  888 
                888    888 888  888 888      888   888  888 888        "Y8888b.      888  Y8P  888 88888888 888  888 888  888 
                888  .d88P Y88..88P Y88b.    Y88b. Y88..88P 888             X88      888   "   888 Y8b.     888  888 Y88b 888 
                8888888P"   "Y88P"   "Y8888P  "Y888 "Y88P"  888         88888P'      888       888  "Y8888  888  888  "Y88888
                
                """;
            Console.WriteLine(title);
        }

        public static void ShowNurseCard()
        {
            string title = """

                888b    888                                   d8b              888b     d888                            
                8888b   888                                   88P              8888b   d8888                            
                88888b  888                                   8P               88888b.d88888                            
                888Y88b 888 888  888 888d888 .d8888b   .d88b. "  .d8888b       888Y88888P888  .d88b.  88888b.  888  888 
                888 Y88b888 888  888 888P"   88K      d8P  Y8b   88K           888 Y888P 888 d8P  Y8b 888 "88b 888  888 
                888  Y88888 888  888 888     "Y8888b. 88888888   "Y8888b.      888  Y8P  888 88888888 888  888 888  888 
                888   Y8888 Y88b 888 888          X88 Y8b.            X88      888   "   888 Y8b.     888  888 Y88b 888 
                888    Y888  "Y88888 888      88888P'  "Y8888     88888P'      888       888  "Y8888  888  888  "Y88888
                
                """;
            Console.WriteLine(title);
        }

        public static void CreateBanner(string title, string description="")
        {
            string banner = "";
            string border = "";
            int borderSize = title.Length;
            for (int i = 0; i < borderSize; i++) border += "=";
            banner += border + "\n";
            banner += title.ToUpper() + "\n";
            banner += border + "\n";
            banner += (description.Length > 0) ? description += "\n" : "";
            Console.WriteLine(banner);
        }

        public static void CreateMenu(List<string> options, bool doIndex=true)
        {
            int index = 0;
            foreach (string option in options)
            {
                index++;
                if (doIndex)
                {
                    Console.WriteLine($"[{index}] {option}");
                }
                else
                {
                    Console.WriteLine(option);
                }
            }
            Console.WriteLine();
        }

        public static void PressToConfirm()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
