using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class ConnexionModel
    {
        public static List<Connexion> afficher()
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           select p).ToList();
                return donnees;
            }
        }

        public static List<Connexion> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id
                                         select p).ToList();
                return donnees;
            }

        }


        public static void Ajouter(Connexion connexion)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.Connexion.Add(connexion);
                _db.SaveChanges();
            }

        }

        public static void Modifier(long id, Connexion connexion)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id
                                         select p).ToList();

                foreach (Connexion connexion1 in donnees)
                {
                    connexion1.Login = connexion.Login;
                    connexion1.Password = connexion.Password;
                    connexion1.EmployeID = connexion.EmployeID;
                    connexion1.Role = connexion.Role;

                }
                _db.SaveChanges();
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Connexion> donnees = (from p in _db.Connexion
                                           where p.ConnexionID == id
                                         select p).ToList();

                _db.Connexion.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }

        public static bool IsValidUser(string login, string pwd)
        {
            
            using (PointisEntities _db = new PointisEntities())
            {
                bool isValid = false;
                var donnees = (from c in _db.Connexion
                                          where c.Login == login && c.Password == pwd
                                          select c);
                 if(donnees.Any())
                {
                    return isValid;
                }
                 else 
                {
                    isValid = true;
                    return isValid;
                }

            }
        }
    }
}