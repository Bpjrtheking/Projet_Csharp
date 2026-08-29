class Etudiant
{
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public string Matricule { get; set; }
    public double? Note { get; set; }

    public string GetMention()
    {
        if (!Note.HasValue)
            return "Non renseignée";

        if (Note >= 16)
            return "Très bien";
        else if (Note >= 14)
            return "Bien";
        else if (Note >= 12)
            return "Assez bien";
        else if (Note >= 10)
            return "Passable";
        else
            return "Insuffisant";
    }
}