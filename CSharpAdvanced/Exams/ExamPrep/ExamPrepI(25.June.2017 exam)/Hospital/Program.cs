using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{

    static void Main()
    {
        Dictionary<string, Dictionary<int, List<string>>> dictDepRoom = new Dictionary<string, Dictionary<int, List<string>>>();
        Dictionary<string, List<string>> dictDocPatient = new Dictionary<string, List<string>>();
        Dictionary<string, List<string>> dictDepPatient = new Dictionary<string, List<string>>();
        while (true)
        {
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (input[0] == "Output")
            {
                break;
            }
            string department = input[0];
            string doctor = input[1] + " " + input[2];
            string patient = input[3];
            if (!dictDepRoom.ContainsKey(department))
            {
                dictDepRoom.Add(department, new Dictionary<int, List<string>>());
                int roomNumber = dictDepRoom[department].Keys.Count() + 1;
                dictDepRoom[department].Add(roomNumber, new List<string>());
                dictDepRoom[department][roomNumber].Add(patient);
                dictDocPatient = AddDataToDict(dictDocPatient, doctor, patient);
                dictDepPatient = AddDataToDict(dictDepPatient, department, patient);
            }
            else
            {
                if (dictDepRoom[department].Keys.Count <= 20)
                {
                    int roomNumber = dictDepRoom[department].Keys.Count();
                    if (dictDepRoom[department][roomNumber].Count() <= 2)
                    {
                        dictDepRoom[department][roomNumber].Add(patient);
                        dictDocPatient = AddDataToDict(dictDocPatient, doctor, patient);
                        dictDepPatient = AddDataToDict(dictDepPatient, department, patient);
                    }
                    else if (dictDepRoom[department][dictDepRoom[department].Keys.Count].Count() >= 3)
                    {
                        if (dictDepRoom[department].Keys.Count < 20)
                        {
                            int newRoomNumber = roomNumber + 1;
                            dictDepRoom[department].Add(newRoomNumber, new List<string>());
                            dictDepRoom[department][newRoomNumber].Add(patient);
                            dictDocPatient = AddDataToDict(dictDocPatient, doctor, patient);
                            dictDepPatient = AddDataToDict(dictDepPatient, department, patient);
                        }

                    }

                }
            }
        }
        while (true)
        {
            var outputRequests = Console.ReadLine().Split(new string[] { " "}, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (outputRequests[0]=="End")
            {
                break;
            }
            if (outputRequests.Count()==1)
            {
                var department = outputRequests[0];
                foreach (var patient in dictDepPatient[department])
                {
                    Console.WriteLine($"{patient}");
                }
            }
            else if(outputRequests.Count>=2)
            {
                int roomNumber;
                var hasParsed=int.TryParse(outputRequests[1], out roomNumber);
                if (hasParsed)
                {
                   string department= outputRequests[0];
                    foreach (var patient in dictDepRoom[department][roomNumber].OrderBy(x=>x))
                    {
                        Console.WriteLine($"{patient}");
                    }
                }
                else
                {
                    string doctor = outputRequests[0] + " " + outputRequests[1];
                    foreach (var patient in dictDocPatient[doctor].OrderBy(x=>x))
                    {
                        Console.WriteLine($"{patient}");
                    }
                }
            }
        }
    }

    private static Dictionary<string, List<string>> AddDataToDict(Dictionary<string, List<string>> dict, string theKey, string patient)
    {
        if (!dict.ContainsKey(theKey))
        {
            dict.Add(theKey, new List<string>());
            dict[theKey].Add(patient);
            return dict;
        }
        dict[theKey].Add(patient);
        return dict;

    }
}

