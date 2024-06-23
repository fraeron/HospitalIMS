using HospitalIMSUI;
using System.Collections.Generic;
using System;
using HospitalIMSServices;

namespace HostpitalIMSUI
{
    internal class Program
    {
        private static bool isActive = true;
        private static bool isLogin = false;
        private static Apps apps = new Apps();
        private static Utils utils = new Utils();

        private static void ShowMainMenu()
        {
            Console.Write(">>> ");
            string userInput = Console.ReadLine() ?? "";
            switch (userInput)
            {
                case "1":
                    ShowLoginMenu();
                    break;
                case "2":
                    isActive = false;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    Console.ReadLine();
                    ShowMainMenuOptions();
                    break;
            }
        }

        private static void ShowDoctorMenuOptions()
        {
            utils.CreateMenu(new List<String> {
                "Search for a Patient's Record",
                "Add a New Patient Record",
                "Delete an Old Patient Record",
                "View your Personal Information",
                "Review Your Prescription History",
                "View List of Medications",
                "Logout"
            });
            ShowNextUpdate();
        }

        private static void ShowNextUpdate()
        {
            Console.WriteLine("\n[ANNOUNCEMENT] To be added in the next update:");
            utils.CreateMenu(new List<String> {
                "Add a Prescription",
                "Remove a Prescription",
                "View Medication"
            }, false);
        }

        private static void ShowNurseMenuOptions()
        {
            utils.CreateMenu(new List<String> {
                "Search for a Patient's Record",
                "Add a New Patient Record",
                "Delete an Old Patient Record",
                "View your Personal Information",
                "View List of Medications",
                "Logout"
            });
            ShowNextUpdate();
        }

        private static void ShowDoctorMenu()
        {
            while (isLogin)
            {
                Console.Clear();
                utils.ShowDoctorCard();
                utils.CreateBanner(
                    $"WELCOME, DOCTOR {apps.GetName()}!",
                    "What can we do for you today?");
                ShowDoctorMenuOptions();
                Console.Write(">>> ");
                string userInput = Console.ReadLine() ?? "";
                switch (userInput)
                {
                    case "1":
                        apps.SearchForPatient();
                        break;
                    case "2":
                        apps.AddNewPatient();
                        break;
                    case "3":
                        apps.DeleteOldPatient();
                        break;
                    case "4":
                        apps.ViewPersonalInformation();
                        break;
                    case "5":
                        apps.ViewPrescriptHistory();
                        break;
                    case "6":
                        apps.ViewMedicineList();
                        break;
                    case "7":
                        isLogin = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void ShowNurseMenu()
        {
            while (isLogin)
            {
                Console.Clear();
                utils.ShowNurseCard();
                utils.CreateBanner(
                    $"WELCOME, NURSE {apps.GetName()}!",
                    "What can we do for you today?");
                ShowNurseMenuOptions();
                Console.Write(">>> ");
                string userInput = Console.ReadLine() ?? "";
                switch (userInput)
                {
                    case "1":
                        apps.SearchForPatient();
                        break;
                    case "2":
                        apps.AddNewPatient();
                        break;
                    case "3":
                        apps.DeleteOldPatient();
                        break;
                    case "4":
                        apps.ViewPersonalInformation();
                        break;
                    case "5":
                        apps.ViewMedicineList();
                        break;
                    case "6":
                        isLogin = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void ShowLoginMenu()
        {
            Console.Write("[LOGIN] Please enter your username: ");
            string username = Console.ReadLine() ?? "";
            Console.Write("[LOGIN] Please enter your password: ");
            string password = Console.ReadLine() ?? "";
            Services.UserType userType = apps.VerifyUser(username, password);
            switch (userType)
            {
                case Services.UserType.Doctor:
                    isLogin = true;
                    ShowDoctorMenu();
                    break;
                case Services.UserType.Nurse:
                    isLogin = true;
                    ShowNurseMenu();
                    break;
                default:
                    Console.WriteLine("Invalid username or password. Please try again.");
                    Console.ReadLine();
                    break;
            }
        }

        private static void ShowMainMenuOptions()
        {
            Console.Clear();
            utils.ShowTitleCard();
            utils.CreateBanner(
                "Welcome! Please login your credentials to continue."
                );
            utils.CreateMenu(new List<String> {
                "Login",
                "Exit"
            });
        }

        private static void Main(string[] args) {          
            while (isActive)
            {
                ShowMainMenuOptions();
                ShowMainMenu();
            }
        }
    }
}
