using System;
using System.Linq;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
   class Program
    {
       static void Main(string[] args)
        {
            Test(
                new[] { 3, 4 }, 
                new[] { 2, 8 }, 
                new[] { 5, 2 }, 
                new[] { "P", "p", "C", "c", "F", "f", "T", "t" }, 
                new[] { 1, 0, 1, 0, 0, 1, 1, 0 });
            Test(
                new[] { 3, 4, 1, 5 }, 
                new[] { 2, 8, 5, 1 }, 
                new[] { 5, 2, 4, 4 }, 
                new[] { "tFc", "tF", "Ftc" }, 
                new[] { 3, 2, 0 });
            Test(
                new[] { 18, 86, 76, 0, 34, 30, 95, 12, 21 }, 
                new[] { 26, 56, 3, 45, 88, 0, 10, 27, 53 }, 
                new[] { 93, 96, 13, 95, 98, 18, 59, 49, 86 }, 
                new[] { "f", "Pt", "PT", "fT", "Cp", "C", "t", "", "cCp", "ttp", "PCFt", "P", "pCt", "cP", "Pc" }, 
                new[] { 2, 6, 6, 2, 4, 4, 5, 0, 5, 5, 6, 6, 3, 5, 6 });
            Console.ReadKey(true);
        }

        private static void Test(int[] protein, int[] carbs, int[] fat, string[] dietPlans, int[] expected)
        {
            var result = SelectMeals(protein, carbs, fat, dietPlans).SequenceEqual(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"Proteins = [{string.Join(", ", protein)}]");
            Console.WriteLine($"Carbs = [{string.Join(", ", carbs)}]");
            Console.WriteLine($"Fats = [{string.Join(", ", fat)}]");
            Console.WriteLine($"Diet plan = [{string.Join(", ", dietPlans)}]");
            Console.WriteLine(result);
        }

        public static int[] SelectMeals(int[] protein, int[] carbs, int[] fat, string[] dietPlans)
        {
            
            int[] dietRes = new int[dietPlans.Length];
            int[] calories = new int[protein.Length];
            List<int> temp = new List<int>();
            /*
            There Function Create:

            1> checkDup()  -- To check if more the one value is present for Maximum and Minimum value.
            
            2> function1_for_same_value()  -- if more the one value present for Maximum the we store the index of all Maximum value and pass to next iteration to check
                                              if there is conflict for same value if not then add that value to answer.
        
            3> function2_for_same_value()  -- if more the one value present for Minimum the we store the index of all Minimum value and pass to next iteration to check
                                              if there is conflict for same value if not then add that value to answer.
             */
            for (int i = 0; i < protein.Length; i++)
                calories[i] = protein[i] * 5 + carbs[i] * 5 + fat[i] * 9;
            
               for (int i = 0; i < dietPlans.Length; i++)
            {
                string diet = dietPlans[i];
                int id=0, flag=0;
                 temp.Clear();
                 for(int o=0;o<protein.Length;o++)
                     temp.Add(o);
                     
              if(diet=="") dietRes[i]=0;
              else{
                for(int j=0;j<diet.Length;j++)
                {   
                    if(diet[j]=='P')
                    { 
                        id = Array.IndexOf(protein, protein.Max());
                        if(checkDup( protein[id], protein )>1 && flag==0)
                        { flag=1;temp = function1_for_same_value(protein,temp); }
                        else
                        {
                          temp = function1_for_same_value(protein,temp); 
                        }
                    }
                    else if(diet[j]=='p')
                    {
                        id = Array.IndexOf(protein, protein.Min());
                        if(checkDup( protein[id], protein )>1 && flag==0)
                        { flag=1;temp = function2_for_same_value(protein,temp); }
                        else
                        {
                          temp = function2_for_same_value(protein,temp); 
                        }
                    }
                    else if(diet[j]=='C')
                    {
                        id = Array.IndexOf(carbs, carbs.Max());
                        if(checkDup( carbs[id], carbs )>1  && flag==0)
                        { flag=1;temp =function1_for_same_value(carbs,temp);}
                        else
                        {
                           temp = function1_for_same_value(carbs,temp);
                        }
                    }
                    else if(diet[j]=='c')
                    {
                        id = Array.IndexOf(carbs, carbs.Min());
                        if(checkDup( carbs[id], carbs )>1  && flag==0)
                        { flag=1;temp = function2_for_same_value(carbs,temp);}
                        else
                        {
                           temp = function2_for_same_value(carbs,temp);
                        }
                    }
                    else if(diet[j]=='F')
                    {
                        id = Array.IndexOf(fat, fat.Max());
                        if(checkDup( fat[id],fat )>1 && flag==0)
                        { flag=1; temp = function1_for_same_value(fat,temp);}
                        else{
                            temp = function1_for_same_value(fat,temp);
                        }
                    }
                    else if(diet[j]=='f')
                    {
                        id = Array.IndexOf(fat, fat.Min());
                        if(checkDup( fat[id],fat )>1 && flag==0)
                        { flag=1; temp = function2_for_same_value(fat,temp);}
                        else{
                            temp = function2_for_same_value(fat,temp);
                        }
                    }
                    else if(diet[j]=='T')
                    {
                        id = Array.IndexOf(calories, calories.Max());
                        if(checkDup( calories[id],calories )>1 && flag==0)
                        {flag=1; temp= function1_for_same_value(calories,temp); }
                        else{
                            temp= function1_for_same_value(calories,temp);
                        }
                    }
                    else if(diet[j]=='t')
                    {
                        id = Array.IndexOf(calories, calories.Min());
                        if(checkDup( calories[id],calories )>1 && flag==0)
                        {
                         flag=1;
                         temp= function2_for_same_value(calories,temp);
                        }
                        else{

                            temp= function2_for_same_value(calories,temp);
                        }
                    }
                    if(flag!=1)
                    break;
                }
               if(flag==1) dietRes[i] = temp[0];
               else
                dietRes[i]=id;
            }
            }

            foreach(int x in dietRes) Console.Write(x+" ");
            return dietRes;

            throw new NotImplementedException();
        }
        /*
        TO check if duplicate are present or not
         */
        public static int checkDup(int item , int[] itemAr)
        {
            int c=0;
            foreach(int x in itemAr)
            {
                if(x==item) c++;
            }
            return c;
        }
        
        /*
        TO check if duplicate Maximum are present and store there index value
         */

       public static List<int> function1_for_same_value(int[] list1, List<int> temp)
        {
            int value = list1[temp[0]];
            List<int> itemnew = new List<int>();
            for(int i =1;i<temp.Count;i++){
                 if(value<list1[temp[i]]){
                     value = list1[temp[i]];
                 }
            }    
            
            foreach(int i in temp){
                 if(list1[i]==value){ 
                  itemnew.Add(i);
                 }
            }
            return itemnew;
        }

        /*
        TO check if duplicate Minimum are present and store there index value
         */
       public static List<int> function2_for_same_value(int[] list1, List<int> temp)
        {
            int value = list1[temp[0]];
            List<int> itemnew = new List<int>();
            for(int i =1;i<temp.Count;i++){
                 if(value>list1[temp[i]]){
                     value = list1[temp[i]];
                 }
            }    
            
            foreach(int i in temp){
                 if(list1[i]==value){ 
                  itemnew.Add(i);
                 }
            }
            return itemnew;
        }

    }
}
