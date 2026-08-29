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
                    SaisirModifierNote();
                    break;

                case 3:
                    AfficherEtudiants();
                    break;

                case 4:
                    AfficherAdmis();
                    break;

                case 5:
                    AfficherRattrapage();
                    break;

                case 6:
                    RechercherEtudiant();
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

    static void AfficherEtudiants()
    {
        Console.Clear();

        Console.WriteLine("=== LISTE DES ÉTUDIANTS ===");
        Console.WriteLine();

        if (etudiants.Count == 0)
        {
            Console.WriteLine("Aucun étudiant enregistré.");
        }
        else
        {
            foreach (Etudiant etudiant in etudiants)
            {
                Console.WriteLine("Nom : " + etudiant.Nom);
                Console.WriteLine("Prénom : " + etudiant.Prenom);
                Console.WriteLine("Matricule : " + etudiant.Matricule);

                if (etudiant.Note.HasValue)
                    Console.WriteLine("Note : " + etudiant.Note + "/20");
                else
                    Console.WriteLine("Note : Non renseignée");

                Console.WriteLine("Mention : " + etudiant.GetMention());
                Console.WriteLine("----------------------------");
            }
        }

        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }

    static void SaisirModifierNote()
    {
        Console.Clear();

        Console.WriteLine("=== SAISIR / MODIFIER UNE NOTE ===");
        Console.WriteLine();

        if (etudiants.Count == 0)
        {
            Console.WriteLine("Aucun étudiant enregistré.");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour revenir...");
            Console.ReadKey();
            return;
        }

        Console.Write("Entrez le nom ou le matricule de l'étudiant : ");
        string recherche = Console.ReadLine();

        Etudiant etudiantTrouve = null;

        foreach (Etudiant etudiant in etudiants)
        {
            if (etudiant.Nom.Equals(recherche, StringComparison.OrdinalIgnoreCase)
                || etudiant.Matricule.Equals(recherche, StringComparison.OrdinalIgnoreCase))
            {
                etudiantTrouve = etudiant;
                break;
            }
        }

        if (etudiantTrouve == null)
        {
            Console.WriteLine();
            Console.WriteLine("Étudiant introuvable.");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour revenir...");
            Console.ReadKey();
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Étudiant : " + etudiantTrouve.Prenom + " " + etudiantTrouve.Nom);
        Console.WriteLine("Matricule : " + etudiantTrouve.Matricule);

        if (etudiantTrouve.Note.HasValue)
            Console.WriteLine("Ancienne note : " + etudiantTrouve.Note + "/20");
        else
            Console.WriteLine("Ancienne note : Non renseignée");

        double note;

        while (true)
        {
            Console.Write("Nouvelle note (0 à 20) : ");

            if (double.TryParse(Console.ReadLine(), out note))
            {
                if (note >= 0 && note <= 20)
                    break;
            }

            Console.WriteLine("Note invalide. Entrez une note entre 0 et 20.");
        }

        etudiantTrouve.Note = note;

        Console.WriteLine();
        Console.WriteLine("Note enregistrée avec succès !");
        Console.WriteLine("Mention : " + etudiantTrouve.GetMention());

        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }

    static void RechercherEtudiant()
    {
        Console.Clear();

        Console.WriteLine("=== RECHERCHER UN ÉTUDIANT ===");
        Console.WriteLine();

        if (etudiants.Count == 0)
        {
            Console.WriteLine("Aucun étudiant enregistré.");
            Console.WriteLine();
            Console.WriteLine("Appuyez sur une touche pour revenir...");
            Console.ReadKey();
            return;
        }

        Console.Write("Nom ou matricule : ");
        string recherche = Console.ReadLine();

        Etudiant etudiantTrouve = null;

        foreach (Etudiant etudiant in etudiants)
        {
            if (etudiant.Nom.Equals(recherche, StringComparison.OrdinalIgnoreCase)
                || etudiant.Matricule.Equals(recherche, StringComparison.OrdinalIgnoreCase))
            {
                etudiantTrouve = etudiant;
                break;
            }
        }

        Console.WriteLine();

        if (etudiantTrouve == null)
        {
            Console.WriteLine("Aucun étudiant trouvé.");
        }
        else
        {
            Console.WriteLine("=== ÉTUDIANT TROUVÉ ===");
            Console.WriteLine("Nom : " + etudiantTrouve.Nom);
            Console.WriteLine("Prénom : " + etudiantTrouve.Prenom);
            Console.WriteLine("Matricule : " + etudiantTrouve.Matricule);

            if (etudiantTrouve.Note.HasValue)
                Console.WriteLine("Note : " + etudiantTrouve.Note + "/20");
            else
                Console.WriteLine("Note : Non renseignée");

            Console.WriteLine("Mention : " + etudiantTrouve.GetMention());
        }

        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour revenir au menu...");
        Console.ReadKey();
    }

    static void AfficherAdmis()
    {
        Console.Clear();

        Console.WriteLine("=== ÉTUDIANTS ADMIS ===");
        Console.WriteLine();

        int total = 0;

        foreach (Etudiant etudiant in etudiants)
        {
            if (etudiant.Note.HasValue && etudiant.Note >= 10)
            {
                Console.WriteLine(etudiant.Nom + " " + etudiant.Prenom
                    + " - " + etudiant.Note + "/20");
                total++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Nombre total d'admis : " + total);
        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour revenir...");
        Console.ReadKey();
    }

    static void AfficherRattrapage()
    {
        Console.Clear();

        Console.WriteLine("=== ÉTUDIANTS À RATTRAPER ===");
        Console.WriteLine();

        int total = 0;

        foreach (Etudiant etudiant in etudiants)
        {
            if (etudiant.Note.HasValue && etudiant.Note < 10)
            {
                Console.WriteLine(etudiant.Nom + " " + etudiant.Prenom
                    + " - " + etudiant.Note + "/20");
                total++;
            }
        }

        Console.WriteLine();
        Console.WriteLine("Nombre total à rattraper : " + total);
        Console.WriteLine();
        Console.WriteLine("Appuyez sur une touche pour revenir...");
        Console.ReadKey();
    }
}