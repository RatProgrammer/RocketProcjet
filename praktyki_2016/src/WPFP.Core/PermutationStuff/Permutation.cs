using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFP.CommunicationLayer.DTO;

namespace WPFP.Core.PermutationStuff
{
    class Permutation
    {
        public static void GetCombination()
        {
            List<string> listOfActions = GetList();
            GetRandomOrder(listOfActions);
        }

        public static void GetRandomOrder(List<string> listOfActions )
        {
            StreamWriter streamWriter = new StreamWriter(@"combination.txt");
            Random random=new Random();
            int n = listOfActions.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                string value = listOfActions[k];
                listOfActions[k] = listOfActions[n];
                listOfActions[n] = value;
            }
            for (int i = 0; i < listOfActions.Count; i++)
            {
                streamWriter.WriteLine(listOfActions[i]);
            }

            streamWriter.Close();

        }

        public static List<string> GetList()
        {
            List<string> listOfActions = new List<string>();
            listOfActions.Add("focus_science primary 10");
            listOfActions.Add("focus_science secondary 10");
            listOfActions.Add("focus_production secondary 10");
            listOfActions.Add("focus_production cargo 10");
            listOfActions.Add("focus_production cargo 10");
            listOfActions.Add("focus_production cargo 10");
            listOfActions.Add("perform_work 10");
            listOfActions.Add("perform_work 10");
            listOfActions.Add("perform_work 10");
            listOfActions.Add("hire_people engineer 10");
            listOfActions.Add("hire_people scientist 10");
            listOfActions.Add("fire_people engineer 10");
            listOfActions.Add("fire_people scientist 10");
            listOfActions.Add("marketing 10");
            listOfActions.Add("slower_time 10");
            listOfActions.Add("slower_time 10");
            listOfActions.Add("hire_people engineer 10");
            listOfActions.Add("hire_people scientist 10");
            listOfActions.Add("focus_science primary 10");
            listOfActions.Add("focus_production primary 10");
            listOfActions.Add("focus_production primary 10");
            listOfActions.Add("focus_science primary 10");
            listOfActions.Add("focus_science primary 10");
            listOfActions.Add("focus_production primary 10");
            listOfActions.Add("focus_production primary 10");


            //listOfActions[12] = "launch_rocket_to_mars 10";
            return listOfActions;
        }

    }

    public enum Actions
    {
        FocusScience,//primary, secondary
        FocusProduction,//primary, secondary, cargo
        PerformWork,
        HirePeople,//engineer, scientist
        FirePeople,//------------||--------
        Marketing,
        SlowerTime,
        LaunchRocketToMars
    }
}
