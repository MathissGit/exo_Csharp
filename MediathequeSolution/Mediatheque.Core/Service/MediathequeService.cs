﻿using Mediatheque.Core.Model;

namespace Mediatheque.Core.Service
{
    public class MediathequeService
    {
        private List<ObjetDePret> _fondDeCommerce = new List<ObjetDePret>();
        private INotationService _notationService;

        public MediathequeService(INotationService notationService)
        {
            _notationService = notationService;
        }

        public void AddObjet(ObjetDePret objet)
        {
            _fondDeCommerce.Add(objet);
        }

        public int GetNombreObjet()
        {
            return _fondDeCommerce.Count;
        }

        public string GetNombreJeux()
        {
            int nombreJeux = _fondDeCommerce.Count(objet => objet is JeuxDeSociete);
            return nombreJeux > 0 ? nombreJeux.ToString() : "Pas de jeux";
        }
    }
}
