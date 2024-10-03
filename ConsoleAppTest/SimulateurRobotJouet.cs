using System;

namespace SimulateurRobotJouet
{
    public enum Direction
    {
        NORD,
        EST,
        SUD,
        OUEST
    }

    public class Robot
    {
        private int? x = null;
        private int? y = null;
        private Direction? facing = null;
        private const int TAILLE_TABLE = 5;

        public void Placer(int x, int y, Direction direction)
        {
            if (EstPositionValide(x, y))
            {
                this.x = x;
                this.y = y;
                this.facing = direction;
            }
        }

        public void Deplacer()
        {
            if (x.HasValue && y.HasValue && facing.HasValue)
            {
                switch (facing)
                {
                    case Direction.NORD:
                        if (y + 1 < TAILLE_TABLE) y++;
                        break;
                    case Direction.SUD:
                        if (y - 1 >= 0) y--;
                        break;
                    case Direction.EST:
                        if (x + 1 < TAILLE_TABLE) x++;
                        break;
                    case Direction.OUEST:
                        if (x - 1 >= 0) x--;
                        break;
                }
            }
        }

        public void Gauche()
        {
            if (facing.HasValue)
            {
                facing = (Direction)(((int)facing + 3) % 4); // Tourner à gauche
            }
        }

        public void Droite()
        {
            if (facing.HasValue)
            {
                facing = (Direction)(((int)facing + 1) % 4); // Tourner à droite
            }
        }

        public string Rapport()
        {
            if (x.HasValue && y.HasValue && facing.HasValue)
            {
                return $"{x},{y},{facing}";
            }
            return string.Empty;
        }

        private bool EstPositionValide(int x, int y)
        {
            return x >= 0 && x < TAILLE_TABLE && y >= 0 && y < TAILLE_TABLE;
        }
    }

    public class TraitementCommande
    {
        private readonly Robot robot = new Robot();

        public void TraiterCommandes(string[] commandes)
        {
            foreach (var commande in commandes)
            {
                if (commande.StartsWith("PLACE"))
                {
                    var parties = commande.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parties.Length == 4)
                    {
                        int x, y;
                        Direction direction;
                        if (int.TryParse(parties[1], out x) && int.TryParse(parties[2], out y) && Enum.TryParse(parties[3], out direction))
                        {
                            robot.Placer(x, y, direction);
                        }
                    }
                }
                else if (commande == "DÉPLACER")
                {
                    robot.Deplacer();
                }
                else if (commande == "GAUCHE")
                {
                    robot.Gauche();
                }
                else if (commande == "DROITE")
                {
                    robot.Droite();
                }
                else if (commande == "RAPPORT")
                {
                    var resultat = robot.Rapport();
                    if (!string.IsNullOrEmpty(resultat))
                    {
                        Console.WriteLine(resultat);
                    }
                }
            }
        }
    }
}
