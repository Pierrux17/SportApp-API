using BLL.Models;
using BLL.Repositories;
using BLL.Tools;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProfilServiceBLL : IProfilRepositoryBLL<ProfilBLL>
    {
        private readonly IProfilRepositoryDAL _profilRepository;

        public ProfilServiceBLL(IProfilRepositoryDAL profilRepository)
        {
            _profilRepository = profilRepository;
        }

        public ProfilBLL Create(ProfilBLL p)
        {
            _profilRepository.Create(Mappers.ToDAL(p));
            return p;
        }

        public IEnumerable<ProfilBLL> GetAll()
        {
            return _profilRepository.GetAll().Select(p => Mappers.ToBLL(p));
        }

        public ProfilBLL GetById(int id)
        {
            return Mappers.ToBLL(_profilRepository.GetById(id));
        }

        //public ProfilBLL GetByIdPerson(int id)
        //{
        //    return Mappers.ToBLL(_profilRepository.GetByIdPerson(id));
        //}

        public ProfilBLL GetByIdPerson(int id)
        {
            try
            {
                var profilDAL = _profilRepository.GetByIdPerson(id);
                if (profilDAL == null)
                {
                    // Ici, si le profil n'est pas trouvé, nous renvoyons un profil vide ou une valeur par défaut.
                    return new ProfilBLL();
                }

                return Mappers.ToBLL(profilDAL);
            }
            catch (Exception ex)
            {
                // Gérez l'exception de manière appropriée (par exemple, journalisation, traitement supplémentaire, etc.).
                // Pour l'instant, nous allons simplement afficher l'erreur.
                Console.WriteLine("Erreur lors de la conversion du profil DAL en profil BLL : " + ex.Message);
                return null;
            }
        }


        public void Update(ProfilBLL p)
        {
            _profilRepository.Update(Mappers.ToDAL(p));
        }
    }
}
