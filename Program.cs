using System;
using System.Collections.Generic;

class Program
{
    static List<Etudiant> etudiants = new List<Etudiant>();

    static void Main()
    {
        int choix;

        do
        {
            Console.Clear();

            Console.WriteLine("=== GESTION DE CLASSE ===");
            Console.WriteLine();
            Console.WriteLine("1. Saisir les étudiants");
            Console.WriteLine("2. Saisir / Modifier les notes");
            Console.WriteLine("3. Afficher la liste complète");
            Console.WriteLine("4. Afficher les étudiants admis");
            Console.WriteLine("5. Afficher les étudiants à rattraper");
            Console.WriteLine("6. Rechercher un étudiant");
            Console.WriteLine("7. Afficher les statistiques de la classe");
            Console.WriteLine("8. Trier les étudiants (par nom ou par note)");
            Console.WriteLine("9. Supprimer un étudiant");
            Console.WriteLine("10. Quitter");
            Console.WriteLine();

            Console.Write("Votre choix : ");
            choix = Convert.ToInt32(Console.ReadLine());

            switch (choix)
            {
                case 1:
                    SaisirEtudiants();
                    break;

                case 2:
                    Console.WriteLine("Saisie / Modification des notes");
                    break;

                case 3:
                    Console.WriteLine("Liste complète");
                    break;

                case 4:
                    Console.WriteLine("Étudiants admis");
                    break;

                case 5:
                    Console.WriteLine("Étudiants à rattraper");
                    break;

                case 6:
                    Console.WriteLine("Recherche d'un étudiant");
                    break;

                case 7:
                    Console.WriteLine("Statistiques de la classe");
                    break;

                case 8:
                    Console.WriteLine("Tri des étudiants");
                    break;

                case 9:
                    Console.WriteLine("Suppression d'un étudiant");
                    break;

                case 10:
                    Console.WriteLine("Au revoir !");
                    break;

                default:
                    Console.WriteLine("Choix invalide.");
                    break;
            }

            if (choix != 10)
            {
                Console.WriteLine();
                Console.WriteLine("Appuyez sur une touche pour continuer...");
                Console.ReadKey();
            }

        } while (choix != 10);
    }

    static void SaisirEtudiants()
    {
        Console.Clear();

        Console.WriteLine("=== SAISIE DES ÉTUDIANTS ===");
        Console.WriteLine();

        Console.Write("Combien d'étudiants voulez-vous ajouter ? ");
        int nombre = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < nombre; i++)
        {
            Console.Clear();

            Console.WriteLine("=== ÉTUDIANT " + (i + 1) + " ===");
            Console.WriteLine();

            Console.Write("Nom : ");
            string nom = Console.ReadLine();

            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();

            Console.Write("Matricule : ");
            string matricule = Console.ReadLine();

            bool existe = false;

            foreach (Etudiant etudiant in etudiants)
            {
                if (etudiant.Matricule == matricule)
                {
                    existe = true;
                    break;
                }
            }

            if (existe)
            {
                Console.WriteLine();
                Console.WriteLine("Ce matricule existe déjà.");
                Console.WriteLine("Cet étudiant ne sera pas ajouté.");
                Console.ReadKey();

                i--;
                continue;
            }

            Etudiant nouvelEtudiant = new Etudiant();

            nouvelEtudiant.Nom = nom;
            nouvelEtudiant.Prenom = prenom;
            nouvelEtudiant.Matricule = matricule;
            nouvelEtudiant.Note = null;

            etudiants.Add(nouvelEtudiant);

            Console.WriteLine();
            Console.WriteLine("Étudiant ajouté avec succès !");
            Console.ReadKey();
        }

        Console.Clear();

        Console.WriteLine("Tous les étudiants ont été saisis.");
        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }
}