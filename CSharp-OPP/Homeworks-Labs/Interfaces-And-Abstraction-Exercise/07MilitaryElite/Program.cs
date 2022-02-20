using System;
using System.Collections.Generic;

namespace InterfacesAbstration
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            while(true)
            {
                string command = Console.ReadLine();

                if (command == "End") break;

                string[] commands = command.Split();

                string type = commands[0];
                string id = commands[1];
                string firstName = commands[2];
                string lastName = commands[3];

                if(type == nameof(Private))
                {
                    decimal salary = decimal.Parse(commands[4]);

                    soldiersById[id] = new Private(id, firstName, lastName, salary);
                }
                else if(type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(commands[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < commands.Length; i++)
                    {
                        string privateId = commands[i];

                        if(!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        lieutenantGeneral.AddPrivate((IPrivate)soldiersById[privateId]);
                    }
                    soldiersById[id] = lieutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(commands[4]);

                    bool isCorpseValid = Enum.TryParse(commands[5], out Corps corps);

                    if(!isCorpseValid)
                    {
                        continue;
                    }
                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commands.Length; i += 2)
                    {
                        string partName = commands[i];
                        int hourseWorked = int.Parse(commands[i + 1]);

                        IRepair repair = new Repair(partName, hourseWorked);
                        engineer.AddRepair(repair);
                    }

                    soldiersById[id] = engineer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(commands[4]);

                    bool isCorpseValid = Enum.TryParse(commands[5], out Corps corps);

                    if (!isCorpseValid)
                    {
                        continue;
                    }
                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < commands.Length; i += 2)
                    {
                        string codeName = commands[i];
                        string missionState = commands[i + 1];

                        bool isMissionStateValid = Enum.TryParse(missionState, out State state);

                        if (!isMissionStateValid) continue;

                        IMission mission = new Mission(codeName, state);
                        commando.AddMission(mission);
                    }
                    soldiersById[id] = commando;
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(commands[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }
            }
            foreach (var soldier in soldiersById.Values)
            {
                Console.WriteLine(soldier);
            }
        }
    }
}
