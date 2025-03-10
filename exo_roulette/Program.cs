namespace Roulette
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = @".\names.txt";
            string lastOutput = @".\lastOutput.txt";

            Console.WriteLine("------------------------");
            Console.WriteLine("Roulette en C#\r");
            Console.WriteLine("------------------------\n");

            
            Console.WriteLine("Choisir une option");
            Console.WriteLine("\tf - Find Name");
            Console.WriteLine("\ta - Add");
            Console.WriteLine("\tr - Remove");
            Console.Write("Your option? ");
            string reponse = Console.ReadLine();

            if (!string.IsNullOrEmpty(reponse))
            {
                switch (reponse)
                {
                    

                    case "f":
                        if (File.Exists(file) && File.Exists(lastOutput))
                        {
                            string[] lines = File.ReadAllLines(file);
                            string last = File.ReadLines(lastOutput).LastOrDefault();

                            Random number = new Random();
                            string name;

                            do
                            {
                                name = lines[number.Next(lines.Length)];
                            }
                            while (name == last);

                            File.AppendAllText(lastOutput, name + Environment.NewLine);
                            Console.WriteLine($"Voici un nom prit au hasard dans le fichier: {name}");
                        }
                        else { 
                            Console.WriteLine("Fichier non trouvé"); 
                        }
                        break;
                    case "a":
                        Console.WriteLine("Entrer les noms a ajouter : ( laisser vide pour valider )");
                        List<string> names = new List<string>();
                        while (true)
                        {
                            string newName = Console.ReadLine()?.Trim();
                            if (string.IsNullOrEmpty(newName))
                            {
                                break; 
                            }
                            names.Add(newName);
                        }
                        if (names.Count() > 0)
                        {
                            File.AppendAllLines(file, names);
                            Console.WriteLine($"{string.Join(" / ", names )} ajouté au fichier !");
                        } else
                        {
                            Console.WriteLine("Aucun ajout");
                        }

                            break;
                    case "r":
                        List<string> existingNames = new List<string>(File.ReadAllLines(file));
                        Console.WriteLine("Entrer un nom à supprimer : (laisser vide pour annuler)");
                        Console.WriteLine("- " + string.Join("\n- ", existingNames)); 
                        string wantedName = Console.ReadLine()?.Trim();
                        
                        if (string.IsNullOrEmpty(wantedName))
                        {
                            Console.WriteLine("Null");
                        }else if (!existingNames.Contains(wantedName)) {
                            Console.WriteLine($"{wantedName} n'est pas dans la liste");
                        } else
                        {
                            Console.WriteLine($"Nom à supprimer : {wantedName}");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("La commande est mal formée !");
            }
        }
    }
}