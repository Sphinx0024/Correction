using Activ.Pointis.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Activ.Pointis.WebAPI.Models
{
    public class PointageModel
    {
        public static List<V_Pointage> afficher()
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                          select p).ToList();
                return donnees;
            }
        }

        public static List<V_Pointage> AfficherUnSeul(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<V_Pointage> donnees = (from p in _db.V_Pointage
                                            where p.PointageID == id
                                          select p).ToList();
                return donnees;
            }

        }


        public static void Ajouter(Pointage pointage)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                _db.Pointage.Add(pointage);
                _db.SaveChanges();
            }

        }

        public static void Modifier(long id, Pointage pointage)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          where p.PointageID == id
                                          select p).ToList();

                foreach (Pointage point in donnees)
                {
                    point.Jour = pointage.Jour;
                    point.HeureEntree = pointage.HeureEntree;
                    point.HeureSortie = pointage.HeureSortie;
                    point.Application_id_sortie = pointage.Application_id_sortie;
                    point.Application_id_entree = pointage.Application_id_entree;
                    point.EmployesID = pointage.EmployesID;
                    point.Imei_employe_entree = pointage.Imei_employe_entree;
                    point.Imei_employe_sortie = pointage.Imei_employe_sortie;
                    point.Imei_verificateur_sortie = pointage.Imei_verificateur_sortie;
                    point.Imei_verificateur_entree = pointage.Imei_verificateur_sortie;
                    

                    _db.SaveChanges();
                }

                
            }
        }

        public static void supprimer(long id)
        {
            using (PointisEntities _db = new PointisEntities())
            {
                List<Pointage> donnees = (from p in _db.Pointage
                                          where p.PointageID == id
                                          select p).ToList();

                _db.Pointage.RemoveRange(donnees);
                _db.SaveChanges();
            }
        }
    }
}